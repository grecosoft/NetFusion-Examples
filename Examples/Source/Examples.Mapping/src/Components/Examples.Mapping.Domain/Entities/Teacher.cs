namespace Examples.Mapping.Domain.Entities;

public class Teacher
{
    public int TeacherId { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Address { get; }
    public string City { get; }
    public string State { get; }
    public string Zip { get; }

    public Teacher(int teacherId, string firstName, string lastName,
        string address,
        string city,
        string state,
        string zip)
    {
        TeacherId = teacherId;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        City = city;
        State = state;
        Zip = zip;
    }
}