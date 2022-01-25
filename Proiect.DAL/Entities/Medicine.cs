using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Entities
{
    public class Medicine
    {
        public int Id {get; set;}

        public int Name { get; set; }

        //fiecare medicament poate fi luat de mai multi pacienti
        public virtual ICollection<PatientMedicine> PatientMedicines { get; set; } 

    }
}
