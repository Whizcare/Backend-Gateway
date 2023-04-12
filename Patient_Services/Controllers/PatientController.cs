using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Patient_Logic;
using System;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientLogic patientlogic;
        public PatientController(IPatientLogic _patientlogic)
        {
            patientlogic = _patientlogic;
        }

        [HttpGet("GetAllPatients")]
        public IActionResult  Get()
        {
            try
            {
                var p = patientlogic.GetPatients();
                if (p != null)
                {
                    return Ok(p);
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("GetAllPatientsById")]
        public IActionResult Get([FromHeader]Guid Id)
        {
            try
            {
                var p = patientlogic.GetPatientById(Id);
                if (p != null)
                {
                    return Ok(p);
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpPost("Register_Patient")]
        public IActionResult RegisterPat([FromBody]Patient patient)
        {
            try
            {
                patient.DateOfBirth = patient.DateOfBirth.AddDays(1);
                var p = patientlogic.AddPatient(patient);
                if (p != null)
                {
                    return Ok(p);
                }
                else
                    return BadRequest("Sorry...Something Went Wrong");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("SignIn_Patient")]
        public IActionResult SignInPatient([FromHeader]string email, [FromHeader] string pass)
        {
            try
            {
                var p = patientlogic.LoginPatient(email, pass);
                if (p != null)
                {
                    return Ok(p);
                }
                else
                    return BadRequest("Sorry Not Found");
            }
            catch(Exception ex)
            {
                 return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("Delete_Patient")]

        public IActionResult Delete([FromHeader]string email)
        {
            try
            {
                var p = patientlogic.DeletePatient(email);
                if (p != null)
                {
                    return Ok(p);
                }
                else
                    return BadRequest("Not Found");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("Update_Patient")]

        public IActionResult Update([FromHeader]string email, [FromBody]Patient patient)
        {
          try
            {
                patient.DateOfBirth = patient.DateOfBirth.AddDays(1);
                patientlogic.UpdatePatient(email, patient);
                return Ok(patient);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }


        [HttpGet("GetPatientsByEmail")]
        public IActionResult getpatientsbyemail([FromHeader]string email)
        {
            try
            {
                var patient=patientlogic.GetPatientByEmail(email);
                if(patient!=null)
                {
                    return Ok(patient);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
