using StudentWebApp.Entity;

namespace StudentWebApp.Services
{
    public interface IStudentServices
    {
        List<Students> GetAllStudents();

        bool insert(Students stud);
        bool update(Students stud);
        bool Delete(int id);
        Students SearchById(int id);
        List<Students> SearchByStatus(string status);
    }
}
