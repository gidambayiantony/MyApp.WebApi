public class AffiliateResponseList
{

    public int Id { get; set; }
    public string Affiliate_Id { get; set; } = null!;
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? CountryName { get; set; }
    public string? CountryCode { get; set; }
    // public string? Password { get; set; } = null!;
    // public DateTime LastLogin { get; set; }
    // public bool IsLocked { get; set; } 
    public DateTime CreatedOn { get; set; }
    // public string? CreatedBy { get; set; }
    // public string? LastModifiedBy { get; set; } //Guid
    // public DateTime? LastModifiedOn { get; set; } //DateTimeOffset
    // public bool Deleted { get; set; } = false;
    // public List<Customer> Customers { get; set; } = new();
    // public List<Shop>? Shops { get; set; } = new();
}