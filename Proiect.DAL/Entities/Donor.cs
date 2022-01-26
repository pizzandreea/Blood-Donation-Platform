using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Entities
{
    public class Donor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BloodType { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Patient> Patients { get; set;}
        
    }
}
