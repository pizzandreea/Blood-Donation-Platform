using Microsoft.EntityFrameworkCore;
using Proiect.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Helpers
{
    public static class DonorExtension
    {
        //extension methods
        public static IQueryable<Donor> IncludePatients(this IQueryable<Donor> donors)
        {
            return donors.Include(x => x.Patients);
        }
        public static IQueryable<Donor> WhereClauses(this IQueryable<Donor> donors, int id)
        {
            return donors
                .IncludePatients()
                .Where(x => x.Id == id)
                ;
        }

        public static IQueryable<Donor> WhereCount(this IQueryable<Donor> donors, int count)
        {
            return donors
                .IncludePatients()
                .Where(x => x.Patients.Count() >= count)
                ;
        }

        public static IQueryable<Donor> OrderByName(this IQueryable<Donor> donors)
        {
            return donors
                .IncludePatients()
                .OrderBy(x => x.FirstName)
                ;
        }
    }

}
