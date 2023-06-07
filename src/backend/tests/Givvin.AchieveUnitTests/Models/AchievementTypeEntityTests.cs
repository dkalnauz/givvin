using Givvin.Achieve.Model;
using MongoDB.Bson;
using NUnit.Framework;

namespace Givvin.AchieveUnitTests.Models
{
    [TestFixture]
    public class AchievementTypeTests
    {
        [Test]
        public void AchievementType_SetProperties_ShouldSetValuesCorrectly()
        {
            // Arrange
            AchievementType entity = new AchievementType
            {
                // Act
                Id = ObjectId.GenerateNewId(),
                Name = "Event Enthusiast",
                Description = "Earned by actively participating in events"
            };

            // Assert
            Assert.IsNotNull(entity.Id);
            Assert.That(entity.Name, Is.EqualTo("Event Enthusiast"));
            Assert.That(entity.Description, Is.EqualTo("Earned by actively participating in events"));
        }

        [Test]
        public void AchievementType_SetNullName_ShouldThrowArgumentNullException()
        {
            // Arrange
            AchievementType entity = new AchievementType();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => entity.Name = null);
        }

        [Test]
        public void AchievementType_SetEmptyName_ShouldThrowArgumentException()
        {
            // Arrange
            AchievementType entity = new AchievementType();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => entity.Name = "");
        }

        [Test]
        public void AchievementType_SetNullDescription_ShouldThrowArgumentNullException()
        {
            // Arrange
            AchievementType entity = new AchievementType();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => entity.Description = null);
        }

        [Test]
        public void AchievementType_SetEmptyDescription_ShouldThrowArgumentException()
        {
            // Arrange
            AchievementType entity = new AchievementType();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => entity.Description = "");
        }
    }
}