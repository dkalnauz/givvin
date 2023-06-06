using Givvin.Account.Models;
using NUnit.Framework;

namespace Givvin.Account.UnitTests.Models
{
    [TestFixture]
    public class RoleTests
    {
        [Test]
        public void Role_With_Valid_Name_Is_Valid()
        {
            // Arrange
            string roleName = "Admin";

            // Act
            var role = new Role
            {
                Name = roleName
            };

            // Assert
            Assert.AreEqual(roleName, role.Name);
        }

        [Test]
        public void Role_With_Null_Name_Throws_ArgumentNullException()
        {
            // Arrange
            string roleName = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Role
            {
                Name = roleName
            });
        }

        [Test]
        public void Role_With_Empty_Name_Throws_ArgumentException()
        {
            // Arrange
            string roleName = string.Empty;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Role
            {
                Name = roleName
            });
        }

        [Test]
        public void Role_With_Valid_Permissions_Is_Valid()
        {
            // Arrange
            var permissions = new List<string> { "Read", "Write", "Delete" };

            // Act
            var role = new Role
            {
                Permissions = permissions
            };

            // Assert
            Assert.AreEqual(permissions, role.Permissions);
        }

        [Test]
        public void Role_With_Null_Permissions_Is_Valid()
        {
            // Arrange
            List<string> permissions = null;

            // Act
            var role = new Role
            {
                Permissions = permissions
            };

            // Assert
            Assert.IsNull(role.Permissions);
        }

        [Test]
        public void Role_With_Valid_OpenIdProviders_Is_Valid()
        {
            // Arrange
            var providers = new List<string> { "Facebook", "Google", "Apple" };

            // Act
            var role = new Role
            {
                OpenIdProviders = providers
            };

            // Assert
            Assert.AreEqual(providers, role.OpenIdProviders);
        }

        [Test]
        public void Role_With_Null_OpenIdProviders_Is_Valid()
        {
            // Arrange
            List<string> providers = null;

            // Act
            var role = new Role
            {
                OpenIdProviders = providers
            };

            // Assert
            Assert.IsNull(role.OpenIdProviders);
        }

        [Test]
        public void Role_With_Valid_Description_Is_Valid()
        {
            // Arrange
            string description = "Administrator role";

            // Act
            var role = new Role
            {
                Description = description
            };

            // Assert
            Assert.AreEqual(description, role.Description);
        }

        [Test]
        public void Role_With_Null_Description_Is_Valid()
        {
            // Arrange
            string description = null;

            // Act
            var role = new Role
            {
                Description = description
            };

            // Assert
            Assert.IsNull(role.Description);
        }

        [Test]
        public void Role_With_Empty_Permissions_Is_Valid()
        {
            // Arrange
            var permissions = new List<string>();

            // Act
            var role = new Role
            {
                Permissions = permissions
            };

            // Assert
            Assert.IsEmpty(role.Permissions);
        }


        [Test]
        public void Role_With_Empty_OpenIdProviders_Is_Valid()
        {
            // Arrange
            var providers = new List<string>();

            // Act
            var role = new Role
            {
                OpenIdProviders = providers
            };

            // Assert
            Assert.IsEmpty(role.OpenIdProviders);
        }
    }
}
