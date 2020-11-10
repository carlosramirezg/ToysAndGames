using ToysApi.Controllers;
using Xunit;
using Moq;
using ToysDatabase;
using ToysApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToysTests
{
	public class ToyControllerTests
	{
		[Fact]
		public void GetById_Test()
		{
			//Arrange
			var repositoryMock = new Mock<IRepository<Toy>>();
			repositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(new Toy { Id = 1, Name = "Playstation" });
			var controller = new ToysController(repositoryMock.Object);

			//Act
			var result = controller.GetById(1);

			//Assert
			Assert.Equal("Playstation", result.Name);
		}

		[Fact]
		public void Get_Test()
		{
			//Arrange
			var repositoryMock = new Mock<IRepository<Toy>>();
			repositoryMock.Setup(x => x.GetAll())
				.Returns(new List<Toy>()
				{  
					new Toy { Id = 1, Name = "Playstation"},
					new Toy { Id = 2, Name = "Superman"} 
				});
			var controller = new ToysController(repositoryMock.Object);

			//Act
			var result = controller.Get();

			//Assert
			Assert.Equal(2, result.Count());
		}

		[Fact]
		public void Post_Test()
		{
			//Arrange
			var repositoryMock = new Mock<IRepository<Toy>>();
			repositoryMock.Setup(x => x.Add(It.IsAny<Toy>())).Verifiable();
			var controller = new ToysController(repositoryMock.Object);

			//Act
			controller.Post(new Toy());

			//Assert
			repositoryMock.Verify(x => x.Add(It.IsAny<Toy>()), Times.Once);
		}

		[Fact]
		public void PutTest()
		{
			//Arrange
			var repositoryMock = new Mock<IRepository<Toy>>();
			repositoryMock.Setup(x => x.Update(It.IsAny<Toy>())).Verifiable();			
			var controller = new ToysController(repositoryMock.Object);

			//Act
			controller.Put(new Toy());

			//Assert
			repositoryMock.Verify(x => x.Update(It.IsAny<Toy>()), Times.Once);
		}

		[Fact]
		public void DeleteTest()
		{
			//Arrange
			var repositoryMock = new Mock<IRepository<Toy>>();
			repositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Verifiable();
			var controller = new ToysController(repositoryMock.Object);

			//Act
			controller.Delete(3);

			//Assert
			repositoryMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
		}
	}
}
