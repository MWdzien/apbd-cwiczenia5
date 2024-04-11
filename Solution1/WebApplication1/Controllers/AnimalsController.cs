using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("controller/animals")]
[ApiController]
public class AnimalsController : ControllerBase 
{
    private static readonly List<Animal> _animals= new()
    {
        new Animal { Id = 1, Category  = "dog", FurColor = "white", Name = "pimpek", Weight = 10.7},
        new Animal { Id = 2, Category  = "cat", FurColor = "tricolor", Name = "kot", Weight = 6.3},
        new Animal { Id = 3, Category  = "cat", FurColor = "black", Name = "filemon", Weight = 4.2}
    }; 
    
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetAnimalById(int id)
    {
        var animal = _animals.FirstOrDefault(an => an.Id == id);
        
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        _animals.Add(animal);
        return Created();
    }

    [HttpPut("{id:int}")]
    public IActionResult EditAnimal(int id, Animal animal)
    {
        var animalToEdit = _animals.FirstOrDefault(an => an.Id == id);
        if (animalToEdit == null)
        {
            _animals.Add(animal);
            return Created();
        }

        _animals.Remove(animalToEdit);
        _animals.Add(animal);
        return Ok(animal);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(x => x.Id == id);

        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        return Ok(animal);
    }
}