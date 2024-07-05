namespace PowerRaker.Model.Users
{
    public class AuthInfo
    {
        public string? Username {get;set;}
        public string? Token {get;set;}
        public string? RefreshToken {get;set;}
        public string? Source {get;set;}
        public string? Action {get;set;}
    }
}