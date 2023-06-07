namespace Givvin.Auth.Models
{
    /// <summary>
    /// Configuration options for Google authentication.
    /// </summary>
    public class GoogleAuthOptions
    {
        /// <summary>
        /// The client ID associated with your Google application.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The client secret associated with your Google application.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// The callback URL where Google will redirect the user after authentication.
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// The redirect URL where the user will be redirected after successful authentication.
        /// </summary>
        public string RedirectUri { get; set; }

        // Other relevant configuration properties for Google authentication

        // Add any additional properties or methods as per your application's requirements
    }
}
