using Microsoft.EntityFrameworkCore;
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

        virtual public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        virtual public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        virtual public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        virtual public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

    }
}
