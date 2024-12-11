using Microsoft.AspNetCore.Mvc;
using HomeIEApi.Controllers;
using HomeIEApi.Models;
using HomeIEApi.Database;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using HomeIEApi.Repositories;

namespace HomeIEApi.Tests.Controllers;

public class PropertyControllerTests
{
    private readonly DbContextOptions<AppDbContext> _dbContextOptions;
    private readonly ILogger<PropertyController> _logger;
    public PropertyControllerTests()
    {
        _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        var loggerFactory = LoggerFactory.Create(builder =>
    {
        builder
            .AddConsole()
            .SetMinimumLevel(LogLevel.Debug);
    });

        _logger = loggerFactory.CreateLogger<PropertyController>();
    }
    private AppDbContext InitializeContext()
    {
        var context = new AppDbContext(_dbContextOptions);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        return context;
    }

    // ======================================================== GET
    [Fact]
    public void Get_ReturnsOk_WhenPropertyExists()
    {
        // ============== Init DB
        using var context = InitializeContext();
        context.Properties?.Add(new Property { Id = 1 });
        context.SaveChanges();

        // ============== Init Repository
        var repository = new PropertyRepository(context);

        // ============== Init Controller
        var controller = new PropertyController(_logger, repository);

        // ============== ACT
        var result = controller.Get(1);

        // ============== Asserts
        // Assert 200
        var okResult = Assert.IsType<OkObjectResult>(result);
        // Assert response object correct data structure
        var property = Assert.IsType<Property>(okResult.Value);
        // Assert response payload
        Assert.Equal(1, property.Id);
    }

