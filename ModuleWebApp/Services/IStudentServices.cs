using ModuleWebApp.Models;

namespace ModuleWebApp.Services
{
    public interface IStudentServices
    {
        List<Students> GetStudents();
        void AddStudents (Students students);
        void UpdateStudent(Students student);
        void DeleteStudent(int id);
        Students GetStudentById(int id);
        List<Students> GetStudentsByStatus(string status);
    }
}
