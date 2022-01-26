﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Entities
{
    public class Doctor
    {
        int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        int Salary { get; set; }
        public int AddressId { get; set; }

        //one to one
        public virtual Address Address { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        //many to many
        public virtual ICollection<DoctorLab> DoctorLab { get; set; }

        //one to many
        public virtual ICollection<Patient> Patients { get; set; }


    }
}
