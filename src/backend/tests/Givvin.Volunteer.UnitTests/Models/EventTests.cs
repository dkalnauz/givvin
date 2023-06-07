using NUnit.Framework;

namespace Givvin.Volunteer.UnitTests.Models
{
    [TestFixture]
    public class EventTests
    {
        [Test]
        public void Event_Id_ShouldHaveValidGetterAndSetter()
        {
            // Arrange
            var @event = new Volunteer.Models.Event();
            var id = "12345";

            // Act
            @event.Id = id;

            // Assert
            Assert.That(@event.Id, Is.EqualTo(id));
        }

        [Test]
        public void Event_Name_ShouldHaveValidGetterAndSetter()
        {
            // Arrange
            var @event = new Volunteer.Models.Event();
            var name = "Volunteering Event";

            // Act
            @event.Name = name;

            // Assert
            Assert.That(@event.Name, Is.EqualTo(name));
        }

        [Test]
        public void Event_Description_ShouldHaveValidGetterAndSetter()
        {
            // Arrange
            var @event = new Volunteer.Models.Event();
            var description = "A description of the event.";

            // Act
            @event.Description = description;

            // Assert
            Assert.That(@event.Description, Is.EqualTo(description));
        }

        // ... Repeat the same pattern for other fields ...

        [Test]
        public void Event_Participants_ShouldBeInitialized()
        {
            // Arrange
            var @event = new Volunteer.Models.Event();

            // Act

            // Assert
            Assert.NotNull(@event.Participants);
            Assert.IsEmpty(@event.Participants);
        }

        [Test]
        public void Event_CreatedAt_ShouldBeInitializedWithCurrentDateTime()
        {
            // Arrange
            var @event = new Volunteer.Models.Event();

            // Act

            // Assert
            Assert.That(@event.CreatedAt, Is.Not.EqualTo(DateTime.MinValue));
            Assert.That(@event.CreatedAt, Is.Not.EqualTo(DateTime.MaxValue));
        }

        [Test]
        public void Event_UpdatedAt_ShouldBeInitializedWithCurrentDateTime()
        {
            // Arrange
            var @event = new Volunteer.Models.Event();

            // Act

            // Assert
            Assert.That(@event.UpdatedAt, Is.Not.EqualTo(DateTime.MinValue));
            Assert.That(@event.UpdatedAt, Is.Not.EqualTo(DateTime.MaxValue));
        }

        [Test]
        public void Event_Participants_ShouldAllowAddingParticipants()
        {
            // Arrange
            var @event = new Volunteer.Models.Event();
            var userId = "user123";

            // Act
            @event.Participants.Add(userId);

            // Assert
            Assert.That(@event.Participants.Count, Is.EqualTo(1));
            Assert.Contains(userId, @event.Participants);
        }

        [Test]
        public void Event_Participants_ShouldAllowRemovingParticipants()
        {
            // Arrange
            var @event = new Volunteer.Models.Event();
            var userId = "user123";
            @event.Participants.Add(userId);

            // Act
            @event.Participants.Remove(userId);

            // Assert
            Assert.That(@event.Participants, Is.Empty);
        }

        [Test]
        public void Event_CreatedAt_ShouldBeSetWhenCreated()
        {
            // Arrange
            var createdAt = DateTime.UtcNow;

            // Act
            var @event = new Volunteer.Models.Event();

            // Assert
            Assert.That(@event.CreatedAt, Is.GreaterThanOrEqualTo(createdAt));
            Assert.That(@event.CreatedAt, Is.LessThanOrEqualTo(DateTime.UtcNow));
        }

        [Test]
        public void Event_UpdatedAt_ShouldBeUpdatedWhenModified()
        {
            // Arrange
            var @event = new Volunteer.Models.Event();
            var initialUpdatedAt = @event.UpdatedAt;
            var delay = TimeSpan.FromMilliseconds(10);

            // Act
            // Simulate a delay
            Thread.Sleep(delay);
            @event.Name = "Updated Event Name";

            // Assert
            Assert.That(@event.UpdatedAt, Is.GreaterThan(initialUpdatedAt));
            Assert.That(@event.UpdatedAt - initialUpdatedAt, Is.GreaterThanOrEqualTo(delay));
        }
    }
}