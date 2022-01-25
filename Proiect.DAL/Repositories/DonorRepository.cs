using Microsoft.EntityFrameworkCore;
using Proiect.DAL.Entities;
using Proiect.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly AppDbContext _context;

        public DonorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Donor donor)
        {
            await _context.Donors.AddAsync(donor);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Donor donor)
        {
            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Donor>> GetAll()
        {
            var donors = await (await GetAllQuery()).ToListAsync();
            return donors;
        }

        public async Task<IQueryable<Donor>> GetAllQuery()
        {
            var query = _context.Donors.AsQueryable();
            return query;
        }

        public async Task<Donor> GetById(int id)
        {
            // dupa primary key
            var donor = await _context.Donors.FindAsync(id);
            return donor;
        }

        public async Task Update(Donor donor)
        {
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync();
        }
    }
}
