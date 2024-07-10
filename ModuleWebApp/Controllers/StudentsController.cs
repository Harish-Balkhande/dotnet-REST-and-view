using Microsoft.AspNetCore.Mvc;
using ModuleWebApp.Models;
using ModuleWebApp.Services;

namespace ModuleWebApp.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentServices _studentServices;

        public StudentsController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Retrive all students details 
        [HttpGet]
        public IActionResult GetAllStudents()
        {            
            return View(_studentServices.GetStudents());
        }

        //Add new students in the database
        [HttpGet]
        public IActionResult AddNewStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewStudent(Students stud)
        {
            if (!ModelState.IsValid)
            {
                _studentServices.AddStudents(stud);
                return RedirectToAction("GetAllStudents");
            }
            return View(stud);
        }

        //Update student details
        public IActionResult UpdateStudentDetails()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateStudentDetails(Students model)
        {           
            _studentServices.UpdateStudent(model);
            return RedirectToAction("GetAllStudents");            
        }

        //Delete student from database
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            _studentServices.DeleteStudent(id);
            return RedirectToAction("GetAllStudents");
        }

        //Search student by id
        [HttpPost]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentServices.GetStudentById(id);
            return Json(student);

        }

        //search student by status
        [HttpPost]
        public IActionResult SearchByStatus(string status)
        {
            var student = _studentServices.GetStudentsByStatus(status);
            if (student == null || student.Count == 0)
            {
                return NotFound(); // Return 404 Not Found if no students with the given status are found
            }
            return Json(student);
        }

        


    }
}
