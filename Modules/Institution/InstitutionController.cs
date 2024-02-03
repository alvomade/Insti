using Insti.Context;
using Insti.Modules.Institution;
using Insti.Modules.Institution.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insti.Modules.Institution
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionController : ControllerBase
    {
        private readonly InstitutionServices _services;
        public InstitutionController(InstitutionServices services) { 
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewInstitution(InstitutionAddDTO addInstitutionDTO)
        {
            try
            {

                await _services.addInstitution(addInstitutionDTO);
                return Ok("Institution added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> FindInstitution([FromRoute] Guid id)
        {
            try
            {
                var theInstitution = await _services.findInstitution(id);
                return Ok(theInstitution);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult> FindAllInstitutions()
        {
            try
            {
                var theInstitutions = await _services.findAllInstitutions();
                return Ok(theInstitutions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteTheInstitution(Guid id)
        {
            try
            {
                await _services.deleteInstitution(id);
                return Ok("Institution deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("search")]
        public IActionResult GetInstitutionByDates([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var InstitutionDTOs = _services.findInstitutionByDate(startDate, endDate);
                return Ok(InstitutionDTOs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> editInstitutionData(Guid id, InstitutionEditDTO newChanges)
        {
            try
            {
                await _services.editInstitution(id, newChanges);
                return Ok("Institution data edited succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


    }
}
