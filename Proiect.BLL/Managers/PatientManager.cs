using Proiect.BLL.Interfaces;
using Proiect.DAL.Entities;
using Proiect.DAL.Interfaces;
using Proiect.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.BLL.Managers
{
    public class PatientManager : IPatientManager
    {
        private readonly IPatientRepository _patientRepo;
        public PatientManager(IPatientRepository patientRepo)
        {
            _patientRepo = patientRepo;
        }
        public async Task<List<string>> ModifyPatient()
        {
            //la o lista de donatori afisam 
            var patients = await _patientRepo.GetAll();
            var list = new List<string>();

            foreach (var patient in patients)
            {
                list.Add($" Patient First Name: {patient.FirstName}," +
                    $"Patient Last Name: {patient.LastName}," +
                    $"Patient Blood Type: {patient.BloodType}," +
                    $"Patient Age: {patient.Age}," +
                    $"Patient Gender: {patient.Gender}");
            }

            return list;
        }
        public async Task<List<Patient>> GetAll()
        {
            var patients = await _patientRepo.GetAll();

            return patients;
        }

        public async Task<PatientModel> GetById(int id)
        {
            var patient = await (_patientRepo.GetById(id));

            return patient;
        }

        public async Task Create(Patient patient)
        {
            await _patientRepo.Create(patient);
        }

        public async Task Update(Patient patient)
        {
            await _patientRepo.Update(patient);
        }

        public async Task Update(PatientModel patient)
        {
            var newpatient = new Patient
            {
                Id = 0,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Age = patient.Age,
                BloodType = patient.BloodType,
                Gender = patient.Gender,
                PatientMedicines = patient.PatientMedicines
            };
            await _patientRepo.Update(newpatient);
        }
    }
}
