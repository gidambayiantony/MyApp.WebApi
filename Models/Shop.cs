namespace MyApp.WebApi.Models;
public class Shop
{
    public int ShopId { get; set; }
    public string? ShopName { get; set; }
    public int DaysLeft { get; set; }
    public string? Location { get; set; }
    public int Attendants { get; set; }
    public DateTime DateJoined { get; set; }
    public DateTime LastSeen { get; set; }

    // Foreign Key: Each shop belongs to ONE customer
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
}