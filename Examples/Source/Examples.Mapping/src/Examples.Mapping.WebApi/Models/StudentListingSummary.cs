namespace Examples.Mapping.WebApi.Models;

public class StudentListingSummary
{
    public string Instructor { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Year { get; set; }
    public int Semester { get; set; }
    public int HighestScore { get; set; }
    public StudentAverage[] Averages { get; set; } = Array.Empty<StudentAverage>();
}