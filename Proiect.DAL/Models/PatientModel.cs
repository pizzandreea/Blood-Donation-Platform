using Proiect.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Models
{
    public class PatientModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BloodType { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        //fiecare pacient are un donator
        public int? DonorId { get; set; }


        // fiecare pacient poate lua mai multe medicamente
        public virtual ICollection<PatientMedicine> PatientMedicines { get; set; }
    }
}
