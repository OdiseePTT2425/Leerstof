using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithDatabase
{
    internal class StudentRepository : IStudentRepository
    {
        private StudentenContext _studentenContext;

        public void Add(Student student)
        {
            _studentenContext.Student.Add(student);
            _studentenContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Student s = Get(id);
            Delete(s);
        }

        public void Delete(Student student)
        {
            _studentenContext.Student.Remove(student);
            _studentenContext.SaveChanges();
        }

        public Student Get(int id)
        {
            return _studentenContext.Student.First(s => s.Id == id);
        }

        public List<Student> GetByName(string naam) { 
            return _studentenContext.Student.Where(s => s.Naam == naam).ToList();
        }

        public List<Student> GetAll()
        {
            return _studentenContext.Student.ToList();
        }

        public void Update(Student student)
        {
            _studentenContext.SaveChanges();
        }
    }
}
