using Givvin.Volunteer.Models;
using MongoDB.Bson.Serialization.Attributes;
using NUnit.Framework;

namespace Givvin.Volunteer.UnitTests.Models
{
    [TestFixture]
    public class CampaignTests
    {
        [Test]
        public void Campaign_ConstructedWithDefaultValues_PropertiesInitializedCorrectly()
        {
            // Arrange
            var campaign = new Campaign();

            // Assert
            Assert.That(campaign.Id, Is.Null.Or.Empty);
            Assert.That(campaign.Title, Is.Null);
            Assert.That(campaign.Description, Is.Null);
            Assert.That(campaign.StartDate, Is.EqualTo(default(DateTime)));
            Assert.That(campaign.EndDate, Is.EqualTo(default(DateTime)));
            Assert.That(campaign.GoalAmount, Is.EqualTo(0));
            Assert.That(campaign.CurrentAmount, Is.EqualTo(0));
            Assert.That(campaign.CreatedBy, Is.Null.Or.Empty);
            Assert.That(campaign.Contributors, Is.Not.Null);
            Assert.That(campaign.Contributors.Count, Is.EqualTo(0));
            Assert.That(campaign.IsActive, Is.False);
        }

        [Test]
        public void Campaign_Id_HasBsonIdAttribute()
        {
            // Arrange
            var idProperty = typeof(Campaign).GetProperty("Id");

            // Assert
            Assert.That(idProperty, Has.Attribute<BsonIdAttribute>());
        }
    }
}
