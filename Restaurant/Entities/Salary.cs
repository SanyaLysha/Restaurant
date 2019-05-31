using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Entities
{
    public class Salary
    {
        public long Id { get; set; }
        public int Size { get; set; }

        public virtual ICollection<StaffPerson> Person { get; set; }
    }
}