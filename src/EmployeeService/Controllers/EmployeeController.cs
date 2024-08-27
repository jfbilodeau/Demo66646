using System.Text.Json;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrSystem.EmployeeService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public EmployeeController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string EmployeesText => System.IO.File.ReadAllText("data/employees.json");
    public Employee[] Employees => JsonSerializer.Deserialize<Employee[]>(EmployeesText, new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    }) ?? [];

    [HttpGet]
    // [EnableCors("AllowAll")]
    public IActionResult Get()
    {
        return Ok(Employees);
    }

    [HttpGet("{id}")]
    [EnableCors("AllowAll")]
    public IActionResult Get(string id)
    {
        var employee = Employees.FirstOrDefault(e => e.Id == id);

        return Ok(employee);
    }
}

