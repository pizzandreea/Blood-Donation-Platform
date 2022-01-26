using Microsoft.EntityFrameworkCore;
using Proiect.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Helpers
{
    public static class PatientExtension
    {
        //extension methods
        public static IQueryable<Patient> IncludeMedicines(this IQueryable<Patient> donors)
        {
            return donors.Include(x => x.PatientMedicines);
        }
        public static IQueryable<Patient> WhereClauses(this IQueryable<Patient> patients, int id)
        {
            return patients
                .IncludeMedicines()
                .Where(x => x.Id == id)
                ;
        }

        public static IQueryable<Patient> OrderByName(this IQueryable<Patient> patients)
        {
            return patients
                .OrderBy(x => x.FirstName);
        }
    }  
}
