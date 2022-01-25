using Proiect.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Interfaces
{
    public interface IDonorRepository
    {
        Task<List<Donor>> GetAll();
        Task<Donor> GetById(int id);
        Task Create(Donor donor);
        Task Update(Donor donor);
        Task Delete(Donor donor);
        Task<IQueryable<Donor>> GetAllQuery();

    }
}
