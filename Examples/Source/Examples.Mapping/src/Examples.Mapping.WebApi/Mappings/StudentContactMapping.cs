using Examples.Mapping.Domain.Entities;
using Examples.Mapping.WebApi.Models;
using NetFusion.Services.Mapping;

namespace Examples.Mapping.WebApi.Mappings;

public class StudentContactMapping: MappingStrategy<Student, StudentSummary>
{
    protected override StudentSummary SourceToTarget(Student source) =>
        new()
        {
            FullName = source.FirstName + " == " + source.LastName,
            MaxScore = source.Scores.Max(),
            MinScore = source.Scores.Min()
        };
}