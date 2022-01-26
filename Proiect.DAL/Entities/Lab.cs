using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Entities
{
    public class Lab
    {
        int Id { get; set; }
        string Type { get; set; }

        public virtual ICollection<DoctorLab> DoctorLab { get; set; }

    }
}
