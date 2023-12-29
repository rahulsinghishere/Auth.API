namespace Auth.API.Application.ViewModels
{
    public class AuthTokenVM
    {
        public string Token { get; set; }
        public DateTime ExpirationAt {  get; set; }
    }

    public class AuthenticatedUser
    {
        public string EmailID { get; init; }
        public AuthTokenVM AuthToken { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string MiddleName { get; init; } = string.Empty;
    }
}

