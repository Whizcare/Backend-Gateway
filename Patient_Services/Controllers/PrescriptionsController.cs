using System;
using System.Collections.Generic;
using System.Linq;
using Patient_Logic;
using Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.Controllers
{
    [Route("api/[controller]")]
    public class PrescriptionsController : Controller
    {

        private readonly IPresciptionLogic presciption;
        public PrescriptionsController(IPresciptionLogic _prescription)
        {
            presciption = _prescription;
        }

        // GET api/values/5
        [HttpGet("Get_Prescription")]
        public IActionResult Get([FromHeader] Guid HHID)
        {
            try
            {
                var x = presciption.GetPrescriptions(HHID);
                if (x != null)
                {
                    return Ok(x);
                }
                else
                {
                    return BadRequest("Something");
                }
            }
          
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/values
        [HttpPost("Prescription_Add")]
        public IActionResult Post([FromBody] Prescriptions prescriptions)
        {
            try {
                var p = presciption.AddPrescriptions(prescriptions);
                if (p != null) return Ok(p);
                else return BadRequest("Something");

            }
           
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

