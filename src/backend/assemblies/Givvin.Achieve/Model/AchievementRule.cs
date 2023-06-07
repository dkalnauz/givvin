using MongoDB.Bson;

namespace Givvin.Achieve.Model
{
    /// <summary>
    /// Represents a rule for earning an achievement.
    /// </summary>
    public class AchievementRule
    {
        /// <summary>
        /// Gets or sets the ID of the associated achievement type.
        /// </summary>
        public ObjectId AchievementTypeId { get; set; }

        /// <summary>
        /// Gets or sets the description of the achievement rule.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the requirement count for earning the achievement.
        /// </summary>
        public int Requirement { get; set; }
    }

}
