using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskManager_Api.Controllers;
using TaskManager_Api.Models;
using TaskManager_Api.Repositories;
using Xunit;

namespace TareasControllerTests
{
    public class TareasControllerTests
    {
        private readonly Mock<ITareaRepository> _mockRepository;
        private readonly TareasController _controller;

        public TareasControllerTests()
        {
            _mockRepository = new Mock<ITareaRepository>();
            _controller = new TareasController(_mockRepository.Object);
        }

        [Fact]
        public void GetAllTareas_ReturnsOkResult()
        {
            // Arrange
            var tareas = new List<Tarea> { new Tarea { Id = 1, Titulo = "Tarea 1" } };
            _mockRepository.Setup(repo => repo.GetAllTareas()).Returns(tareas);

            // Act
            var result = _controller.GetAllTareas();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnTareas = Assert.IsType<List<Tarea>>(okResult.Value);
            Assert.Equal(1, returnTareas.Count);
        }

        [Fact]
        public void GetTareaById_ExistingId_ReturnsOkResult()
        {
            // Arrange
            var tarea = new Tarea { Id = 1, Titulo = "Tarea 1" };
            _mockRepository.Setup(repo => repo.GetTareaById(1)).Returns(tarea);

            // Act
            var result = _controller.GetTareaById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnTarea = Assert.IsType<Tarea>(okResult.Value);
            Assert.Equal("Tarea 1", returnTarea.Titulo);
        }

        [Fact]
        public void GetTareaById_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetTareaById(1)).Returns((Tarea)null);

            // Act
            var result = _controller.GetTareaById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void CreateTarea_ValidTarea_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var tarea = new Tarea { Id = 1, Titulo = "Tarea 1" };
            _mockRepository.Setup(repo => repo.AddTarea(tarea));

            // Act
            var result = _controller.CreateTarea(tarea);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetTareaById", createdResult.ActionName);
        }

    }
}