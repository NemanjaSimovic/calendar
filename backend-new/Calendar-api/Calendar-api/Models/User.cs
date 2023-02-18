namespace Calendar_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId  { get; set; }

        public User(int id, string username, string password, string name, string email, int roleId)
        {
            Id = id;
            Username = username;
            Password = password;
            Name = name;
            Email = email;
            RoleId = roleId;
        }
    }
}
