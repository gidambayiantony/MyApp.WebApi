using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Affiliate>>> GetAffiliates()
    {
        return await _context.Affiliates.Include(a => a.Customers).ThenInclude(c => c.Shops).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Affiliate>> GetAffiliate(string id)
    {
        var affiliate = await _context.Affiliates.Include(a => a.Customers).ThenInclude(c => c.Shops)
                                                 .FirstOrDefaultAsync(a => a.Id == id);
        if (affiliate == null)
            return NotFound(new { message = "Affiliate not found" });

        return affiliate;
    }
    //create an affiliate with autogen id
    [HttpPost]
    public async Task<ActionResult<Affiliate>> CreateAffiliate(Affiliate affiliate)
    {
        AffiliateCounter++;
        affiliate.Id = $"AF{AffiliateCounter}";
        _context.Affiliates.Add(affiliate);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAffiliate), new { id = affiliate.Id }, affiliate);
    }
    // ✅ Get all customers who signed up using a specific affiliate's referral ID
    [HttpGet("{affId}/customers")]
    public async Task<ActionResult<IEnumerable<Customer>>> GetReferredCustomers(string affId)
    {
        var customers = await _context.Customers
            .Where(c => c.AffId == affId) // Customers linked to this affiliate
            .Include(c => c.Shops)        // ✅ Include their shops
            .ToListAsync();

        if (!customers.Any())
            return NotFound(new { message = "No customers found for this affiliate." });

        return customers;
    }

    //get the shops 

    [HttpGet("{affId}/shops")]
    public async Task<ActionResult<IEnumerable<Shop>>> GetShopsForAffiliateCustomers(string affId)
    {
        var shops = await _context.Shops
            .Where(s => s.Customer != null && s.Customer.AffId == affId) // ✅ Filter shops via customer
            .ToListAsync();

        if (!shops.Any())
            return NotFound(new { message = "No shops found for this affiliate's customers." });

        return Ok(shops);
    }

}
