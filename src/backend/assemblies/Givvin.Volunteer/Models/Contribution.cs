using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Givvin.Volunteer.Models
{
    /// <summary>
    /// Represents a contribution made to a fundraising campaign.
    /// </summary>
    public class Contribution
    {
        /// <summary>
        /// The unique identifier for the contribution.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// The id of the campaign to which the contribution is made.
        /// </summary>
        public string CampaignId { get; set; }

        /// <summary>
        /// The id of the user who made the contribution. (Nullable)
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The amount contributed by the user.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The date and time of the contribution.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Indicates whether the contribution is made anonymously.
        /// </summary>
        public bool IsAnonymous { get; set; }
    }
}
