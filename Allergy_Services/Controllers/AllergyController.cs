using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly Ilogic logic;
        public AllergyController(Ilogic _logic)
        {
            logic   = _logic;
        }
        [HttpGet("GetAllAllergy")]
        public  IActionResult GetAllAllergy([FromHeader] Guid appointmentid)
        {
            try
            {
                var allergyList = logic.GetAllAllergies(appointmentid);
                return Ok(allergyList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddAllergies")]
        public IActionResult PostAllergy(Allergy allergy)
        {
            try
            {
                return Ok(logic.addPatientAllergy(allergy));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
