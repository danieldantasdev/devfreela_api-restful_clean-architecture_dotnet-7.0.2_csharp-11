using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    //api/Project?query=net core
    [HttpGet("[action]")]
    public IActionResult GetAll(string query)
    {
        //buscar todos
        return Ok();
    }

    //api/Project/1
    [HttpGet("[action]/{id}")]
    public IActionResult GetById(int id)
    {
        // caso o id não exisitir, return NotFound();
        
        //buscar por id
        return Ok();
    }

    //api/Project/
    [HttpPost("[action]")]
    public IActionResult Create([FromBody] CreateProjectModel createProjectModel)
    {
        //valida se o título tem mas de 50 caracteres, se tiver, retorna BadRequest
        if (createProjectModel.Title.Length > 50)
        {
            return BadRequest();
        }

        //criar objeto
        return CreatedAtAction(nameof(GetById), new { id = createProjectModel.Id }, createProjectModel);
    }

    [HttpPut("[action]/{id}")]
    public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProjectModel)
    {
        
        if (updateProjectModel.Description.Length > 200)
        {
            return BadRequest();
        }

        //atualizar objeto
        return NoContent();
    }

    [HttpDelete("[action]/{id}")]
    public IActionResult Delete(int id)
    {
        //Buscar, se não existir, retorna NotFound()

        //Remover
        return NoContent();
    }
}