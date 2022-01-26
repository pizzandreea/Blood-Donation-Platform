using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Update(T entity);
        Task Create(T entity);
        void Delete(T entity);
    }
}
