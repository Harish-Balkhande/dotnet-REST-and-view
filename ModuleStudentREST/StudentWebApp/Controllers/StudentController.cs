using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentWebApp.Entity;
using StudentWebApp.Services;

namespace StudentWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentServices _studentServices;

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        [HttpGet("GetResults")]
        public IActionResult GetResults()
        {
            return Ok(_studentServices.GetAllStudents());
        }

        [HttpPost("AddStudent")]
        public IActionResult AddStudent(Students model)
        {
            var stud = _studentServices.insert(model);
            return Ok(stud);
        }

        [HttpPut("update")]
        public IActionResult update(Students model)
        {
            return Ok(_studentServices.update(model));
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_studentServices.Delete(id));
        }

        [HttpGet("SearchById/{id}")]
        public IActionResult SearchById(int id)
        {
            return Ok(_studentServices.SearchById(id));
        }

        [HttpGet("SearchByStatus/{status}")]
        public IActionResult SearchByStatus(string status)
        {
            return Ok(_studentServices.SearchByStatus(status));
        }


    }
}
