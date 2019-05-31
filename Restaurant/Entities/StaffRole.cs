using System.Collections.Generic;

namespace Restaurant.Entities
{
    public class StaffRole
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StaffPerson> Person { get; set; }
    }
}