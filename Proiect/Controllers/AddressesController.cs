using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect.DAL;
using Proiect.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AddressesController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpPost("AddAddress")]
        public async Task<IActionResult> AddAddress([FromBody] Address address)
        {
            

            if (string.IsNullOrEmpty(address.Phone))
            {
                return BadRequest("Phone is null");
            }

            if (string.IsNullOrEmpty(address.Street))
            {
                return BadRequest("Street is null");
            }

            if (string.IsNullOrEmpty(address.City))
            {
                return BadRequest("City is null");
            }

            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetAddress([FromRoute] int id)
        {
            //var address = await _context.Addresses.FindAsync(id);
            var address = await _context.Addresses.Where(x => x.Id == id).Include(x => x.Donor).FirstOrDefaultAsync();

            return Ok(address);
        }
        
    }
}
