using Givvin.Volunteer.Models;
using NUnit.Framework;

namespace Givvin.Volunteer.UnitTests.Models
{
    [TestFixture]
    public class ContributionTests
    {
        [Test]
        public void Contribution_ValidAmount_AmountSet()
        {
            // Arrange
            var contribution = new Contribution
            {
                CampaignId = "1",
                Amount = 100
            };

            // Act
            var amount = contribution.Amount;

            // Assert
            Assert.That(amount, Is.EqualTo(100));
        }

        [Test]
        public void Contribution_InvalidAmount_AmountNotSet()
        {
            // Arrange
            var contribution = new Contribution
            {
                CampaignId = "1",
                Amount = -100
            };

            // Act
            var amount = contribution.Amount;

            // Assert
            Assert.That(amount, Is.EqualTo(0));
        }

        [Test]
        public void Contribution_DefaultValues_IsAnonymousFalse()
        {
            // Arrange
            var contribution = new Contribution
            {
                CampaignId = "1",
                Amount = 100
            };

            // Act
            var isAnonymous = contribution.IsAnonymous;

            // Assert
            Assert.That(isAnonymous, Is.False);
        }

        [Test]
        public void Contribution_SetIsAnonymous_IsAnonymousUpdated()
        {
            // Arrange
            var contribution = new Contribution
            {
                CampaignId = "1",
                Amount = 100,
                IsAnonymous = false
            };

            // Act
            contribution.IsAnonymous = true;

            // Assert
            Assert.That(contribution.IsAnonymous, Is.True);
        }
    }

}
