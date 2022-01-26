using Proiect.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace Proiect.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        virtual public async Task Create(T entity)
        {
        }
        virtual public async Task Delete(T entity)
        {
        }
        virtual public async Task Update(T entity)
        {
        }

    }
}
