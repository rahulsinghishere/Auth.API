namespace Auth.API.Application.ViewModels
{
    public class AuthTokenVM
    {
        public string Token { get; set; }
        public DateTime ExpirationAt {  get; set; }
    }
}

