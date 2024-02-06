using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CqrsProject.Entities.Dbset
{
    public class Driver : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int DriverNumber { get; set; }

        public Driver()
        {
            Achievements =new HashSet<Achievement>();   
        }
        public virtual ICollection<Achievement>? Achievements { get; set;}
    }
}
