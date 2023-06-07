using Givvin.Achieve.Model;
using MongoDB.Bson;
using NUnit.Framework;

namespace Givvin.AchieveUnitTests.Models
{
    [TestFixture]
    public class UserAchievementTests
    {
        [Test]
        public void UserAchievement_SetProperties_ShouldSetValuesCorrectly()
        {
            // Arrange
            UserAchievement userAchievement = new UserAchievement();

            // Act
            userAchievement.Id = ObjectId.GenerateNewId();
            userAchievement.UserId = "1";
            userAchievement.AchievementId = "1";
            userAchievement.DateEarned = DateTime.Now;

            // Assert
            Assert.AreEqual(userAchievement.Id, userAchievement.Id);
            Assert.AreEqual("1", userAchievement.UserId);
            Assert.AreEqual("1", userAchievement.AchievementId);
            Assert.AreEqual(DateTime.Now, userAchievement.DateEarned);
        }

        [Test]
        public void UserAchievement_SetEmptyUserId_ShouldThrowArgumentException()
        {
            // Arrange
            UserAchievement userAchievement = new UserAchievement();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => userAchievement.UserId = "");
        }

        [Test]
        public void UserAchievement_SetEmptyAchievementId_ShouldThrowArgumentException()
        {
            // Arrange
            UserAchievement userAchievement = new UserAchievement();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => userAchievement.AchievementId = "");
        }
    }
}
