using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService ?? throw new ArgumentNullException(nameof(schoolService));
        }

        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateSchool([FromBody] SchoolDTO schoolDTO)
        {
            try
            {
              
                var newSchool = _schoolService.CreateSchool(schoolDTO);
                return CreatedAtAction(nameof(CreateSchool), newSchool);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [Route("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateSchool([FromBody] SchoolDTO schoolDTO)
        {
            try
            {

                var newSchool = _schoolService.UpdateSchool(schoolDTO);
                return CreatedAtAction(nameof(UpdateSchool), newSchool);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [Route("read")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ReadSchool([FromBody] Guid schoolId)
        {
            try
            {
                var school = _schoolService.ReadSchool(schoolId);
                return Ok(school);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [Route("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteSchool([FromBody] Guid id)
        {
            try
            {
                _schoolService.DeleteSchool(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
