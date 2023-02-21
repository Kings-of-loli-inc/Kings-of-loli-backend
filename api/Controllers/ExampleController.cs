using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{
    private readonly ILogger<ExampleResponse> _logger;

    public ExampleController(ILogger<ExampleResponse> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetExample")]
    public IEnumerable<ExampleResponse> Get()
    {

        return Enumerable.Range(1, 5).Select(index => new ExampleResponse
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Name = Database.request()
        })
        .ToArray();
    }
}
