using System.Collections.Generic;

namespace Restaurant.Entities
{
    public class StaffPerson
    {
        public long Id { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public long SalaryId { get; set; }

        public virtual StaffRole Role { get; set; }
        public virtual Salary Salary { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}