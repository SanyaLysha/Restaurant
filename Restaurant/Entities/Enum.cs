namespace Restaurant.Entities
{
    public class Enum
    {
        public enum Roles
        {
            Admin = 1,
            User = 2
        }
        public enum TableStatus
        {
            Free = 1,
            Booked = 2
        }
        public enum StaffRoles
        {
            Waiter = 1,
            Bartender = 2,
            Cook = 3,
            Manager = 4
        }
    }
}