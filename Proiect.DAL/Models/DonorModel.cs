using Proiect.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Models
{
    public class DonorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BloodType { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
