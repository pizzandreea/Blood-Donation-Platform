using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BloodType { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        //fiecare pacient are un donator
        public int? DonorId { get; set; }

        public virtual Donor Donor { get; set; }

        // fiecare pacient poate lua mai multe medicamente
        public virtual ICollection<PatientMedicine> PatientMedicines { get; set; }
    }
}
