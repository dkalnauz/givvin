//using Microsoft.AspNetCore.Mvc;

//namespace Givvin.Auth.Controllers
//{
//    /// <summary>
//    /// Controller for Givvin authentication with Google OpenID.
//    /// </summary>
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthController : ControllerBase
//    {
//        private readonly IGoogleAuthService _googleAuthService;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="AuthController"/> class.
//        /// </summary>
//        /// <param name="googleAuthService">The Google authentication service.</param>
//        public AuthController(IGoogleAuthService googleAuthService)
//        {
//            _googleAuthService = googleAuthService;
//        }

//        /// <summary>
//        /// Performs Google OpenID login.
//        /// </summary>
//        /// <param name="model">The login request model containing the access token.</param>
//        /// <returns>The authentication token if successful, or Unauthorized if authentication fails.</returns>
//        [HttpPost("google-login")]
//        public async Task<IActionResult> GoogleLogin([FromBody] LoginRequestModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var result = await _googleAuthService.AuthenticateAsync(model.AccessToken);

//            if (result.Success)
//            {
//                var token = result.Token;
//                return Ok(new { token });
//            }
//            else
//            {
//                return Unauthorized();
//            }
//        }

//        /// <summary>
//        /// Redirects the user to the Google authentication page.
//        /// </summary>
//        /// <returns>The redirect result.</returns>
//        [HttpGet("google-redirect")]
//        public IActionResult GoogleRedirect()
//        {
//            var redirectUrl = _googleAuthService.GetAuthorizationUrl();
//            return Redirect(redirectUrl);
//        }

//        /// <summary>
//        /// Handles the Google authentication callback.
//        /// </summary>
//        /// <param name="model">The callback request model containing the authorization code.</param>
//        /// <returns>The authentication token if successful, or Unauthorized if authentication fails.</returns>
//        [HttpPost("google-callback")]
//        public async Task<IActionResult> GoogleCallback([FromBody] CallbackRequestModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var result = await _googleAuthService.HandleCallbackAsync(model.Code);

//            if (result.Success)
//            {
//                var token = result.Token;
//                return Ok(new { token });
//            }
//            else
//            {
//                return Unauthorized();
//            }
//        }

//        /// <summary>
//        /// Performs logout for the authenticated user.
//        /// </summary>
//        /// <returns>The logout result.</returns>
//        [HttpPost("logout")]
//        public IActionResult Logout()
//        {
//            _googleAuthService.Logout();
//            return Ok();
//        }
//    }
//}
