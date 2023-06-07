using MongoDB.Bson;

namespace Givvin.Achieve.Model
{
    /// <summary>
    /// Represents an achievement type.
    /// </summary>
    public class AchievementType
    {
        /// <summary>
        /// Gets or sets the unique identifier of the achievement type.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the achievement type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the achievement type.
        /// </summary>
        public string Description { get; set; }
    }
}
