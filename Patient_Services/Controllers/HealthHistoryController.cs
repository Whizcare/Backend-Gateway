using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Patient_Logic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataEntities.Entities;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.Controllers
{
    [Route("api/[controller]")]
    public class HealthHistoryController : Controller
    {
        private readonly IHealthHistoryLogic healthLogic;
        public HealthHistoryController(IHealthHistoryLogic _healthLogic)
        {
            healthLogic = _healthLogic;
        }
    

        // GET api/values/5
        [HttpGet ("GetHistory")]
        public IActionResult Get([FromHeader]  Guid patientId)
        {
            try
            {
                var x = healthLogic.GetHealthHistory(patientId);
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

        [HttpPost("HealthHistory_Add")]
        public IActionResult Post([FromBody] Models.HealthHistory healthHistory)
        {
            try
            {
                
                var s = healthLogic.AddHealthHistory(healthHistory);
                if (s != null)
                {
                    return Ok(s);
                }
                else
                {
                    return BadRequest("Someting went wrong");
                }
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

