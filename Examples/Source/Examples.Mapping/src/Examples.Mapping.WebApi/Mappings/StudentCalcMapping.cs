using Examples.Mapping.Domain.Entities;
using Examples.Mapping.Domain.Services;
using Examples.Mapping.WebApi.Models;
using NetFusion.Services.Mapping;

namespace Examples.Mapping.WebApi.Mappings;

public class StudentCalcMapping: MappingStrategy<Student, StudentCalcSummary>
{
    private IEntityIdGenerator IdGenerator { get; }

    public StudentCalcMapping(IEntityIdGenerator idGenerator)
    {
        IdGenerator = idGenerator;
    }

    protected override StudentCalcSummary SourceToTarget(Student source)
    {
        var summary = new StudentCalcSummary
        {
            StudentId = IdGenerator.GenerateId(),
            FullName = source.FirstName + " " + source.LastName,
            Calculations = source.AttributeValues
        };

        return summary;
    }
}