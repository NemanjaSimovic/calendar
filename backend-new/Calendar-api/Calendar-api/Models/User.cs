namespace Calendar_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int roleId  { get; set; }
        public User() { }
        public User(string username, string password, string name, int roleId)
        {
            Username = username;
            Password = password;
            Name = name;
            this.roleId = roleId;
        }
    }
}
