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



    }

}
