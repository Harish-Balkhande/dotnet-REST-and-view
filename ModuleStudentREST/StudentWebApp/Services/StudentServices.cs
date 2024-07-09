using Microsoft.AspNetCore.Mvc;
using StudentWebApp.Entity;
using StudentWebApp.Repository;

namespace StudentWebApp.Services
{
    public class StudentServices : IStudentServices
    {
        public List<Students> GetAllStudents()
        {
            using(var context = new StoreContext())
            {
                var students = from p in context.studContext select p;
                return students.ToList<Students>();
            }
        }

        public bool insert(Students stud)
        {
            using( var context = new StoreContext())
            {
                context.studContext.Add(stud);
                context.SaveChanges();
            }
            return true;
        }

        
        public bool update(Students stud)
        {
            using(var context = new StoreContext())
            {
                var student = context.studContext.Find(stud.id);
                if (student != null)
                {                    
                    student.name = stud.name;
                    student.email = stud.email;
                    student.address = stud.address;
                    student.fees = stud.fees;
                    student.mobile_no = stud.mobile_no;
                    student.status = stud.status;
                    context.studContext.Update(student);
                    context.SaveChanges();
                }
            }
            return true;
        }

       
        public bool Delete(int id)
        {
            using(var context = new StoreContext())
            {
                var find = context.studContext.Find(id);
                if (find != null)
                {
                    context.studContext.Remove(find);
                    context.SaveChanges();
                }
            }
            return true;    
        }

        public Students SearchById(int id)
        {
            using (var contaxt = new StoreContext())
            {
                var find = contaxt.studContext.Find(id);
                return find;
             }
        }

        public List<Students> SearchByStatus(string status)
        {
            using ( var contaxt = new StoreContext())
            {
                var find = contaxt.studContext.Where(e => e.status == status);
                return find.ToList<Students>();
            }
        }

    }
}
