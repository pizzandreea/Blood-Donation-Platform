using Proiect.DAL.Entities;
using Proiect.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Interfaces
{
    public interface IPatientRepository 
    {
        Task<List<Patient>> GetAll();
        Task<PatientModel> GetById(int id);

        Task Create(Patient patient);
        Task Update(Patient patient);
        Task Delete(Patient patient);

        Task<IQueryable<Patient>> GetAllQuery();
    }
}
