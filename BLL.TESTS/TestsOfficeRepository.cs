using BLL.DTO;
using BLL.Services.Impl;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Moq;

namespace BLL.TESTS
{
    public class TestsOfficeRepository
    {
        [Fact]
        public void Ctor_InputNulUnitOfWork_ThrowsArgumentNullException()
        {
            //Arrange
            IUnitOfWork unitOfWork = null;

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(
                () => new OfficeService(unitOfWork));
        }

        [Fact]
        public void GetOffices_InputHeadManager_ThrowsMethodAccessException()
        {
            //Arrange
            SecurityContext.SetUser(new HeadManager(
                2,
                "������",
                "VasilGysalov@gmail.com",
                "HeadManager"
                ));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockOfficeService = new Mock<OfficeService>(mockUnitOfWork.Object);

            //Act
            //Assert
            //����������, �� ��� ������� ������ GetOffices(), OfficeService'�
            //� ������������ ���� HeadManager ���������� �������
            Assert.Throws<MethodAccessException>(
                () => mockOfficeService.Object.GetOffices());
        }

        [Fact]
        public void GetOffices_InputAssistManager_ReturnsOfficeDTO()
        {
            //Arrange
            SecurityContext.SetUser(new AssistManager(
                2,
                "�����",
                "PertrikBeytman@gmail.com",
                "AssistManager"
                ));

            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var offices = new List<Office>(new Office[]
            {
                new Office(),
                new Office()
            });

            //����������� ����� GetAll, OfficeRepository ���,
            //��� ��� ������� �� �������� ����� ��'���� offices
            mockUnitOfWork
                .Setup(unit => unit.OfficeRepository.GetAll()).Returns(offices);

            var mockOfficeService = new Mock<OfficeService>(mockUnitOfWork.Object);

            //Act
            List<OfficeDTO> serviceResult = mockOfficeService.Object.GetOffices().ToList();

            //Assert 
            //���������� �� ������������� ������� �
            //������� � Setup(unit => unit.OfficeRepository.GetAll()) ��'����
            Assert.Equivalent(serviceResult[0], offices[0]);
            Assert.Equivalent(serviceResult[1], offices[1]);
        }

        [Fact]
        public void GetOfficeFurniture_InputHeadManager_ThrowsMethodAccessException()
        {
            //Arrange
            SecurityContext.SetUser(new HeadManager(
                3,
                "������",
                "VasilGysalov@gmail.com",
                "HeadManager"
                ));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockOfficeService = new Mock<OfficeService>(mockUnitOfWork.Object);

            //Act
            //Assert
            //����������, �� ��� ������� ������ GetOfficeFurniture(3), OfficeService'�
            //� ������������ ���� HeadManager ���������� �������
            Assert.Throws<MethodAccessException>(
                () => mockOfficeService.Object.GetOfficeFurniture(3));
        }

        [Fact]
        public void GetOfficeFurniture_InputAssistManagerAndOfficeId_CallsFindMethodOfFurnitureRepositoryy()
        {
            //Arrange
            SecurityContext.SetUser(new Manager(
                2,
                "�������",
                "Jmihaylo@gmail.com",
                "Manager"
                ));

            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var mockFurnitureRepository = new Mock<IFurnitureRepository>();
            //����������� ������� FurnitureRepository, UnitOfWork'� ���,
            //��� ��� ������� �� �������� ��'��� ���� mockFurnitureRepository
            mockUnitOfWork
                .Setup(unit => unit.FurnitureRepository).Returns(mockFurnitureRepository.Object);

            var mockOfficeRepository = new Mock<IOfficeRepository>();
            //����������� ������� OfficeRepository, UnitOfWork'� ���,
            //��� ��� ������� �� �������� ��'��� ���� mockOfficeRepository
            mockUnitOfWork
                .Setup(unit => unit.OfficeRepository).Returns(mockOfficeRepository.Object);

            //����������� ����� Get, OfficeRepository ���,
            //��� ��� ������� Get(2) �� �������� ����� ��'��� Office
            mockOfficeRepository
                .Setup(repo => repo.Get(2)).Returns(new Office());

            var officeService = new OfficeService(mockUnitOfWork.Object);

            //Act
            var serviceResult = officeService.GetOfficeFurniture(2);

            //Assert
            //����������, �� ����� Find, FurnitureRepository
            //��� ���������� � ����-���� ��������� ���� ���
            mockFurnitureRepository.Verify(
                repo => repo.Find(It.IsAny<Func<Furniture, bool>>()), Times.Once);
        }
    }
}