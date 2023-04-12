using System;
using Audit_BusinessLogic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Audit_Service
{
    [Route("api/[controller]")]
    public class AuditController : Controller
    {
        private readonly Audit_BusinessLogic.IAuditLogic logic;
        public AuditController(IAuditLogic _logic)
        {
            logic = _logic;
        }

        // POST api/values
        [HttpPost("AddAudit")]
        public IActionResult Post([FromBody]Audit_Models.Audit_Data audit)
        {
            try
            {
                var a = logic.Add(audit);
                return Ok(a);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);  
            }
        }

    }
}

