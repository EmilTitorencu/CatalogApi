using CatalogApi.Dtos;
using CatalogApi.Utils;
using Data.AccessLayer;
using Data.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IAccessLayer dataAccessLayerService;
        public NoteController(IAccessLayer dataAccessLayerService)
        {
            this.dataAccessLayerService = dataAccessLayerService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nota"></param>
        [HttpPost]
        public IActionResult AddNota([FromBody] NotaToCreateDto nota)
        {
            try
            {
                dataAccessLayerService.AcordaNota(nota.Valoare, nota.StudentId, nota.CursId);
                return Ok();
            }
            catch (InvalidIdException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Gets all student's marks
        /// </summary>
        /// <param name="studentId"></param>
        [HttpGet("student/{studentId}")]
        public IActionResult GetStudentNote([FromRoute] int studentId)
        {
            try
            {
                var note = dataAccessLayerService.GetStudentNote(studentId);
                return Ok(note.Select(s => s.ToDto()).ToList());
            }
            catch (InvalidIdException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Gets student's marks for a course
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="cursId"></param>
        [HttpGet("student/{studentId}/curs/{cursId}")]
        public IActionResult GetStudentCursNote([FromRoute] int studentId, [FromRoute] int cursId)
        {
            try
            {
                var note = dataAccessLayerService.GetStudentCursNote(studentId, cursId);
                return Ok(note.Select(s => s.ToDto()).ToList());
            }
            catch (InvalidIdException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Gets student's averages for courses
        /// </summary>
        /// <param name="studentId"></param>
        [HttpGet("student/{studentId}/medii")]
        public IActionResult GetStudentCursuriMedii([FromRoute] int studentId)
        {
            try
            {
                var note = dataAccessLayerService.GetStudentCursuriMedii(studentId);
                return Ok(note.Select(s => s.ToDto()).ToList());
            }
            catch (InvalidIdException e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Gets students averages
        /// </summary>
        [HttpGet("medii")]
        public IActionResult GetStudentMedii()
        {
            try
            {
                var note = dataAccessLayerService.GetStudentMedii();
                return Ok(note.Select(s => s.ToDto()).ToList()); // 
            }
            catch (InvalidIdException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
