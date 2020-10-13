using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        //// GET api/values // For Testing
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpPost("", Name = "createSchool")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult CreateSchool([FromBody] SchoolDTO schoolDTO)
        {
            try
            {

                var newSchool = _schoolService.CreateSchool(schoolDTO);
                return CreatedAtAction(nameof(CreateSchool), schoolDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("", Name = "updateSchool")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult UpdateSchool([FromBody] SchoolDTO schoolDTO)
        {
            try
            {

                var newSchool = _schoolService.UpdateSchool(schoolDTO);
                return CreatedAtAction(nameof(UpdateSchool), schoolDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("", Name = "getSchool")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult ReadSchool([FromQuery] Guid id)
        {
            try
            {

                var school = _schoolService.ReadSchool(id);
                return Ok(school);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPatch("", Name = "deleteSchool")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult DeleteSchool([FromQuery] Guid id)
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
