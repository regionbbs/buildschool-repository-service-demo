using BuildSchool.Mvc.Demo.Abstractions;
using BuildSchool.Mvc.Demo.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BuildSchool.Mvc.Demo.Repository
{
    public class EmployeeRepository : IEmployeeRepository, IRepository<IEmployee, int>
    {
        private IDbOptions _dbOptions;

        public EmployeeRepository(IDbOptions dbOptions)
        {
            _dbOptions = dbOptions;
        }

        public void Create(IEmployee employee)
        {
            var connection = new SqlConnection(_dbOptions.ConnectionString);
            connection.Execute(
                @"INSERT INTO Employees VALUES (@ln, @fn, @title, @titleC, @birthdate, @hiredate, @addr, @city, 
                                                @region, @postalcode, @country, @hp, @ext, @photo, @notes, @reportTo, @photoPath)",
                new
                {
                    ln = employee.LastName,
                    fn = employee.FirstName,
                    title = employee.Title,
                    titleC = employee.TitleOfCourtesy,
                    birthdate = employee.BirthDate,
                    hiredate = employee.HireDate,
                    addr = employee.Address,
                    city = employee.City,
                    region = employee.Region,
                    postalcode = employee.PostalCode,
                    country = employee.Country,
                    hp = employee.HomePhone,
                    ext = employee.Extension,
                    photo = employee.Photo,
                    notes = employee.Notes,
                    reportTo = employee.ReportsTo,
                    photoPath = employee.PhotoPath
                });
        }

        public void Delete(IEmployee employee)
        {
            var connection = new SqlConnection(_dbOptions.ConnectionString);
            connection.Execute(
                @"DELETE FROM Employees WHERE EmployeeID = @id",
                new
                {
                    id = employee.EmployeeID
                });
        }

        public IEmployee Get(int id)
        {
            var connection = new SqlConnection(_dbOptions.ConnectionString);
            return connection.QuerySingle<Employee>("SELECT * FROM Employees WHERE EmployeeID = @id", new { id });
        }

        public IEnumerable<IEmployee> GetAll()
        {
            var connection = new SqlConnection(_dbOptions.ConnectionString);
            return connection.Query<Employee>("SELECT * FROM Employees");
        }

        public void Update(IEmployee employee)
        {
            var connection = new SqlConnection(_dbOptions.ConnectionString);
            connection.Execute(
                @"UPDATE Employees SET LastName = @ln, FirstName = @fn, Title = @title, TitleOfCourtesy = @titleC, 
                                       BirthDate = @birthdate, HireDate = @hiredate, Address = @addr, City = @city, 
                                       Region = @region, PostalCode = @postalcode, Country = @country, HomePhone = @hp, 
                                       Extension = @ext, Photo = @photo, Notes = @notes, ReportsTo = @reportTo, PhotoPath = @photoPath
                  WHERE EmployeeID = @id",
                new
                {
                    id = employee.EmployeeID,
                    ln = employee.LastName,
                    fn = employee.FirstName,
                    title = employee.Title,
                    titleC = employee.TitleOfCourtesy,
                    birthdate = employee.BirthDate,
                    hiredate = employee.HireDate,
                    addr = employee.Address,
                    city = employee.City,
                    region = employee.Region,
                    postalcode = employee.PostalCode,
                    country = employee.Country,
                    hp = employee.HomePhone,
                    ext = employee.Extension,
                    photo = employee.Photo,
                    notes = employee.Notes,
                    reportTo = employee.ReportsTo,
                    photoPath = employee.PhotoPath
                });
        }
    }
}
