using Proiect.DAL.Entities;
using System;
using Proiect.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Repositories
{
    public class DoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }
        /*public async Task Create(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Doctor doctor)
        {
            _context.Doctors.Remove(donor);
            await _context.SaveChangesAsync();
        }*/
    }
}
