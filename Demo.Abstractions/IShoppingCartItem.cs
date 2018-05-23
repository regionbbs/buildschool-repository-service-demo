namespace BuildSchool.Mvc.Demo.Abstractions
{
    public interface IShoppingCartItem
    {
        string ShoppingCartId { get; }
        string ProductId { get; }
        int Qty { get; }
        int UnitPrice { get; }
    }
}
