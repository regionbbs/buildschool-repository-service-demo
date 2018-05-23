namespace BuildSchool.Mvc.Demo.Abstractions
{
    public interface ICustomer
    {
        string CustomerID { get; }
        string CompanyName { get; }
        string ContactName { get; }
        string ContactTitle { get; }
        string Address { get; }
        string City { get; }
        string Region { get; }
        string PostalCode { get; }
        string Country { get; }
        string Phone { get; }
        string Fax { get; }
    }
}
