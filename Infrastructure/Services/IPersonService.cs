using CRUDMVC.Infrastructure.Models;

namespace CRUDMVC.Infrastructure.Services;

public interface IPersonService 
{
    IEnumerable<Person> GetPersons();
    
    Person? GetPersonById(int id);
    
    bool CreatePerson(Person person);
    
    bool UpdatePerson(Person person);
    
    bool DeletePerson(int id);
}