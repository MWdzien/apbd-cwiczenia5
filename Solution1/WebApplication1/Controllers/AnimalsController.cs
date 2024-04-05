using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalsController : ControllerBase 
{
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        return Ok();
    }
}