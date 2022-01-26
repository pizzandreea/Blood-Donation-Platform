using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect.BLL.Interfaces;
using Proiect.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Patientsv2Controller : ControllerBase
    {

        private readonly IPatientManager _patientManager;

        public Patientsv2Controller(IPatientRepository donorRepo,
             IPatientManager donorManager)
        {
            _patientManager = donorManager;
        }

        [HttpPut("updateAge")] //?id=1
        public async Task<IActionResult> UpdatePatientsAge([FromQuery] int id)
        {
            var patient = await _patientManager.GetById(id);
            patient.Age = patient.Age + 1;

            await _patientManager.Update(patient);

            return Ok(patient.Age);
        }
    }
}
