using Microsoft.AspNetCore.Mvc;
using Proiect.BLL.Interfaces;
using Proiect.DAL.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Donorsv2Controller : ControllerBase
    {
        private readonly IDonorManager _donorManager;

        public Donorsv2Controller(IDonorRepository donorRepo,
            IDonorManager donorManager)
        {
            _donorManager = donorManager;
        }

        [HttpGet("get-select/{id}")]
        public async Task<IActionResult> GetDonorPatientsSelect([FromRoute] int id)
        {

            // select Id, first_name, last_name from patients
            //where donorid = id
            // transformam sql query intr o lista
            var donor = await _donorManager.GetById(id);
            //var donor = donors.GetById(id);
            if (donor == null)
            {
                return NotFound();
            }
            var donorPatients = donor.Patients.Select(p => new { FirstName = p.FirstName, BloodType = p.BloodType, Age = p.Age }).ToList();

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
            var donorsCount = await _donorManager
                .WhereCount(1);

            if (donorsCount == null)
            {
                return NotFound();
            }


            return Ok(donorsCount);
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
            var donor = await _donorManager
                .OrderByName();


            return Ok(donor);
        }

        [HttpGet("get-modify")]
        public async Task<IActionResult> GetModify()
        {
            var list = await _donorManager.ModifyDonor();
            return Ok(list);
        }


    }

}
