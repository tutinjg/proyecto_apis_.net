using System;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;

    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(ILogger<HelloWorldController> logger, IHelloWorldService helloWorld)
    {
        _logger = logger;
        helloWorldService = helloWorld;
    }

    [HttpGet]

    public IActionResult Get()
    {
        _logger.LogInformation("Se esta retornando el método GetHelloWorld");
        return Ok(helloWorldService.GetHelloWorld());
    }

}