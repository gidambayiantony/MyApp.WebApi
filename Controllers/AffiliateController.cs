using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.WebApi.Models;

[Route("api/[controller]")]
[ApiController]
public class AffiliateController : ControllerBase
{
    private readonly AppDbContext _context;

    public AffiliateController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Affiliate>>> GetAffiliates()
    {
        return await _context.Affiliates.Include(a => a.Customers).Include(a => a.Shops).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Affiliate>> GetAffiliate(int id)
    {
        var affiliate = await _context.Affiliates.Include(a => a.Customers).Include(a => a.Shops)
                                                 .FirstOrDefaultAsync(a => a.Id == id);
        if (affiliate == null)
            return NotFound();

        return affiliate;
    }

    [HttpPost]
    public async Task<ActionResult<Affiliate>> CreateAffiliate(Affiliate affiliate)
    {
        _context.Affiliates.Add(affiliate);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAffiliate), new { id = affiliate.Id }, affiliate);
    }
}
