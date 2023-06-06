using MongoDB.Bson;

namespace Givvin.Account.Models
{
    /// <summary>
    /// Represents a role in the application.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// The unique identifier of the role.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// The name of the role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the role.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The permissions associated with the role.
        /// </summary>
        public List<string> Permissions { get; set; }

        /// <summary>
        /// The OpenID providers supported by the role.
        /// </summary>
        public List<string> OpenIdProviders { get; set; }
    }
}
