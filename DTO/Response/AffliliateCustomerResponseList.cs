using MyApp.WebApi.Models;

public class AffiliateCustomerResponseList{
    public int Id { get; set; }

    public string UserId { get; set; }= null!;
    public string Affiliate_Id { get; set; } = null!;
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? CountryName { get; set; }
    // public string? CountryCode { get; set; }
    public DateTime CreatedOn { get; set; }

    public string? Referedby { get; set; }

     public ICollection<Shop> Shops { get;  } = [];

}