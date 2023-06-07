using Givvin.Auth.Models;

namespace Givvin.Auth.Services
{
    /// <summary>
    /// Interface for Google authentication service.
    /// </summary>
    public interface IGoogleAuthService
    {
        /// <summary>
        /// Authenticates the user using the provided access token.
        /// </summary>
        /// <param name="accessToken">The access token obtained from Google.</param>
        /// <returns>The authenticated user's information.</returns>
        Task<GoogleAuthUser> AuthenticateUserAsync(string accessToken);

        /// <summary>
        /// Generates an authorization URL for initiating the Google login flow.
        /// </summary>
        /// <returns>The authorization URL.</returns>
        string GetAuthorizationUrl();
    }
}
