using Givvin.Auth.Models;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace Givvin.Auth.Services
{
    public class GoogleAuthService : IGoogleAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly GoogleAuthOptions _authOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleAuthService"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client used to make requests.</param>
        /// <param name="authOptions">The Google authentication options.</param>
        public GoogleAuthService(HttpClient httpClient, IOptions<GoogleAuthOptions> authOptions)
        {
            _httpClient = httpClient;
            _authOptions = authOptions.Value;
        }

        /// <inheritdoc/>
        public async Task<GoogleAuthUser> AuthenticateUserAsync(string accessToken)
        {
            // Set up the request to the Google userinfo endpoint
            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.googleapis.com/oauth2/v3/userinfo");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // Send the request and retrieve the user data
            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<GoogleAuthUser>(json);

                return user;
            }

            // If the request fails, return null or throw an exception based on your preference
            return null;
        }

        /// <inheritdoc/>
        public string GetAuthorizationUrl()
        {
            var parameters = new Dictionary<string, string>
            {
                ["client_id"] = _authOptions.ClientId,
                ["response_type"] = "code",
                ["redirect_uri"] = _authOptions.RedirectUri,
                ["scope"] = "openid profile email",
                ["state"] = GenerateState()
            };

            var queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value)}"));

            return $"https://accounts.google.com/o/oauth2/v2/auth?{queryString}";
        }

        private string GenerateState()
        {
            // Generate a unique state value to prevent CSRF attacks
            var data = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
            return WebEncoders.Base64UrlEncode(data);
        }
    }
}
