using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFStudentService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStudentsService" in both code and config file together.
    [ServiceContract]
    public interface IStudentsService
    {
        [OperationContract]
        void AddStudents(StudentContract studentcontractor);
        [OperationContract]
        List<StudentContract> GetStudents();
        [OperationContract]
        StudentContract GetStudentByID(int StudentID);
        [OperationContract]
        void UpdateStudent(StudentContract studentcontractor);
        [OperationContract]
        void DeleteStudent(int StudentID);
    }

    [DataContract]
    public class StudentContract
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
    }
}
