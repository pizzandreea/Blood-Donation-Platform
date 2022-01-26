using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Entities
{
    public class Lab
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<DoctorLab> DoctorLabs { get; set; }

    }
}
