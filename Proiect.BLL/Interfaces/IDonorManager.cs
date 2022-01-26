using Proiect.DAL.Entities;
using Proiect.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.BLL.Interfaces
{
    public interface IDonorManager
    {
        Task<List<string>> ModifyDonor();
        Task<List<Donor>> GetAll();

        Task<DonorModel> GetById( int id);
        Task<List<Donor>> WhereCount(int count);
        Task<List<Donor>> OrderByName();

    }
}
