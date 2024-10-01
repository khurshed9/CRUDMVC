using System.Collections;
using CRUDMVC.Infrastructure.Models;
using Dapper;
using Npgsql;

namespace CRUDMVC.Infrastructure.Services;

public class PersonService : IPersonService
{
    public IEnumerable<Person> GetPersons()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.ConnectionString))
            {
                connection.Open();
                return  connection.Query<Person>(SqlCommand.GetPersons);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public Person? GetPersonById(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.ConnectionString))
            {
                connection.Open();
                return connection.QueryFirstOrDefault<Person>(SqlCommand.GetPersonById, new { Id = @id });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool CreatePerson(Person person)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommand.CreatePerson, person) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool UpdatePerson(Person person)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.ConnectionString))
            {
                connection.Open();
                return connection.Execute(SqlCommand.UpdatePerson, person) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public bool DeletePerson(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommand.ConnectionString))
            {  
                connection.Open();
                return connection.Execute(SqlCommand.DeletePerson, new { Id = @id }) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}

file class SqlCommand
{
    public const string ConnectionString = "Server=localhost;Port=5432;Database=crud_mvc_db;Username=postgres;Password=Galchaew05;";

    public const string CreatePerson = "Insert into persons(firstName, lastName, age, email, phone) values(@firstName, @lastName, @age, @email, @phone)";

    public const string GetPersons = "Select * from persons";
    
    public const string GetPersonById = "Select * from persons where id = @id";
    
    public const string UpdatePerson = "Update persons set id = @id, firstName = @firstName, lastName = @lastName, age = @age, email = @email, phone = @phone where id = @id";
    
    public const string DeletePerson = "Delete from persons where id = @id";
}