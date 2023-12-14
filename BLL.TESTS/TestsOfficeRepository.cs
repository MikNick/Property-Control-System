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
                "Василь",
                "VasilGysalov@gmail.com",
                "HeadManager"
                ));

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockOfficeService = new Mock<OfficeService>(mockUnitOfWork.Object);

            //Act
            //Assert
            Assert.Throws<MethodAccessException>(
                () => mockOfficeService.Object.GetOffices());
        }

        [Fact]
        public void GetOffices_InputAssistManager_ReturnsRightDTOObjects()
        {

            //Arrange
            SecurityContext.SetUser(new AssistManager(
                2,
                "Петро",
                "PertrikBeytman@gmail.com",
                "AssistManager"
                ));

            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var offices = new List<Office>(new Office[]
            {
                new Office(),
                new Office()
            });

            mockUnitOfWork
                .Setup(unit => unit.OfficeRepository.GetAll()).Returns(offices);

            var mockOfficeService = new Mock<OfficeService>(mockUnitOfWork.Object);

            //Act
            List<OfficeDTO> serviceResult = mockOfficeService.Object.GetOffices().ToList();

            //Assert 
            Assert.Equivalent(serviceResult[0], offices[0]);
            Assert.Equivalent(serviceResult[1], offices[1]);
        }
    }
}