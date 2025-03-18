using Moq;
using TestHub.BLL.Interfaces;
using TestHub.BLL.Services;
using TestHub.DAL.Interfaces;
using TestHub.DAL.Models;
using TestHub.DAL.DTO;

namespace TestHub.UnitTests
{
    public class SupervisorServiceTest
    {
        private readonly Mock<ISupervisorRepository> _mockRepo;
        private readonly ISupervisorService _service;

        public SupervisorServiceTest()
        {
            _mockRepo = new Mock<ISupervisorRepository>();
            _service = new SupervisorService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAdminsAsync_ReturnsListOfAdmins()
        {
            // Arrange
            var expectedAdmins = new List<User>
            {
                new User
                {
                    user_id = 1, name = "Admin1", login = "admin1@example.com",
                    password_hash = "hashedpass1", role = "Admin", created_at = DateTime.UtcNow
                },
                new User
                {
                    user_id = 2, name = "Admin2", login = "admin2@example.com",
                    password_hash = "hashedpass2", role = "Admin", created_at = DateTime.UtcNow
                }
            };

            _mockRepo.Setup(repo => repo.GetAdminsAsync()).ReturnsAsync(expectedAdmins);

            // Act
            var result = await _service.GetAdminsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Admin1", result[0].name);
            Assert.Equal("admin2@example.com", result[1].login);
            Assert.All(result, admin => Assert.False(string.IsNullOrEmpty(admin.password_hash)));
        }

        [Fact]
        public async Task AddAdminAsync_CallsRepositoryWithCorrectData()
        {
            // Arrange
            var name = "NewAdmin";
            var login = "newadmin@example.com";
            var password = "securepassword";

            _mockRepo.Setup(repo => repo.AddAdminAsync(It.IsAny<UserDto>())).Returns(Task.CompletedTask);

            // Act
            await _service.AddAdminAsync(name, login, password);

            // Assert
            _mockRepo.Verify(repo => repo.AddAdminAsync(It.Is<UserDto>(u =>
                u.name == name &&
                u.login == login &&
                u.role == "Admin" &&
                !string.IsNullOrEmpty(u.password_hash) &&
                u.created_at <= DateTime.UtcNow
            )), Times.Once);
        }

        [Fact]
        public async Task DeleteAdminAsync_CallsRepositoryWithCorrectId()
        {
            // Arrange
            int userId = 5;
            _mockRepo.Setup(repo => repo.DeleteAdminAsync(userId)).Returns(Task.CompletedTask);

            // Act
            await _service.DeleteAdminAsync(userId);

            // Assert
            _mockRepo.Verify(repo => repo.DeleteAdminAsync(userId), Times.Once);
        }

        [Fact]
        public async Task AddAdminAsync_WhenPasswordIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var name = "NewAdmin";
            var login = "admin@example.com";
            string? password = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.AddAdminAsync(name, login, password));
        }

        [Fact]
        public async Task DeleteAdminAsync_WhenUserNotFound_ThrowsKeyNotFoundException()
        {
            // Arrange
            int nonExistentUserId = 999;
            _mockRepo.Setup(repo => repo.DeleteAdminAsync(nonExistentUserId)).ThrowsAsync(new KeyNotFoundException());

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _service.DeleteAdminAsync(nonExistentUserId));
        }
    }
}