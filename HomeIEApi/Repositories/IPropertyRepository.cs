using HomeIEApi.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace HomeIEApi.Repositories;

public interface IPropertyRepository
{
    Property Get(int id);
    void Add(Property property);
    void Update(int id, Property property);
    void PartialUpdate(int id, JsonPatchDocument<Property> patchDocument);
    void Delete(int id);
}
