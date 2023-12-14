using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DAL.TESTS
{
    public class TestsBaseRepository
    {
        [Fact]
        public void Create_InputFurniture_CallAddMethodOfFurnitureDbSet()
        {
            //Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<PCSContext>().Options;
            var mockContext = new Mock<PCSContext>(opt);
            var mockFurnitureDbSet = new Mock<DbSet<Furniture>>();

            //налаштовуємо проперті Set<Furniture>, dbCotnext'у так,
            //щоб при виклику він повертав об'єкт моку mockFurnitureDbSet
            mockContext
               .Setup(context => context.Set<Furniture>()).Returns(mockFurnitureDbSet.Object);

            TestFurnitureRepository repository = new TestFurnitureRepository(mockContext.Object);
            Furniture expectedFurniture = new Mock<Furniture>().Object;

            //Act
            repository.Create(expectedFurniture);

            //Assert
            //перевіряємо, що метод Add, dbSet'у був викликаний з параметром expectedFurniture один раз
            mockFurnitureDbSet.Verify(
                dbSet => dbSet.Add(expectedFurniture), Times.Once());
        }

        [Fact]
        public void Get_InputId_CallFindMethodOfFurnitureDbSet()
        {
            //Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<PCSContext>().Options;
            var mockContext = new Mock<PCSContext>(opt);
            var mockFurnitureDbSet = new Mock<DbSet<Furniture>>();

            //налаштовуємо проперті Set<Furniture>, dbCotnext'у так,
            //щоб при виклику він повертав об'єкт моку mockFurnitureDbSet
            mockContext
               .Setup(context => context.Set<Furniture>()).Returns(mockFurnitureDbSet.Object);

            Furniture expectedFurniture = new Furniture()
            {
                Id = 2,
                Name = "Стіл дубовий",
                category = FurnitureCategory.Table
            };

            //налаштовуємо метод Find, dbSet'у так,
            //щоб при виклику Find(2) він повертав об'єкт expectedFurniture
            mockFurnitureDbSet
                .Setup(mock => mock.Find(2)).Returns(expectedFurniture);

            TestFurnitureRepository repository = new TestFurnitureRepository(mockContext.Object);

            //Act
            var actionResult = repository.Get(2);

            //Assert
            //перевіряємо, що метод Find, dbSet'у був викликаний з параметром (2) один раз
            mockFurnitureDbSet.Verify(
                dbSet => dbSet.Find(2), Times.Once());
            //перевіряємо на рівність отриманий і заданий в Setup(mock => mock.Find(2)) об'єкти
            Assert.Equal(expectedFurniture, actionResult);
        }

        [Fact]
        public void Delete_InputId_CallFindMethodOfFurnitureDbSetThanCallRemoveMethodOfFurnitureDbSet()
        {
            //Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<PCSContext>().Options;
            var mockContext = new Mock<PCSContext>(opt);
            var mockFurnitureDbSet = new Mock<DbSet<Furniture>>();

            //налаштовуємо проперті Set<Furniture>, dbCotnext'у так,
            //щоб при виклику він повертав об'єкт моку mockFurnitureDbSet
            mockContext
               .Setup(context => context.Set<Furniture>()).Returns(mockFurnitureDbSet.Object);

            Furniture expectedFurniture = new Furniture()
            {
                Id = 2,
                Name = "Стіл дубовий",
                category = FurnitureCategory.Table
            };

            //налаштовуємо метод Find, dbSet'у так,
            //щоб при виклику Find(2) він повертав об'єкт expectedFurniture
            mockFurnitureDbSet
                .Setup(mock => mock.Find(2)).Returns(expectedFurniture);

            TestFurnitureRepository repository = new TestFurnitureRepository(mockContext.Object);

            //Act
            repository.Delete(2);

            //Assert
            //перевіряємо, що метод Find, dbSet'у був викликаний з параметром (2) один раз
            mockFurnitureDbSet.Verify(
                repo => repo.Find(2), Times.Once());
            //перевіряємо, що метод Remove, dbSet'у був викликаний з параметром expectedFurniture один раз
            mockFurnitureDbSet.Verify(
                dbSet => dbSet.Remove(expectedFurniture), Times.Once());
        }
    }
}
