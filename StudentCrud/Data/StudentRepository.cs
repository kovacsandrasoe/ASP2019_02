using StudentCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCrud.Data
{
    public class StudentRepository
    {
        List<Student> students;

        public StudentRepository()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student s)
        {
            students.Add(s);
        }

        public IEnumerable<Student> GetAll()
        {
            return students;
        }

        public void DeleteStudentById(string id)
        {
            students.RemoveAll(t => t.NeptunCode == id);

            //Student actual = students.Where(t => t.NeptunCode == id)
            //    .FirstOrDefault();
            //students.Remove(actual);
        }
    }
}
