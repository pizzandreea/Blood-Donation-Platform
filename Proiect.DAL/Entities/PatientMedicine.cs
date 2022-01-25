using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Entities
{
    public class PatientMedicine
    {
        public int Id { get; set; }

        public int PatientId { get; set; }
        public int MedicineId { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
