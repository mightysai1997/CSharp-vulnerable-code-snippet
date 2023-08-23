public class UserController
{
    public void Login(string username, string password)
    {
        // This code sends the password over HTTPS, which is a secure protocol.
        // An attacker cannot intercept the password.
        var client = new HttpsClient();
        var request = new HttpRequest("https://example.com/api/login");
        request.SetParameter("username", username);
        request.SetParameter("password", password);
        client.SendAsync(request).Wait();
    }
}
