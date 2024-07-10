using Microsoft.AspNetCore.Mvc;
using ModuleWebApp.Models;
using ModuleWebApp.Repository;
/*using System.Security.Cryptography.X509Certificates;*/

namespace ModuleWebApp.Services
{
    public class StudentsServices : IStudentServices
    {
        public List<Students> GetStudents()
        {
            using (var context = new StoreContext())
            {
                var students = from p in context.Students select p;
                return students.ToList<Students>();
            }           
        }

        public void AddStudents(Students students)
        {
            using (var context = new StoreContext())
            {
                
                context.Students.Add(students);
                context.SaveChanges();
            }

        }

        public void UpdateStudent(Students student)
        {
            using(var context = new StoreContext())
            {
                var findStudent = context.Students.Find(student.id);
                if (findStudent != null)
                {
                    findStudent.name = student.name;
                    findStudent.email = student.email;
                    findStudent.mobile_no = student.mobile_no;
                    findStudent.address = student.address;                
                    findStudent.status = student.status;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteStudent(int id)
        {
            using(var context = new StoreContext())
            {
                var findStudent = context.Students.Find(id);
                if(findStudent != null)
                {
                    context.Students.Remove(findStudent);
                    context.SaveChanges();
                }
            }
        }

        public Students GetStudentById(int id)
        {
            using( var context = new StoreContext())
            {
                var student = context.Students.Find(id);
                
                return student;
                
                
            }   
        }

        public List<Students> GetStudentsByStatus(string status)
        {
            using (var context = new StoreContext())
            {
                var students = context.Students.Where(s => s.status == status).ToList();

                return students;
            }
        }




    }
}
