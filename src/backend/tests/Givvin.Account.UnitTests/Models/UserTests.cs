using Givvin.Account.Models;
using MongoDB.Bson;
using NUnit.Framework;
using System;

namespace Givvin.Account.UnitTests.Models
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void User_Model_Properties_Are_Correctly_Set()
        {
            // Arrange
            var user = new User
            {
                Id = ObjectId.GenerateNewId(),
                LoginId = ObjectId.GenerateNewId(),
                FirstName = "John",
                LastName = "Doe",
                Location = "123 Main St, City",
                Phone = "+123456789",
                SocialNetworks = new Dictionary<string, string>(),
                Roles = new List<Role>(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Assert
            Assert.AreEqual("John", user.FirstName);
            Assert.AreEqual("Doe", user.LastName);
            Assert.AreEqual("123 Main St, City", user.Location);
            Assert.AreEqual("+123456789", user.Phone);
            Assert.IsNotNull(user.SocialNetworks);
            Assert.IsNotNull(user.Roles);
            Assert.AreEqual(0, user.SocialNetworks.Count);
            Assert.AreEqual(0, user.Roles.Count);
        }

        [Test]
        public void User_Model_With_Default_Values_Is_Correct()
        {
            // Arrange
            var user = new User();

            // Assert
            Assert.IsNull(user.Id);
            Assert.IsNull(user.LoginId);
            Assert.IsNull(user.FirstName);
            Assert.IsNull(user.LastName);
            Assert.IsNull(user.Location);
            Assert.IsNull(user.Phone);
            Assert.IsNotNull(user.SocialNetworks);
            Assert.IsNotNull(user.Roles);
            Assert.AreEqual(0, user.SocialNetworks.Count);
            Assert.AreEqual(0, user.Roles.Count);
        }

        [Test]
        public void User_Model_Can_Add_Role()
        {
            // Arrange
            var user = new User();
            var role = new Role();

            // Act
            user.Roles.Add(role);

            // Assert
            Assert.AreEqual(1, user.Roles.Count);
            Assert.AreEqual(role, user.Roles[0]);
        }

        [Test]
        public void User_Model_Can_Add_SocialNetwork_Profile()
        {
            // Arrange
            var user = new User();
            var provider = "Facebook";
            var profileUrl = "https://www.facebook.com/johndoe";

            // Act
            user.SocialNetworks.Add(provider, profileUrl);

            // Assert
            Assert.AreEqual(1, user.SocialNetworks.Count);
            Assert.AreEqual(profileUrl, user.SocialNetworks[provider]);
        }

        [Test]
        public void User_Model_Can_Be_Created_With_Roles_And_SocialNetworks()
        {
            // Arrange
            var user = new User
            {
                Id = ObjectId.GenerateNewId(),
                LoginId = ObjectId.GenerateNewId(),
                FirstName = "John",
                LastName = "Doe",
                Location = "123 Main St, City",
                Phone = "+123456789",
                SocialNetworks = new Dictionary<string, string>
            {
                { "Facebook", "https://www.facebook.com/johndoe" },
                { "Twitter", "https://www.twitter.com/johndoe" }
            },
                Roles = new List<Role>
            {
                new Role
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Admin",
                    Description = "Administrator role with full access",
                    Permissions = new List<string> { "Read", "Write", "Delete" },
                    OpenIdProviders = new List<string> { "Google", "Facebook" }
                },
                new Role
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Editor",
                    Description = "Editor role with limited access",
                    Permissions = new List<string> { "Read", "Write" },
                    OpenIdProviders = new List<string> { "Google", "Apple" }
                }
            },
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Assert
            Assert.AreEqual("John", user.FirstName);
            Assert.AreEqual("Doe", user.LastName);
            Assert.AreEqual("123 Main St, City", user.Location);
            Assert.AreEqual("+123456789", user.Phone);
            Assert.AreEqual(2, user.SocialNetworks.Count);
            Assert.AreEqual("https://www.facebook.com/johndoe", user.SocialNetworks["Facebook"]);
            Assert.AreEqual("https://www.twitter.com/johndoe", user.SocialNetworks["Twitter"]);
            Assert.AreEqual(2, user.Roles.Count);
            Assert.AreEqual("Admin", user.Roles[0].Name);
            Assert.AreEqual("Editor", user.Roles[1].Name);
        }

        [Test]
        public void User_Model_Can_Remove_Role()
        {
            // Arrange
            var user = new User();
            var role1 = new Role { Id = ObjectId.GenerateNewId() };
            var role2 = new Role { Id = ObjectId.GenerateNewId() };
            user.Roles.Add(role1);
            user.Roles.Add(role2);

            // Act
            user.Roles.Remove(role1);

            // Assert
            Assert.AreEqual(1, user.Roles.Count);
            Assert.AreEqual(role2, user.Roles[0]);
        }

        [Test]
        public void User_Model_Can_Remove_SocialNetwork_Profile()
        {
            // Arrange
            var user = new User();
            var provider1 = "Facebook";
            var provider2 = "Twitter";
            user.SocialNetworks.Add(provider1, "https://www.facebook.com/johndoe");
            user.SocialNetworks.Add(provider2, "https://www.twitter.com/johndoe");

            // Act
            user.SocialNetworks.Remove(provider1);

            // Assert
            Assert.AreEqual(1, user.SocialNetworks.Count);
            Assert.IsFalse(user.SocialNetworks.ContainsKey(provider1));
            Assert.IsTrue(user.SocialNetworks.ContainsKey(provider2));
        }

        [Test]
        public void User_Model_Can_Be_Compared_For_Equality()
        {
            // Arrange
            var user1 = new User
            {
                Id = ObjectId.GenerateNewId(),
                FirstName = "John",
                LastName = "Doe"
            };

            var user2 = new User
            {
                Id = user1.Id,
                FirstName = user1.FirstName,
                LastName = user1.LastName
            };

            var user3 = new User
            {
                Id = ObjectId.GenerateNewId(),
                FirstName = "Jane",
                LastName = "Smith"
            };

            // Assert
            Assert.AreEqual(user1, user2);
            Assert.AreNotEqual(user1, user3);
        }

        [Test]
        public void User_Model_With_Null_FirstName_Is_Invalid()
        {
            // Arrange
            var user = new User
            {
                FirstName = null,
                LastName = "Doe",
                Location = "123 Main St, City",
                Phone = "+123456789",
                SocialNetworks = new Dictionary<string, string>(),
                Roles = new List<Role>(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => user.Validate());
        }

        [Test]
        public void User_Model_With_Null_LastName_Is_Invalid()
        {
            // Arrange
            var user = new User
            {
                FirstName = "John",
                LastName = null,
                Location = "123 Main St, City",
                Phone = "+123456789",
                SocialNetworks = new Dictionary<string, string>(),
                Roles = new List<Role>(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => user.Validate());
        }

        [Test]
        public void User_Model_With_Empty_Roles_Is_Invalid()
        {
            // Arrange
            var user = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Location = "123 Main St, City",
                Phone = "+123456789",
                SocialNetworks = new Dictionary<string, string>(),
                Roles = new List<Role>(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => user.Validate());
        }

        [Test]
        public void User_Model_With_Negative_CreatedAt_Is_Invalid()
        {
            // Arrange
            var user = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Location = "123 Main St, City",
                Phone = "+123456789",
                SocialNetworks = new Dictionary<string, string>(),
                Roles = new List<Role>(),
                CreatedAt = DateTime.UtcNow.AddMinutes(-5),
                UpdatedAt = DateTime.UtcNow
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => user.Validate());
        }

        [Test]
        public void User_Model_With_Empty_FirstName_Is_Invalid()
        {
            // Arrange
            var user = new User
            {
                FirstName = string.Empty,
                LastName = "Doe",
                Location = "123 Main St, City",
                Phone = "+123456789",
                SocialNetworks = new Dictionary<string, string>(),
                Roles = new List<Role>(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => user.Validate());
        }

        [Test]
        public void User_Model_With_Empty_LastName_Is_Invalid()
        {
            // Arrange
            var user = new User
            {
                FirstName = "John",
                LastName = string.Empty,
                Location = "123 Main St, City",
                Phone = "+123456789",
                SocialNetworks = new Dictionary<string, string>(),
                Roles = new List<Role>(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => user.Validate());
        }

        [Test]
        public void User_Model_With_Invalid_Phone_Number_Is_Invalid()
        {
            // Arrange
            var user = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Location = "123 Main St, City",
                Phone = "123456789", // Invalid format
                SocialNetworks = new Dictionary<string, string>(),
                Roles = new List<Role>(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => user.Validate());
        }

        [Test]
        public void User_Model_With_Invalid_SocialNetwork_Profile_Is_Invalid()
        {
            // Arrange
            var user = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Location = "123 Main St, City",
                Phone = "+123456789",
                SocialNetworks = new Dictionary<string, string>
            {
                { "Facebook", "facebook.com/johndoe" } // Invalid URL format
            },
                Roles = new List<Role>(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => user.Validate());
        }
    }
}