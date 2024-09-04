namespace ToDoAppLocal.Models
{
    public class AuthenticateResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(string username, string token)
        {
            Username = username;
            Token = token;
        }
    }
}
