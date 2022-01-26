using Microsoft.EntityFrameworkCore;
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
    public class DonorRepository : IDonorRepository
    {
        private readonly AppDbContext _context;

        public DonorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Donor donor)
        {
            await _context.Donors.AddAsync(donor);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Donor donor)
        {
            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Donor>> GetAll()
        {
            
            var donors = _context.Donors.IncludePatients();
            var list = new List<Donor>();
            foreach(var donor in donors)
            {
                var donorModel = new Donor
                {
                    Id = donor.Id,
                    FirstName = donor.FirstName,
                    LastName = donor.LastName,
                    Age = donor.Age,
                    BloodType = donor.BloodType,
                    Gender = donor.Gender,
                    Patients = donor.Patients
                };
                list.Add(donorModel);
            }
            return list;
        }

        

        public async Task<IQueryable<Donor>> GetAllQuery()
        {
            var query = _context.Donors.AsQueryable();
            return query;
        }

        public async Task<DonorModel> GetById(int id)
        {
            // dupa primary key
            var donors = _context.Donors.WhereClauses(id);
            var donorModel = new DonorModel();

            foreach (var donor in donors)
            {
                donorModel.FirstName = donor.FirstName;
                donorModel.LastName = donor.LastName;
                donorModel.Age = donor.Age;
                donorModel.BloodType = donor.BloodType;
                donorModel.Gender = donor.Gender;
                donorModel.Patients = donor.Patients;
                
            }
            return donorModel;
        }

        public async Task<List<Donor>> WhereCount(int count)
        {
            var donors = _context.Donors.IncludePatients().WhereCount(count);
            var list = new List<Donor>();
            foreach (var donor in donors)
            {
                var donorModel = new Donor
                {
                    Id = donor.Id,
                    FirstName = donor.FirstName,
                    LastName = donor.LastName,
                    Age = donor.Age,
                    BloodType = donor.BloodType,
                    Gender = donor.Gender,
                    Patients = donor.Patients
                };
                list.Add(donorModel);
            }
            return list;
        }

        public async Task<List<Donor>> OrderByName()
        {
            var donors = _context.Donors.IncludePatients().OrderByName();
            var list = new List<Donor>();
            foreach (var donor in donors)
            {
                var donorModel = new Donor
                {
                    Id = donor.Id,
                    FirstName = donor.FirstName,
                    LastName = donor.LastName,
                    Age = donor.Age,
                    BloodType = donor.BloodType,
                    Gender = donor.Gender,
                    Patients = donor.Patients
                };
                list.Add(donorModel);
            }
            return list;
        }

        public async Task Update(Donor donor)
        {
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync();
        }
    }
}
