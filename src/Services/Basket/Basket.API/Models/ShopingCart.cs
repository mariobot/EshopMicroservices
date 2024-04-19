namespace Basket.API.Models;

public class ShopingCart
{
    public string Username { get; set; } = default!;
    public List<ShoppingCartItem> Items { get; set; } = new();
    public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

    public ShopingCart(string username)
    {
        this.Username = username;
    }

    public ShopingCart()
    {
        
    }
}
