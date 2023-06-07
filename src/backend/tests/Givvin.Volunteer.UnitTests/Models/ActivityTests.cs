using Givvin.Volunteer.Models;
using NUnit.Framework;

namespace Givvin.Volunteer.UnitTests.Models
{
    [TestFixture]
    public class ActivityTests
    {
        [Test]
        public void Activity_PropertiesInitialized_Successfully()
        {
            // Arrange
            var activity = new Activity();

            // Act

            // Assert
            Assert.IsNotNull(activity.Id);
            Assert.IsNull(activity.Name);
            Assert.IsNull(activity.Description);
            Assert.AreEqual(default(DateTime), activity.StartTime);
            Assert.AreEqual(default(DateTime), activity.EndTime);
            Assert.IsNull(activity.Location);
            Assert.AreEqual(0, activity.MaxParticipants);
            Assert.IsNotNull(activity.Participants);
            Assert.AreEqual(0, activity.Participants.Count);
            Assert.IsNull(activity.Type);
            Assert.IsNotNull(activity.Requirements);
            Assert.AreEqual(0, activity.Requirements.Count);
        }

        [Test]
        public void Activity_Participants_AddParticipant_Successfully()
        {
            // Arrange
            var activity = new Activity();
            var participant = new Participant { UserId = "123", Status = "Registered" };

            // Act
            activity.Participants.Add(participant);

            // Assert
            Assert.AreEqual(1, activity.Participants.Count);
            Assert.AreEqual(participant, activity.Participants[0]);
        }

        [Test]
        public void Activity_StartTime_EndTime_SetSuccessfully()
        {
            // Arrange
            var activity = new Activity();
            var startTime = DateTime.UtcNow;
            var endTime = startTime.AddHours(2);

            // Act
            activity.StartTime = startTime;
            activity.EndTime = endTime;

            // Assert
            Assert.AreEqual(startTime, activity.StartTime);
            Assert.AreEqual(endTime, activity.EndTime);
        }

        [Test]
        public void Activity_AddRequirement_Successfully()
        {
            // Arrange
            var activity = new Activity();
            var requirement = new Requirement { Name = "Age Limit", Value = "18" };

            // Act
            activity.Requirements.Add(requirement);

            // Assert
            Assert.AreEqual(1, activity.Requirements.Count);
            Assert.AreEqual(requirement, activity.Requirements[0]);
        }

        [Test]
        public void Activity_MaxParticipants_ReachLimit_ReturnsTrue()
        {
            // Arrange
            var activity = new Activity { MaxParticipants = 5 };
            for (int i = 0; i < 5; i++)
            {
                activity.Participants.Add(new Participant { UserId = $"User{i + 1}" });
            }

            // Act
            var isFull = activity.IsMaxParticipantsReached();

            // Assert
            Assert.IsTrue(isFull);
        }

        [Test]
        public void Activity_MaxParticipants_NotReachLimit_ReturnsFalse()
        {
            // Arrange
            var activity = new Activity { MaxParticipants = 10 };
            for (int i = 0; i < 5; i++)
            {
                activity.Participants.Add(new Participant { UserId = $"User{i + 1}" });
            }

            // Act
            var isFull = activity.IsMaxParticipantsReached();

            // Assert
            Assert.IsFalse(isFull);
        }
    }
}