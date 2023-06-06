using MongoDB.Bson;

/// <summary>
/// Represents the login credentials for a user.
/// </summary>
public class Login
{
    /// <summary>
    /// Gets or sets the unique identifier for the login credentials.
    /// </summary>
    public ObjectId Id { get; set; }

    /// <summary>
    /// Gets or sets the provider name (e.g., Facebook, Google, Apple, BankId).
    /// </summary>
    public string Provider { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier provided by the authentication provider.
    /// </summary>
    public string ProviderId { get; set; }

    /// <summary>
    /// Gets or sets the email address associated with the login credentials.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the URL or file path to the user's photo/avatar.
    /// </summary>
    public string Avatar { get; set; }
}
