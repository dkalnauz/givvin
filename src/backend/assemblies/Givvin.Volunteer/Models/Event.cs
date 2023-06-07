using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Givvin.Volunteer.Models
{
    /// <summary>
    /// Represents a volunteering event.
    /// </summary>
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        /// <summary>
        /// The unique identifier of the event.
        /// </summary>
        public string Id { get; set; }

        [BsonElement("name")]
        /// <summary>
        /// The name or title of the event.
        /// </summary>
        public string Name { get; set; }

        [BsonElement("description")]
        /// <summary>
        /// A brief description of the event.
        /// </summary>
        public string Description { get; set; }

        [BsonElement("date")]
        /// <summary>
        /// The date and time of the event.
        /// </summary>
        public DateTime Date { get; set; }

        [BsonElement("location")]
        /// <summary>
        /// The location where the event will take place.
        /// </summary>
        public string Location { get; set; }

        [BsonElement("category")]
        /// <summary>
        /// The category or type of the event.
        /// </summary>
        public string Category { get; set; }

        [BsonElement("organizer")]
        /// <summary>
        /// The organizer of the event.
        /// </summary>
        public string Organizer { get; set; }

        [BsonElement("participants")]
        /// <summary>
        /// The list of user IDs representing the participants who have signed up for the event.
        /// </summary>
        public List<string> Participants { get; set; }

        [BsonElement("maxParticipants")]
        /// <summary>
        /// The maximum number of participants allowed for the event.
        /// </summary>
        public int MaxParticipants { get; set; }

        [BsonElement("createdAt")]
        [BsonRepresentation(BsonType.DateTime)]
        /// <summary>
        /// The date and time when the event was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        [BsonRepresentation(BsonType.DateTime)]
        /// <summary>
        /// The date and time when the event was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }

}
