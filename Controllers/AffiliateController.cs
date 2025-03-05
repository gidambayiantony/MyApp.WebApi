using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.WebApi;
using MyApp.WebApi.DTO.Requests;
using MyApp.WebApi.Models;

[Route("api/[controller]")]
[ApiController]
public class AffiliateController : ControllerBase
{
    private static List<Affiliate> Affiliates = new List<Affiliate>();
    private static int AffiliateCounter = 5000; // Start from 5000 so first ID is AF5001

    private readonly AppDbContext _context;

    public AffiliateController(AppDbContext context)
    {
        _context = context;
    }
   //get all affiliates
    [HttpGet("GetAffiliates")]
    public async Task<ActionResult<AffiliateResponseList>> GetAffiliates()
    {
        var affs =  await _context.Affiliates.Include(a => a.User).ToListAsync();

        List<AffiliateResponseList> affiliateResponseLists = new List<AffiliateResponseList>();


        foreach (var aff in affs)
        {
             AffiliateResponseList affiliateResponseList = new AffiliateResponseList();
            affiliateResponseList.Affiliate_Id = aff.Affiliate_Id;
            affiliateResponseList.Email = aff.User.Email;
            affiliateResponseList.UserName = aff.User.Username;
            affiliateResponseList.Phone = aff.User.Phone;
            affiliateResponseList.CountryCode = aff.User.CountryCode;
            affiliateResponseList.CreatedOn = aff.User.Datejoined;
            affiliateResponseList.Id = aff.Id;
            affiliateResponseList.CountryName = "Nigeria";

            affiliateResponseLists.Add(affiliateResponseList);

        
        }

        return Ok(affiliateResponseLists);
    }

    [HttpGet("GetAffiliateCustomers")]
     public async Task<ActionResult> GetAffliateCustomers(string affId)
    {
    var  customerlist =  await _context.ShopOwners.Include(a => a.User).Where(a => a.Referedby == affId).ToListAsync();

    List<AffiliateCustomerResponseList> affiliateCustomerResponseLists = new List<AffiliateCustomerResponseList>();

       foreach(var affcustomers in customerlist){
              AffiliateCustomerResponseList affiliateCustomerResponseList = new AffiliateCustomerResponseList();
              affiliateCustomerResponseList.UserId = affcustomers.User.Userid;
              affiliateCustomerResponseList.Affiliate_Id = affcustomers.Referedby ?? string.Empty;
              affiliateCustomerResponseList.Email = affcustomers.User.Email;
              affiliateCustomerResponseList.UserName = affcustomers.User.Username;
              affiliateCustomerResponseList.Phone = affcustomers.User.Phone;
              affiliateCustomerResponseList.CreatedOn = affcustomers.User.Datejoined;
              affiliateCustomerResponseList.Id = affcustomers.Id;
              affiliateCustomerResponseList.Referedby = affcustomers.Referedby;
              
    
              affiliateCustomerResponseLists.Add(affiliateCustomerResponseList);

       }

       return Ok(affiliateCustomerResponseLists);
    }

 

//  //get an affiliate by id 
//     [HttpGet("{id}")]
//     public async Task<ActionResult<Affiliate>> GetAffiliate(int id)
//     {
//         var affiliate = await _context.Affiliates.Include(a => a.Customers).ThenInclude(c => c.Shops)
//                                                  .FirstOrDefaultAsync(a => a.Id == id);
//         if (affiliate == null)
//             return NotFound(new { message = "Affiliate not found" });

//         return affiliate;
//     }

    //create an affiliate with autogen id
   
    // public async Task<ActionResult<Affiliate>> CreateAffiliate(Affiliate affiliate)
    // {
    //     AffiliateCounter++;
    //     affiliate.Id = $"AF{AffiliateCounter}";
    //     _context.Affiliates.Add(affiliate);
    //     await _context.SaveChangesAsync();
    //     return CreatedAtAction(nameof(GetAffiliate), new { id = affiliate.Id }, affiliate);
    // }
     
        [HttpPost("CreateAffiliate")]
        public async Task<int> CreateAffiliate(CreateAffiliateReq req)
    {
        var ids = await _context.Users.Select(x => new User { Id = x.Id })
                                                .OrderByDescending(x => x.Id)
                                                .FirstAsync();
        string userid = $"AF{ids.Id + 1}" ;

        
       
        // var attedantSettings = UtilityHelperService.GetAttedantDefaultPermission();        

        // string hashedPaswd = UtilityHelperService.GetMd5Hash(req.Password);
        var user = new User()
        {            
            Username = req.UserName,
            Userid = userid,
            Email = req.Email,
            Name = req.UserName,
            Password = req.Password,
            Phone = req.Phone,
            CountryCode = req.CountryCode,
            Datejoined = DateTime.Now,
            Lastseen = DateTime.Now,
            // Status = 0,
            RoleId = 0,           
            Rolename="affiliate",
            UserLogin = new UserLogin()
            {
                UserId = userid,
                Email = req.Email,
                Password = req.Password,
                Username = req.UserName,
                NormalizedPassword = req.Password
            },
            Affiliate = new Affiliate()
            {
              Affiliate_Id   = userid,
                 
            }
        };

        _context.Users.Add(user);

       return await _context.SaveChangesAsync();
    }

    // // ✅ Get all customers who signed up using a specific affiliate's referral ID
    // [HttpGet("{affId}/customers")]
    // public async Task<ActionResult<IEnumerable<Customer>>> GetReferredCustomers(string affId)
    // {
    //     var customers = await _context.Customers
    //         .Where(c => c.AffId == affId) // Customers linked to this affiliate
    //         .Include(c => c.Shops)        // ✅ Include their shops
    //         .ToListAsync();

    //     if (!customers.Any())
    //         return NotFound(new { message = "No customers found for this affiliate." });

    //     return customers;
    // }

    //get the shops 

    // [HttpGet("{affId}/shops")]
    // public async Task<ActionResult<IEnumerable<Shop>>> GetShopsForAffiliateCustomers(string affId)
    // {
    //     var shops = await _context.Shops
    //         .Where(s => s.Customer != null && s.Customer.AffId == affId) // ✅ Filter shops via customer
    //         .ToListAsync();

    //     if (!shops.Any())
    //         return NotFound(new { message = "No shops found for this affiliate's customers." });

    //     return Ok(shops);
    // }

//    

}