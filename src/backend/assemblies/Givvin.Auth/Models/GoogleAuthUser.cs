namespace Givvin.Auth.Models
{
    /// <summary>
    /// Represents a user authenticated through Google OpenID.
    /// </summary>
    public class GoogleAuthUser
    {
        /// <summary>
        /// Gets or sets the user's unique identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user's full name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the user's profile picture URL.
        /// </summary>
        public string ProfilePictureUrl { get; set; }
    }
}
