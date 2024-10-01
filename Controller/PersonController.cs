using CRUDMVC.Infrastructure.Models;
using CRUDMVC.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDMVC.Controller;

[Route("/api/persons/")]
[ApiController]

public class PersonController : ControllerBase
{
    private readonly IPersonService _personService = new PersonService();
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IResult GetPersons()
    {
        return Results.Ok(_personService.GetPersons());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IResult GetPersonById(int id)
    {
        if (id == 0) return Results.BadRequest();
        return Results.Ok(_personService.GetPersonById(id));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IResult CreatePerson(Person person)
    {
        if (person == null) return Results.BadRequest();
        return Results.Ok(_personService.CreatePerson(person));
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IResult UpdatePerson(Person person)
    {
        if (person == null) return Results.NotFound();
        return Results.Ok(_personService.UpdatePerson(person));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IResult DeletePerson(int id)
    {
        if (id == 0) return Results.BadRequest();
        return Results.Ok(_personService.DeletePerson(id));
    }
}