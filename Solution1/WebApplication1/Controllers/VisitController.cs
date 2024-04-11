using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("controller/visits")]
[ApiController]
public class VisitController : ControllerBase
{
    private static readonly List<Visit> _visits = new();

    [HttpGet("{animalId:int}")]
    public IActionResult GetVisitByAnimal(int animalId)
    {
        var visits = _visits.Where(vis => vis.Animal.Id == animalId);
        if (visits == null)
        {
            return NotFound($"No visits found for animal with id = {animalId}");
        }

        return Ok(visits);
    }

    [HttpPost]
    public IActionResult CreateNewVisit(Visit visit)
    {
        _visits.Add(visit);
        return Created();
    }
}