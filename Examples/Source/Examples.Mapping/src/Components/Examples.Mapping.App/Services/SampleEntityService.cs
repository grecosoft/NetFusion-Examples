using System.Linq;
using Examples.Mapping.Domain.Entities;

namespace Examples.Mapping.App.Services;

public class SampleEntityService
{
    private static Course ExampleEntity =>
        new Course("Computer Science",
            "Mark Smith",
            2018,
            2);

    private static void AddStudents(Course course)
    {
        course.AddStudent(
            new Student("Tom", "Green", new[] { 100, 92 }));

        course.AddStudent(
            new Student("Jim", "Smith", new[] { 90, 89 }));
    }

    // Methods returning entity for use by mappings examples:
    public Course GetCourse()
    {
        var course = ExampleEntity;

        AddStudents(course);
        return course;
    }
    
    public object[] GetContacts() {
        var entity = ExampleEntity;
        AddStudents(entity);

        var student = entity.Students.First();
        var teacher = new Teacher(1, "Ben", "Smith",
            "134 West Main",
            "Cheshire",
            "CT",
            "06410");

        return new object[]
        {
            student,
            teacher
        };
    }
    
    public Student GetStudent()
    {
        var entity = ExampleEntity;
        AddStudents(entity);

        var student = entity.Students.First();
        student.Attributes.Values.MaxScore = student.Scores.Max();
        student.Attributes.Values.MinScore = student.Scores.Min();

        return student;
    }
    
    public Car GetCar()
    {
        return new Car("Honda", "Accord", 8000, "white", 2010) {
            WasSmokerCar = true,
            HasSalvageTitle = true
        };
    }
}