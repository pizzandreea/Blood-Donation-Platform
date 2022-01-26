using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PatientsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPut("updateAge")] //?id=1
        [Authorize(Roles = ("Admin,Doctor"))]
        public async Task<IActionResult> UpdatePatientsAge([FromQuery] int id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
            patient.Age = patient.Age + 1;

            await _context.SaveChangesAsync();

            return Ok(patient.Age);
        }

    }
}
