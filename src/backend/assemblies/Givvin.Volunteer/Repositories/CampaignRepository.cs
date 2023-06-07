using Givvin.Volunteer.Models;
using MongoDB.Driver;

namespace Givvin.Volunteer.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly IMongoCollection<Campaign> _campaignsCollection;

        public CampaignRepository(IMongoDatabase database)
        {
            _campaignsCollection = database.GetCollection<Campaign>("campaigns");
        }

        /// <inheritdoc />
        public async Task<Campaign> GetByIdAsync(string id)
        {
            var filter = Builders<Campaign>.Filter.Eq(c => c.Id, id);
            return await _campaignsCollection.Find(filter).FirstOrDefaultAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Campaign>> GetAllAsync()
        {
            return await _campaignsCollection.Find(_ => true).ToListAsync();
        }

        /// <inheritdoc />
        public async Task<Campaign> CreateAsync(Campaign campaign)
        {
            await _campaignsCollection.InsertOneAsync(campaign);
            return campaign;
        }

        /// <inheritdoc />
        public async Task<Campaign> UpdateAsync(string id, Campaign campaign)
        {
            var filter = Builders<Campaign>.Filter.Eq(c => c.Id, id);
            var options = new ReplaceOptions { IsUpsert = true };
            await _campaignsCollection.ReplaceOneAsync(filter, campaign, options);
            return campaign;
        }

        /// <inheritdoc />
        public async Task<bool> DeleteAsync(string id)
        {
            var filter = Builders<Campaign>.Filter.Eq(c => c.Id, id);
            var result = await _campaignsCollection.DeleteOneAsync(filter);
            return result.DeletedCount > 0;
        }
    }
}
