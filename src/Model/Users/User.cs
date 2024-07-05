namespace PowerRaker.Model.Users
{
    public class UserList
    {
        public List<User>? Users { get; set; }
    }
    public class User
    {
        public string? Username { get; set; }
        public string? Source { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}