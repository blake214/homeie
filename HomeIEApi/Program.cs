using HomeIEApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics;
using HomeIEApi.Exceptions;
using HomeIEApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=Database/properties.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseExceptionHandler("/error");
app.Map("/error", (HttpContext context) =>
{
    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

    // Handel 400
    if (exception is BadRequestException) return Results.Problem(
        title: exception.Message,
        statusCode: StatusCodes.Status400BadRequest);

    // Handel 404
    if (exception is NotFoundException) return Results.Problem(
        title: exception.Message,
        statusCode: StatusCodes.Status404NotFound);

    // Handel 409
    if (exception is ConflictException) return Results.Problem(
        title: exception.Message,
        statusCode: StatusCodes.Status409Conflict);

    // Handel 500
    if (exception is InternalException) return Results.Problem(
        title: exception.Message,
        statusCode: StatusCodes.Status500InternalServerError);

    // Handel 500 DB error
    if (exception is DbUpdateException) return Results.Problem(
        title: "Database Error",
        statusCode: StatusCodes.Status500InternalServerError);

    // Handel unknown
    return Results.Problem(
        title: "Internal Server Error",
        statusCode: StatusCodes.Status500InternalServerError);
});

app.MapControllers();

app.Run();