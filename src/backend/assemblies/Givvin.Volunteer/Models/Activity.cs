using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Givvin.Volunteer.Models
{

    /// <summary>
    /// Represents a volunteering activity.
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// The unique identifier for the activity.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// The name of the activity.
        /// </summary>
        [BsonElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// The description of the activity.
        /// </summary>
        [BsonElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// The start time of the activity.
        /// </summary>
        [BsonElement("startTime")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// The end time of the activity.
        /// </summary>
        [BsonElement("endTime")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// The location of the activity.
        /// </summary>
        [BsonElement("location")]
        public string Location { get; set; }

        /// <summary>
        /// The maximum number of participants allowed for the activity.
        /// </summary>
        [BsonElement("maxParticipants")]
        public int MaxParticipants { get; set; }

        /// <summary>
        /// The participants registered for the activity.
        /// </summary>
        [BsonElement("participants")]
        public List<Participant> Participants { get; set; }

        /// <summary>
        /// The type of the activity.
        /// </summary>
        [BsonElement("type")]
        public string Type { get; set; }

        /// <summary>
        /// The requirements or criteria associated with the activity.
        /// </summary>
        [BsonElement("requirements")]
        public List<Requirement> Requirements { get; set; }

        public bool IsMaxParticipantsReached() => MaxParticipants == Participants.Count;
    }
}