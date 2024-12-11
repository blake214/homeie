using Microsoft.AspNetCore.Mvc;
using HomeIEApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using HomeIEApi.Repositories;
using HomeIEApi.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HomeIEApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PropertyController : ControllerBase
{
    private readonly IPropertyRepository _repository;
    private readonly ILogger<PropertyController> _logger;

    public PropertyController(ILogger<PropertyController> logger, IPropertyRepository repository)
    {
        _repository = repository;
        _logger = logger;
    }

    // ======================================================== UTILITIES
    // Validates a PK
    private static void ValidateId(int id)
    {
        if (id <= 0) throw new BadRequestException("Invalid ID");
    }
    // Process Exception, by returning a IAction that we can directly send to client
    public static IActionResult ProcessException(Exception exception, ILogger logger)
    {
        // Log only 500 errors
        if (exception is InternalException || exception is DbUpdateException || !(exception is BadRequestException or NotFoundException or ConflictException))
        {
            logger.LogError(exception, "An error occurred: {Message}", exception.Message);
        }

        return exception switch
        {
            // Handle 400
            BadRequestException badRequestException =>
                new BadRequestObjectResult(new { badRequestException.Message }),

            // Handle 404
            NotFoundException notFoundException =>
                new NotFoundObjectResult(new { notFoundException.Message }),

            // Handle 409
            ConflictException conflictException =>
                new ConflictObjectResult(new { conflictException.Message }),

            // Handle 500 - Internal Application Errors
            InternalException internalException =>
                new ObjectResult(new { internalException.Message }) { StatusCode = StatusCodes.Status500InternalServerError },

            // Handle 500 - Database Errors
            DbUpdateException _ =>
                new ObjectResult(new { Message = "Database Error" }) { StatusCode = StatusCodes.Status500InternalServerError },

            // Handle all unknown exceptions as internal server errors
            _ => new ObjectResult(new { Message = "Internal Server Error" }) { StatusCode = StatusCodes.Status500InternalServerError }
        };
    }

    // ======================================================== ENDPOINTS
    [HttpGet("{id}", Name = "GetProperty")]
    public IActionResult Get(int id)
    {
        try
        {
            // ============== Validations
            ValidateId(id);

            // ============== Query
            var property = _repository.Get(id);

            // ============== Generate Response
            // Return 200
            return Ok(property);
        }
        catch (Exception ex)
        {
            return ProcessException(ex, _logger);
        }
    }
    [HttpPost(Name = "PostProperty")]
    public IActionResult Post([FromBody] Property newProperty)
    {
        try
        {
            // ============== Validations
            if (!ModelState.IsValid) return BadRequest(ModelState);
            ValidateId(newProperty.Id);

            // ============== Query
            _repository.Add(newProperty);

            // ============== Generate Response
            // Return 201
            return CreatedAtRoute("GetProperty", new { id = newProperty.PropertyId }, newProperty);
        }
        catch (Exception ex)
        {
            return ProcessException(ex, _logger);
        }
    }
    [HttpDelete("{id}", Name = "DeleteProperty")]
    public IActionResult Delete(int id)
    {
        try
        {
            // ============== Validations
            ValidateId(id);

            // ============== Query
            _repository.Delete(id);

            // ============== Generate Response
            // Return 200
            return Ok(new { Message = "Success" });
        }
        catch (Exception ex)
        {
            return ProcessException(ex, _logger);
        }
    }
    [HttpPut("{id}", Name = "UpdateProperty")]
    public IActionResult Put(int id, [FromBody] Property updatedProperty)
    {
        try
        {
            // ============== Validations
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != updatedProperty.Id) return BadRequest("ID in the route does not match ID in the body");
            ValidateId(updatedProperty.Id);

            // ============== Query
            _repository.Update(id, updatedProperty);

            // ============== Generate Response
            // Return 200
            return Ok(new { Message = "Success" });
        }
        catch (Exception ex)
        {
            return ProcessException(ex, _logger);
        }
    }

    [HttpPatch("{id}", Name = "PatchProperty")]
    public IActionResult Patch(int id, [FromBody] JsonPatchDocument<Property> patchDocument)
    {
        try
        {
            // ============== Validations
            if (!ModelState.IsValid) return BadRequest(ModelState);
            ValidateId(id);

            // ============== Query
            _repository.PartialUpdate(id, patchDocument);

            // ============== Generate Response
            // Return 200
            return Ok(new { Message = "Success" });
        }
        catch (Exception ex)
        {
            return ProcessException(ex, _logger);
        }
    }
}
