using Examples.Mapping.App.Services;
using Examples.Mapping.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using NetFusion.Services.Mapping;

namespace Examples.Mapping.WebApi.Controllers;

[ApiController, Route("api/[controller]")]
public class ExamplesController : ControllerBase
{
    private readonly SampleEntityService _entityService;
    private readonly IObjectMapper _objectMapper;

    public ExamplesController(
        SampleEntityService entityService,
        IObjectMapper objectMapper)
    {
        _entityService = entityService;
        _objectMapper = objectMapper;
    }
    
    [HttpGet("code-mapping")]
    public StudentListingSummary GetStudentListingSummary()
    {
        var courseEntity = _entityService.GetCourse();
        return _objectMapper.Map<StudentListingSummary>(courseEntity);
    }
    
    [HttpGet("derived-targets")]
    public IActionResult GetContactSummaries()
    {
        var contacts = _entityService.GetContacts();

        var mappedResults = contacts.Select(
            c => _objectMapper.Map<ContactSummary>(c)
        ).ToArray();

        return Ok(mappedResults.Cast<object>().ToArray());
    }
    
    [HttpGet("dependency-mapping")]
    public StudentCalcSummary GetStudentSummary()
    {
        var student = _entityService.GetStudent();
        return _objectMapper.Map<StudentCalcSummary>(student);
    }
    
    [HttpGet("opensource-mapping")]
    public CarSummary GetStudentCalcSummary()
    {
        var carEntity = _entityService.GetCar();
        return _objectMapper.Map<CarSummary>(carEntity);
    }
}