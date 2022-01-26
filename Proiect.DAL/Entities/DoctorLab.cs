using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Entities
{
    public class DoctorLab
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }
        public int LabId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Lab Lab { get; set; }
    }
}
