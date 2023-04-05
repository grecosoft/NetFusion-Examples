using Examples.Mapping.Domain.Entities;
using Examples.Mapping.WebApi.Models;
using NetFusion.Services.Mapping;

namespace Examples.Mapping.WebApi.Mappings;

public class TeacherContactMapping: MappingStrategy<Teacher, TeacherSummary>
{
    protected override TeacherSummary SourceToTarget(Teacher source) =>
        new()
        {
            FullName = source.FirstName + " " + source.LastName,
            State = source.State,
            Zip =  source.Zip
        };
    
}