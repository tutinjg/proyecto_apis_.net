using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]

public class TareaController : ControllerBase
{
    ITareaService tareaService;

    public TareaController(ITareaService tarService)
    {
        tareaService = tarService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        return Ok(tareaService.Save(tarea));
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea)
    {
        return Ok(tareaService.Update(id, tarea));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        return Ok(tareaService.Delete(id));
    }



}
