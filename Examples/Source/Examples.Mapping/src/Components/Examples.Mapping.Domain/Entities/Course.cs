using System.Collections.Generic;

namespace Examples.Mapping.Domain.Entities
{
    public class Course
    {
        public string Name { get; }
        public string Instructor { get; }
        public int Year { get; }
        public int Semester { get; set; }
        public IReadOnlyCollection<Student> Students => _students;

        private readonly List<Student> _students;


        public Course(
            string name,
            string instructor,
            int year,
            int semester)
        {
            Name = name;
            Instructor = instructor;
            Year = year;
            Semester = semester;
            _students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }
    }
}