    [Fact]
    public void Get_ReturnsNotFound_WhenPropertyDoesNotExist()
    {
        // ============== Init DB
        using var context = InitializeContext();

        // ============== Init Repository
        var repository = new PropertyRepository(context);

        // ============== Init Controller
        var controller = new PropertyController(_logger, repository);

        // ============== ACT
        var result = controller.Get(1);

        // ============== Asserts
        // Assert 404
        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public void Get_ReturnsBadRequest_ForInvalidId()
    {
        // ============== Init DB
        using var context = InitializeContext();

        // ============== Init Repository
        var repository = new PropertyRepository(context);

        // ============== Init Controller
        var controller = new PropertyController(_logger, repository);

        // ============== ACT
        var result = controller.Get(0);

        // ============== Asserts
        // Assert 400
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void Get_ReturnsNotFound_WhenDatabaseIsEmpty()
    {
        // ============== Init DB
        using var context = InitializeContext();

        // ============== Init Repository
        var repository = new PropertyRepository(context);

        // ============== Init Controller
        var controller = new PropertyController(_logger, repository);

        // ============== ACT
        var result = controller.Get(1);

        // ============== Asserts
        // Assert 404
        Assert.IsType<NotFoundObjectResult>(result);
    }

    // ======================================================== POST
    [Fact]
    public void Post_ReturnsCreated_WhenPropertiesAreValid()
    {
        // ============== Init DB
        using var context = InitializeContext();

        // ============== Init Repository
        var repository = new PropertyRepository(context);

        // ============== Init Controller
        var controller = new PropertyController(_logger, repository);

        // ============== ACT
        // Create Property
        var newProperty = new Property { Id = 1 };
        // Act
        var result = controller.Post(newProperty);

        // ============== Asserts
        // Assert 201
        Assert.IsType<CreatedAtRouteResult>(result);
        // Assert Database Updated
        var property = context.Properties?.Find(1);
        Assert.NotNull(property);
        Assert.Equal(1, property?.Id);
    }

    [Fact]
    public void Post_ReturnsBadRequest_WhenIDIsInvalid()
    {
        // ============== Init DB
        using var context = InitializeContext();

        // ============== Init Repository
        var repository = new PropertyRepository(context);

        // ============== Init Controller
        var controller = new PropertyController(_logger, repository);

        // ============== ACT
        // Create Property
        var invalidProperty = new Property { Id = 0 };
        // Act
        var result = controller.Post(invalidProperty);

        // ============== Asserts
        // Assert 400
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void Post_ReturnsConflict_WhenIDAlreadyExists()
    {
        // ============== Init DB
        using var context = InitializeContext();
        context.Properties?.Add(new Property { Id = 1 });
        context.SaveChanges();

        // ============== Init Repository
        var repository = new PropertyRepository(context);

        // ============== Init Controller
        var controller = new PropertyController(_logger, repository);

        // ============== ACT
        // Create Property
        var duplicateProperty = new Property { Id = 1 };
        // Act
        var result = controller.Post(duplicateProperty);

        // ============== Asserts
        // Assert 209
        Assert.IsType<ConflictObjectResult>(result);
    }

    // ======================================================== DELETE
    [Fact]
    public void Delete_ReturnsNoContent_WhenPropertyExists()
    {
        // ============== Init DB
        using var context = InitializeContext();
        context.Properties?.Add(new Property { Id = 1 });
        context.SaveChanges();

        // ============== Init Repository
        var repository = new PropertyRepository(context);

        // ============== Init Controller
        var controller = new PropertyController(_logger, repository);

        // ============== ACT
        // Assert 200
        var result = controller.Delete(1);

        // ============== Asserts
        // Assert
        Assert.IsType<OkObjectResult>(result);
        // Assert record deleted
        Assert.Null(context.Properties?.Find(1));
    }

    [Fact]
    public void Delete_ReturnsBadRequest_WhenIDIsInvalid()
    {
        // ============== Init DB
        using var context = InitializeContext();

        // ============== Init Repository
        var repository = new PropertyRepository(context);

        // ============== Init Controller
        var controller = new PropertyController(_logger, repository);

        // ============== ACT
        var result = controller.Delete(0); // Invalid ID

        // ============== Asserts
        // Assert 400
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void Delete_ReturnsNotFound_WhenPropertyDoesNotExist()
    {
        // ============== Init DB
        using var context = InitializeContext();

        // ============== Init Repository
        var repository = new PropertyRepository(context);

        // ============== Init Controller
        var controller = new PropertyController(_logger, repository);

        // ============== ACT
        var result = controller.Delete(50);

        // ============== Asserts
        // Assert 404
        Assert.IsType<NotFoundObjectResult>(result);
    }

    // ======================================================== PUT
    [Fact]
    public void Put_ReturnsOk_WhenPropertyIsUpdated()
    {
        // ============== Init DB
        using var context = InitializeContext();
        context.Properties?.Add(new Property { Id = 1, PropertyId = 1 });
        context.SaveChanges();

        // ============== Init Repository
        var repository = new PropertyRepository(context);

        // ============== Init Controller
        var controller = new PropertyController(_logger, repository);

        // ============== ACT
        // Create Property
        var updatedProperty = new Property { Id = 1, PropertyId = 2 };
        // Act
        var result = controller.Put(id: 1, updatedProperty);

        // ============== Asserts
        // Assert 200
        Assert.IsType<OkObjectResult>(result);
        // Assert Database Updated
        var property = context.Properties?.Find(1);
        Assert.NotNull(property);
        Assert.Equal(2, property?.PropertyId);
    }

    [Fact]
    public void Put_ReturnsBadRequest_WhenIDIsInvalid()
    {
        // ============== Init DB
        using var context = InitializeContext();

        // ============== Init Repository
        var repository = new PropertyRepository(context);

        // ============== Init Controller
        var controller = new PropertyController(_logger, repository);

        // ============== ACT
        // Create Property
        var updatedProperty = new Property { Id = 0, PropertyId = 2 };
        // Act
        var result = controller.Put(id: 0, updatedProperty);

        // ============== Asserts
        // Assert 400
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void Put_ReturnsNotFound_WhenPropertyDoesNotExist()
    {
        // ============== Init DB
        using var context = InitializeContext();

        // ============== Init Repository
        var repository = new PropertyRepository(context);

        // ============== Init Controller
        var controller = new PropertyController(_logger, repository);

        // ============== ACT
        // Create Property
        var updatedProperty = new Property { Id = 1, PropertyId = 2 };
        // Act
        var result = controller.Put(id: 1, updatedProperty);

        // ============== Asserts
        // Assert 404
        Assert.IsType<NotFoundObjectResult>(result);
    }

    // ======================================================== PATCH
    [Fact]
    public void Patch_ReturnsOk_WhenPropertyIsUpdated()
    {
        // ============== Init DB
        using var context = InitializeContext();
        context.Properties?.Add(new Property { Id = 1, PropertyId = 1 });
        context.SaveChanges();

        // ============== Init Repository
        var repository = new PropertyRepository(context);

        // ============== Init Controller
        var controller = new PropertyController(_logger, repository);

        // ============== ACT
        // Create Property
        var patchDocument = new JsonPatchDocument<Property>();
        patchDocument.Replace(p => p.PropertyId, 2);
        // Act
        var result = controller.Patch(1, patchDocument);

        // ============== Asserts
        // Assert 200
        Assert.IsType<OkObjectResult>(result);
        // Assert Database Updated
        var propertya = context.Properties?.Find(1);
        Assert.NotNull(propertya);
        Assert.Equal(2, propertya?.PropertyId);
    }

    [Fact]
    public void Patch_ReturnsBadRequest_WhenIDIsInvalid()
    {
        // ============== Init DB
        using var context = InitializeContext();

        // ============== Init Repository
        var repository = new PropertyRepository(context);

        // ============== Init Controller
        var controller = new PropertyController(_logger, repository);

        // ============== ACT
        // Create Property
        var patchDocument = new JsonPatchDocument<Property>();
        patchDocument.Replace(p => p.PropertyId, 2);
        // Act
        var result = controller.Patch(0, patchDocument);

        // ============== Asserts
        // Assert 400
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void Patch_ReturnsNotFound_WhenPropertyDoesNotExist()
    {
        // ============== Init DB
        using var context = InitializeContext();

        // ============== Init Repository
        var repository = new PropertyRepository(context);

        // ============== Init Controller
        var controller = new PropertyController(_logger, repository);

        // ============== ACT
        // Create Property
        var patchDocument = new JsonPatchDocument<Property>();
        patchDocument.Replace(p => p.PropertyId, 2);
        // Act
        var result = controller.Patch(1, patchDocument);

        // ============== Asserts
        // Assert 404
        Assert.IsType<NotFoundObjectResult>(result);
    }
}
