using System;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloTeamController : ControllerBase
{
    IHelloTeamService helloTeamService;

    public HelloTeamController(IHelloTeamService helloTeam)
    {
        helloTeamService = helloTeam;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(helloTeamService.GetHelloTeam());
    }
}