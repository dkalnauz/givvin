using MongoDB.Bson.Serialization.Attributes;

namespace Givvin.Volunteer.Models
{
    /// <summary>
    /// Represents a participant registered for an activity.
    /// </summary>
    public class Participant
    {
        /// <summary>
        /// The user ID of the participant.
        /// </summary>
        [BsonElement("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// The status of the participant (e.g., registered, confirmed, etc.).
        /// </summary>
        [BsonElement("status")]
        public string Status { get; set; }
    }
}