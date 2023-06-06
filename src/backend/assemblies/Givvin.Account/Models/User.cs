using MongoDB.Bson;
using System.Data;

namespace Givvin.Account.Models
{
    /// <summary>
    /// Represents a user of the application.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The unique identifier of the user.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// The identifier of the login associated with the user.
        /// </summary>
        public ObjectId LoginId { get; set; }

        /// <summary>
        /// The first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The location/address of the user.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The phone number of the user.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// The social network profiles of the user.
        /// Key: Provider name (e.g., Facebook, Google, Apple, BankId)
        /// Value: Profile URL
        /// </summary>
        public Dictionary<string, string> SocialNetworks { get; set; }

        /// <summary>
        /// The user's roles.
        /// </summary>
        public List<Role> Roles { get; set; }

        /// <summary>
        /// The date and time when the user was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The date and time when the user was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                throw new ArgumentException("First name cannot be empty.", nameof(FirstName));
            }

            if (string.IsNullOrWhiteSpace(LastName))
            {
                throw new ArgumentException("Last name cannot be empty.", nameof(LastName));
            }

            if (string.IsNullOrWhiteSpace(Location))
            {
                throw new ArgumentException("Location cannot be empty.", nameof(Location));
            }

            if (string.IsNullOrWhiteSpace(Phone))
            {
                throw new ArgumentException("Phone number cannot be empty.", nameof(Phone));
            }

            if (SocialNetworks == null)
            {
                throw new ArgumentNullException(nameof(SocialNetworks), "Social networks dictionary cannot be null.");
            }

            foreach (var network in SocialNetworks)
            {
                if (string.IsNullOrWhiteSpace(network.Key))
                {
                    throw new ArgumentException("Social network key cannot be empty.", nameof(SocialNetworks));
                }

                if (string.IsNullOrWhiteSpace(network.Value))
                {
                    throw new ArgumentException($"Social network URL cannot be empty for key: {network.Key}.", nameof(SocialNetworks));
                }

                // Perform additional social network URL validation logic
                // ...
            }

            if (Roles == null || Roles.Count == 0)
            {
                throw new ArgumentException("User must have at least one role.", nameof(Roles));
            }

            if (CreatedAt > UpdatedAt)
            {
                throw new ArgumentException("Created date cannot be greater than updated date.", nameof(CreatedAt));
            }
        }
    }
}