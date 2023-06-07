using Givvin.Volunteer.Models;
using System.ComponentModel.DataAnnotations;

namespace Givvin.Volunteer.ApiModels
{
    /// <summary>
    /// Represents a fundraising campaign within the platform.
    /// </summary>
    public class CampaignUpdateApiModel
    {
        /// <summary>
        /// The unique identifier for the campaign.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The title or name of the campaign.
        /// </summary>
        [Required(ErrorMessage = "The title is required.")]
        [StringLength(100, ErrorMessage = "The title must be at most 100 characters long.")]
        public string Title { get; set; }

        /// <summary>
        /// The description or details about the campaign.
        /// </summary>
        [StringLength(500, ErrorMessage = "The description must be at most 500 characters long.")]
        public string Description { get; set; }

        /// <summary>
        /// The start date of the campaign.
        /// </summary>
        [Required(ErrorMessage = "The start date is required.")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The goal amount to be raised in the campaign.
        /// </summary>
        [Required(ErrorMessage = "The goal amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The goal amount must be a positive number.")]
        public decimal GoalAmount { get; set; }

        /// <summary>
        /// The user who created the campaign.
        /// </summary>
        [Required(ErrorMessage = "The creator is required.")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Indicates whether the campaign is active or not.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Maps the <see cref="CampaignPostApiModel"/> to a <see cref="Campaign"/> entity.
        /// </summary>
        /// <returns>The <see cref="Campaign"/> entity.</returns>
        public Campaign ToEntity()
        {
            return new Campaign
            {
                Title = Title,
                Description = Description,
                StartDate = StartDate,
                GoalAmount = GoalAmount,
                CreatedBy = CreatedBy
            };
        }
    }
}
