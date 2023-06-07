using Givvin.Volunteer.Models;

namespace Givvin.Volunteer.Repositories
{
    public interface ICampaignRepository
    {
        /// <summary>
        /// Retrieves a campaign by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the campaign.</param>
        /// <returns>The campaign with the specified identifier, or null if not found.</returns>
        Task<Campaign> GetByIdAsync(string id);

        /// <summary>
        /// Retrieves all campaigns.
        /// </summary>
        /// <returns>A collection of campaigns.</returns>
        Task<IEnumerable<Campaign>> GetAllAsync();

        /// <summary>
        /// Creates a new campaign.
        /// </summary>
        /// <param name="campaign">The campaign to create.</param>
        /// <returns>The created campaign.</returns>
        Task<Campaign> CreateAsync(Campaign campaign);

        /// <summary>
        /// Updates an existing campaign.
        /// </summary>
        /// <param name="id">The unique identifier of the campaign to update.</param>
        /// <param name="campaign">The updated campaign data.</param>
        /// <returns>The updated campaign.</returns>
        Task<Campaign> UpdateAsync(string id, Campaign campaign);

        /// <summary>
        /// Deletes a campaign by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the campaign to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        Task<bool> DeleteAsync(string id);
    }

}
