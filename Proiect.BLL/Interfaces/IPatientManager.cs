using Proiect.DAL.Entities;
using Proiect.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.BLL.Interfaces
{
    public interface IPatientManager 
    {
        Task<List<string>> ModifyPatient();
        Task<List<Patient>> GetAll();

        Task<PatientModel> GetById(int id);
        Task Create(Patient patient);
        Task Update(Patient patient);
        Task Update(PatientModel patient);


    }
}
