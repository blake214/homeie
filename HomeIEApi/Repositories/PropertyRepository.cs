using HomeIEApi.Database;
using HomeIEApi.Models;
using HomeIEApi.Exceptions;
using Microsoft.AspNetCore.JsonPatch;

namespace HomeIEApi.Repositories;

public class PropertyRepository : IPropertyRepository
{
    private readonly AppDbContext _context;

    public PropertyRepository(AppDbContext context)
    {
        _context = context;
    }

    // ======================================================== UTILITIES
    // Validates context
    private void ValidateContext()
    {
        if (_context.Properties == null) throw new InternalException("Database error");
    }

    // ======================================================== METHODS
    public Property Get(int id)
    {
        ValidateContext();
        return _context.Properties?.Find(id) ?? throw new NotFoundException("Not found");
    }

    public void Add(Property property)
    {
        ValidateContext();
        // Return 209 (Verbose though clearer than catching exception)
        if (_context.Properties?.Any(p => p.Id == property.Id) == true) throw new ConflictException("ID already exists");
        _context.Properties?.Add(property);
        _context.SaveChanges();
    }

    public void Update(int id, Property property)
    {
        ValidateContext();
        var existingProperty = _context.Properties?.Find(id) ?? throw new NotFoundException("Not found");
        _context.Entry(existingProperty).CurrentValues.SetValues(property);
        _context.SaveChanges();
    }

    public void PartialUpdate(int id, JsonPatchDocument<Property> patchDocument)
    {
        ValidateContext();
        var existingProperty = _context.Properties?.Find(id) ?? throw new NotFoundException("Not found");
        // Apply the patch to the existing entity
        patchDocument.ApplyTo(existingProperty, error =>
        {
            throw new InvalidOperationException($"Error applying patch: {error.ErrorMessage}");
        });
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        ValidateContext();
        var property = _context.Properties?.Find(id) ?? throw new NotFoundException("Not found");
        _context.Properties?.Remove(property);
        _context.SaveChanges();
    }
}
