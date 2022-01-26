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
    public class DonorManager : IDonorManager
    {
        private readonly IDonorRepository _donorRepo;
        public DonorManager(IDonorRepository donorRepo)
        {
            _donorRepo = donorRepo;
        }
        public async Task<List<string>> ModifyDonor()
        {
            //la o lista de donatori afisam 
            var donors = await _donorRepo.GetAll();
            var list = new List<string>();

            foreach(var donor in donors)
            {
                list.Add($" Donor First Name: {donor.FirstName}," +
                    $"Donor Last Name: {donor.LastName}," +
                    $"Donor Blood Type: {donor.BloodType}," +
                    $"Donor Age: {donor.Age}," +
                    $"Donor Gender: {donor.Gender}");
            }

            return list;
        }
        public async Task<List<Donor>> GetAll()
        {
            var donors = await _donorRepo.GetAll();

            return donors;
        }

        public async Task<DonorModel> GetById(int id)
        {
            var donor = await(_donorRepo.GetById(id));

            return donor;
        }

        public async Task<List<Donor>> WhereCount(int count)
        {
            var donors = await (_donorRepo.WhereCount(count));

            return donors;
        }

        public async Task<List<Donor>> OrderByName()
        {
            var donors = await (_donorRepo.OrderByName());

            return donors;
        }
    }

}
