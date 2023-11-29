namespace Identity.Models
{
    public class UserLogged
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserToken Token { get; set; }
    }
}
