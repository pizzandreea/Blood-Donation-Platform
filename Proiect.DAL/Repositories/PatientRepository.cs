using Proiect.DAL.Entities;
using Proiect.DAL.Helpers;
using Proiect.DAL.Interfaces;
using Proiect.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }
        public  async Task Create(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Patient patient)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Patient>> GetAll()
        {

            var patients = _context.Patients.IncludeMedicines();
            var list = new List<Patient>();
            foreach (var patient in patients)
            {
                var patientModel = new Patient
                {
                    Id = patient.Id,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Age = patient.Age,
                    BloodType = patient.BloodType,
                    Gender = patient.Gender,
                    PatientMedicines = patient.PatientMedicines
                };
                list.Add(patientModel);
            }
            return list;
        }



        public async Task<IQueryable<Patient>> GetAllQuery()
        {
            var query = _context.Patients.AsQueryable();
            return query;
        }

        public async Task<PatientModel> GetById(int id)
        {
            // dupa primary key
            var patients = _context.Patients.WhereClauses(id);
            var patientModel = new PatientModel();

            foreach (var patient in patients)
            {
                patientModel.FirstName = patient.FirstName;
                patientModel.LastName = patient.LastName;
                patientModel.Age = patient.Age;
                patientModel.BloodType = patient.BloodType;
                patientModel.Gender = patient.Gender;
                patientModel.PatientMedicines = patient.PatientMedicines;

            }
            return patientModel;
        }

        public async Task Update(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }


    }
}
