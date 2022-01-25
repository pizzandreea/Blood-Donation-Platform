using Microsoft.AspNetCore.Mvc;
using Proiect.DAL;
using Proiect.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect.DAL.Interfaces;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DonorsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("get-select/{id}")]
        public async Task<IActionResult> GetDonorPatientsSelect([FromRoute] int id)
        {
            // select Id, first_name, last_name from patients
            //where donorid = id
            // transformam sql query intr o lista
            var donorPatients = await _context.Patients.Where(x => x.DonorId == id).Select(x => new { Id = x.Id, FirstNamePatient = x.FirstName, LastNamePatient = x.LastName }).ToListAsync();

            return Ok(donorPatients);
        }

        [HttpGet("get-join")]
        public async Task<IActionResult> GetDonorPatientsJoin()
        {
            // select *
            // from Donors d 
            // left join Patients 
            // where (select count(*)
            //        from patients p
            //        where d.id = p.DonorId >= 1
            // transformam sql query intr o lista
            var donor = await _context.Donors
                .Include(x => x.Patients)
                .Where(x => x.Patients.Count() >= 1)
                .ToListAsync();
                

            return Ok(donor);
        }

        [HttpGet("get-orderby")]
        public async Task<IActionResult> GetDonorPatientsOrdered()
        {
            // select *
            // from Donors d 
            // left join Patients 
            // where (select count(*)
            //        from patients p
            //        where d.id = p.DonorId >= 1
            // order by firstname
            // transformam sql query intr o lista
            var donor = await _context.Donors
                .Include(x => x.Patients)
                .Where(x => x.Patients.Count() >= 1)
                .OrderBy( x => x.FirstName)
                .ToListAsync();


            return Ok(donor);
        }

        //the average age of the patients of a donor and how many of them are
        [HttpGet("get-groupby")]
        public async Task<IActionResult> GetDonorPatientsAge()
        {

            //group by average

            var patientAge = _context.Patients.GroupBy(x => x.DonorId).Select(x => new
            {
                Key = x.Key,
                AverageAge = x.Average(x => x.Age),
                Count = x.Count()
            }).ToList();

            return Ok(patientAge);
        }




        /* [HttpPut("updatePassword")] //?id=1
         public async Task<IActionResult> UpdatePatientsAge([FromQuery] int id, [FromQuery] string newpassword)
         {
             var donor = await _donorRepository.Donors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
             donor.password = newpassword;

             _donorRepository.Donors.Attach(donor);
             //sau
             _donorRepository.Entry(donor).State = EntityState.Modified;

             await _donorRepository.SaveChangesAsync();

             var donor2 = await _donorRepository.Donors.FirstOrDefaultAsync(x => x.Id == id);

             return Ok();
         }
        */
    }
}
