using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFStudentService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StudentsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StudentsService.svc or StudentsService.svc.cs at the Solution Explorer and start debugging.
    public class StudentsService : IStudentsService
    {
        public void AddStudents(StudentContract studentcontractor)
        {
            StudentDBEntities1 db= new StudentDBEntities1 ();   
            db.Students.Add(new Student {Id=db.Students.Count()+1, Name = studentcontractor.Name, Age=studentcontractor.Age });
            db.SaveChanges();
        
        }

        public List<StudentContract> GetStudents()
        {
            StudentDBEntities1  db= new StudentDBEntities1 ();
            return db.Students.Select(s=> new StudentContract { Id=s.Id, Name=s.Name, Age=s.Age }).ToList();
        }

        public StudentContract GetStudentByID(int StudentID)
        {
            StudentDBEntities1 db = new StudentDBEntities1 ();
            var matchedStudent = db.Students.FirstOrDefault(s=>s.Id==StudentID);
            if(matchedStudent != null)
            {
                return new StudentContract
                {
                    Id = matchedStudent.Id,
                    Name = matchedStudent.Name,
                    Age = matchedStudent.Age
                };
            }
            return null;
        }

        public void UpdateStudent(StudentContract studentcontractor)
        {
            StudentDBEntities1 db = new StudentDBEntities1();
            try
            {
                var existingStudent = db.Students.Where(s => s.Id == studentcontractor.Id).FirstOrDefault();
                if (existingStudent != null)
                {
                    existingStudent.Name = studentcontractor.Name;
                    existingStudent.Age = studentcontractor.Age;
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteStudent(int StudentID)
        {
            StudentDBEntities1 db = new StudentDBEntities1();
            var matchStudent= db.Students.FirstOrDefault(s=>s.Id == StudentID);
            if(matchStudent != null)
            {
                db.Students.Remove(matchStudent);
                db.SaveChanges();
            }
        }
    }
}
