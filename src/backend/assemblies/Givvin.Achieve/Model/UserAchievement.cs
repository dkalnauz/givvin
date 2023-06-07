using MongoDB.Bson;

namespace Givvin.Achieve.Model
{
    public class UserAchievement
    {
        /// <summary>
        /// The unique identifier of the user achievement.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// The ID of the user who earned the achievement.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The ID of the achievement earned by the user.
        /// </summary>
        public string AchievementId { get; set; }

        /// <summary>
        /// The date and time when the user earned the achievement.
        /// </summary>
        public DateTime DateEarned { get; set; }
    }
}
