using Proiect.DAL.Entities;
using Proiect.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Repositories
{
    public class MedicineRepository : Repository<Medicine>, IMedicineRepository 
    {
        private AppDbContext _context;

        public MedicineRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
