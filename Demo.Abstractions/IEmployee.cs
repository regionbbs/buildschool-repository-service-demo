using System;

namespace BuildSchool.Mvc.Demo.Abstractions
{
    public interface IEmployee
    {
        int EmployeeID { get; }
        string LastName { get; }
        string FirstName { get; }
        string Title { get; }
        string TitleOfCourtesy { get; }
        DateTime BirthDate { get; }
        DateTime HireDate { get; }
        string Address { get; }
        string City { get; }
        string Region { get; }
        string PostalCode { get; }
        string Country { get; }
        string HomePhone { get; }
        string Extension { get; }
        byte[] Photo { get; }
        string Notes { get; }
        int ReportsTo { get; }
        string PhotoPath { get; }
    }
}
