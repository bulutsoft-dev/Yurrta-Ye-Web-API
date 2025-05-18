namespace YurttaYe.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; } // Gerçekte hash'lenmeli
        public string Role { get; private set; }

        private User() { } // EF Core için

        public User(string username, string password, string role)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Role = role ?? throw new ArgumentNullException(nameof(role));
        }
    }
}