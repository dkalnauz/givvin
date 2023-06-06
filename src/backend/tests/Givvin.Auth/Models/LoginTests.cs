using MongoDB.Bson;
using NUnit.Framework;

[TestFixture]
public class LoginTests
{
    [Test]
    public void Login_Model_Properties_Are_Correctly_Set()
    {
        // Arrange
        var login = new Login
        {
            Id = ObjectId.GenerateNewId(),
            Provider = "Google",
            ProviderId = "google1234567890",
            Email = "johndoe@gmail.com",
            Avatar = "https://example.com/avatar/johndoe.jpg"
        };

        // Assert
        Assert.AreEqual("Google", login.Provider);
        Assert.AreEqual("google1234567890", login.ProviderId);
        Assert.AreEqual("johndoe@gmail.com", login.Email);
        Assert.AreEqual("https://example.com/avatar/johndoe.jpg", login.Avatar);
    }

    [Test]
    public void Login_Model_With_Default_Values_Is_Correct()
    {
        // Arrange
        var login = new Login();

        // Assert
        Assert.IsNull(login.Id);
        Assert.IsNull(login.Provider);
        Assert.IsNull(login.ProviderId);
        Assert.IsNull(login.Email);
        Assert.IsNull(login.Avatar);
    }

    [Test]
    public void Login_Model_Can_Be_Compared_For_Equality()
    {
        // Arrange
        var login1 = new Login
        {
            Id = ObjectId.GenerateNewId(),
            Provider = "Google",
            ProviderId = "google1234567890",
            Email = "johndoe@gmail.com",
            Avatar = "https://example.com/avatar/johndoe.jpg"
        };

        var login2 = new Login
        {
            Id = login1.Id,
            Provider = "Google",
            ProviderId = "google1234567890",
            Email = "johndoe@gmail.com",
            Avatar = "https://example.com/avatar/johndoe.jpg"
        };

        var login3 = new Login
        {
            Id = ObjectId.GenerateNewId(),
            Provider = "Facebook",
            ProviderId = "facebook0987654321",
            Email = "janedoe@gmail.com",
            Avatar = "https://example.com/avatar/janedoe.jpg"
        };

        // Assert
        Assert.AreEqual(login1, login2);
        Assert.AreNotEqual(login1, login3);
    }
}
