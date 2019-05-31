namespace Restaurant.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Password { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public User()
        {
            RoleId = (int)Enum.Roles.User;
        }

        public virtual Role role { get; set; }
    }
}