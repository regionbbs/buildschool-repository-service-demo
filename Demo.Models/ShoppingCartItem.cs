using BuildSchool.Mvc.Demo.Abstractions;

namespace BuildSchool.Mvc.Demo.Models
{
    public class ShoppingCartItem : IShoppingCartItem
    {
        public string ShoppingCartId { get; set; }
        public string ProductId { get; set; }
        public int Qty { get; set; }
        public int UnitPrice { get; set; }
    }
}
