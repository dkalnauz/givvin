using Givvin.Achieve.Model;
using MongoDB.Bson;
using NUnit.Framework;

namespace Givvin.AchieveUnitTests.Models
{
    [TestFixture]
    public class AchievementRuleTests
    {
        [Test]
        public void AchievementRule_SetProperties_ShouldSetValuesCorrectly()
        {
            // Arrange
            AchievementRule rule = new AchievementRule();

            // Act
            rule.Requirement = 1;
            rule.Description = "Achieved by participating in 10 events";
            rule.AchievementTypeId = ObjectId.GenerateNewId();

            // Assert
            Assert.AreEqual(1, rule.Requirement);
            Assert.AreEqual("Achieved by participating in 10 events", rule.Description);
            Assert.IsNotNull(rule.AchievementTypeId);
        }
    }
}
