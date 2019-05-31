using System.Collections.Generic;

namespace Restaurant.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StaffPerson> Persons { get; set; }
    }
}