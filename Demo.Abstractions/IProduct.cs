namespace BuildSchool.Mvc.Demo.Abstractions
{
    public interface IProduct
    {
        int ProductID { get; }
        string ProductName { get; }
        int SupplierID { get; }
        int CategoryID { get; }
        string QuantityPerUnit { get; }
        decimal UnitPrice { get; }
        int UnitsInStock { get; }
        int UnitsOnOrder { get; }
        int ReorderLevel { get; }
        bool Discontinued { get; }
    }
}
