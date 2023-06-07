using Givvin.Volunteer.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Givvin.Volunteer.Configuration
{
    public static class ConfigureServices
    {
        public static void ConfigureServiceCollection(this IServiceCollection services, IConfiguration configuration)
        {
            // Other service registrations

            // Register MongoDB settings from configuration
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

            // Register the MongoDB client and database
            services.AddSingleton<IMongoClient>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                return new MongoClient(settings.ConnectionString);
            });

            services.AddScoped(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(settings.DatabaseName);
            });

            // Register the CampaignRepository
            services.AddScoped<ICampaignRepository, CampaignRepository>();

        }
    }
}
