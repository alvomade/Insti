using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insti.Modules.AdminInstitution
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminInstitutionController : ControllerBase
    {
        private readonly AdminInstitutionServices _services;
        public AdminInstitutionController(AdminInstitutionServices services) {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> assignAdminToInstitution([FromQuery]Guid adminId, [FromQuery] Guid institutionId) {
            try { 
                await _services.assignInstitution(adminId, institutionId);
                return Ok("Institution assigned successfully");
            }catch(Exception e) {
                return BadRequest(e.Message); 
            } 
        
        }
    }
}
