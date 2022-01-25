using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Donorsv2Controller : ControllerBase
    {
        private readonly IDonorRepository _donorRepo;

        public Donorsv2Controller(IDonorRepository donorRepo)
        {
            _donorRepo = donorRepo;
        }

        [HttpGet("get-select/{id}")]
        public async Task<IActionResult> GetDonorPatientsSelect([FromRoute] int id)
        {
            // select Id, first_name, last_name from patients
            //where donorid = id
            // transformam sql query intr o lista
            var donors = await _donorRepo.GetAll();
            var donor = donors.FirstOrDefault(d => d.Id == id);
            /*if (donor == null)
            {
                return NotFound();
            }*/
            var donorPatients = donor.Patients.Select(p => new { FirstName = p.FirstName, BloodType = p.BloodType, Age = p.Age}).ToList();

            return Ok(donorPatients);
        }


    }

}
