namespace Givvin.Volunteer.ApiModels
{
    /// <summary>
    /// Represents a fundraising campaign within the platform.
    /// </summary>
    public class CampaignGetApiModel
    {
        /// <summary>
        /// The unique identifier for the campaign.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The title or name of the campaign.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The description or details about the campaign.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The start date of the campaign.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The end date of the campaign.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// The target amount to be raised in the campaign.
        /// </summary>
        public decimal GoalAmount { get; set; }

        /// <summary>
        /// The current amount raised in the campaign.
        /// </summary>
        public decimal CurrentAmount { get; set; }

        /// <summary>
        /// The user who created the campaign.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// The list of contributors to the campaign.
        /// </summary>
        public List<string> Contributors { get; set; }

        /// <summary>
        /// Indicates whether the campaign is active or not.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
