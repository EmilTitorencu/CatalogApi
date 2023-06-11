using Microsoft.AspNetCore.Mvc;
using Data.AccessLayer;
using CatalogApi.Dtos;
using CatalogApi.Utils;
using Data.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace CatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentiController : ControllerBase
    {
        private readonly IAccessLayer dal;
        public StudentiController(IAccessLayer dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Returns all the students in the db
        /// </summary>
        [HttpGet]
        public IEnumerable<StudentToGetDto> GetAllStudents()
        {
            var allStudents = dal.GetAllStudents();

            return allStudents.Select(s => s.ToDto()).ToList();
        }

        /// <summary>
        /// Creates a student
        /// </summary>
        /// <param name="studentToCreate">student to create data</param>
        /// <returns>created student data</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public StudentToGetDto CreateStudent([FromBody] StudentToCreateDto studentToCreate) =>
            dal.CreateStudent(studentToCreate.ToEntity()).ToDto();

        /// <summary>
        /// Update the student's address
        /// </summary>
        /// <param name="id"></param>
        /// <param name="addressToUpdate"></param>
        [HttpPut("{id}/adresa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult UpdateStudentAddress([FromRoute] int id, [FromBody] AddressToUpdateDto addressToUpdate)
        {

            if (dal.UpdateOrCreateStudentAddress(id, addressToUpdate.ToEntity()))
            {
                return Created("success", null);
            }
            return Ok();
        }

        /// <summary>
        /// Get the student's address
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}/adresa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetStudentAddress([FromRoute] int id)
        {
            try
            {
                return Ok(dal.GetAdresaByStudentId(id));
            }
            catch (InvalidIdException e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Gets a student by id
        /// </summary>
        /// <param name="id">id of the student</param>
        /// <returns>student data</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentToGetDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]

        public ActionResult<StudentToGetDto> GetStudentById([Range(1, int.MaxValue)] int id)
        {
            try
            {
                return Ok(dal.GetStudentById(id).ToDto());
            }
            catch (InvalidIdException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Updates a student
        /// </summary>
        /// <param name="studentToUpdate"></param>
        /// <returns></returns>
        [HttpPatch]
        public StudentToGetDto UpdateStudent([FromBody] StudentToUpdateDto studentToUpdate) =>
            dal.UpdateStudent(studentToUpdate.ToEntity()).ToDto();


        /// <summary>
        /// Deletes a student
        /// </summary>
        /// <param name="id">id of the student</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            if (id == 0)
            {
                return BadRequest("id cannot be 0");
            }
            try
            {
                dal.DeleteStudent(id);
            }
            catch (InvalidIdException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }

    }
}
