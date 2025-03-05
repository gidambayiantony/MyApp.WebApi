namespace MyApp.WebApi.Models;

public class Affiliate
{

    public int Id { get; set; }

    public User User { get; set; } = null!;

    public string Affiliate_Id { get; set; } = null!;
    // public string? Id { get; set; }
    // public string? Username { get; set; }
    // public string? EmailAddress { get; set; }
    // public string? Location { get; set; }

    //  public DateTime LastSeen { get; set; }
    // public DateTime DateJoined { get; set; }
    // public string? PhoneNumber { get; set; }
    // public List<Customer> Customers { get; set; } = new();
    // public List<Shop>? Shops { get; set; } = new();
}
