using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Repositories
{
    public class MedicineRepository
    {
        private AppDbContext _context;

        public MedicineRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
