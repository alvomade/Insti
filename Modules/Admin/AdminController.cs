using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Insti.Modules.Admin;
using Insti.Modules.Admin.DTOs;


namespace Insti.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminServices adminServices;

        public AdminController(AdminServices _adminServices) { 
            this.adminServices = _adminServices;
        }

        [HttpPost]
        public async Task<IActionResult> addNewAdmin(AdminAddDTO addAdminDTO)
        {
            try { 

                await adminServices.addAdmin(addAdminDTO);
                return Ok("Admin added successfully");    
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> findAdmin([FromRoute]Guid id) { 
            try { 
                var theAdmin=await adminServices.findAdmin(id);
                return Ok(theAdmin);    
            }catch (Exception ex) {
                return BadRequest(ex.Message);
            }
            
        }

        

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> deleteTheAdmin(Guid id) {
            try { 
             await adminServices.deleteAdmin(id);
                return Ok("admin deleted successfully");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("search")]
        public IActionResult getAdminByDates([FromQuery]DateTime startDate, [FromQuery]DateTime endDate) {
            try
            {
                var adminDTOs = adminServices.findAdminByDate(startDate, endDate);
                return Ok(adminDTOs);   
            }
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> editAdminData(Guid id,string name) {
            try
            {
                await adminServices.editAdmin(id,name);
                return Ok("admin data edited succesfully");
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
            
        }
    }
}
