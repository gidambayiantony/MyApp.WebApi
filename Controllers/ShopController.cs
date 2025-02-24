using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.WebApi.Models;
[Route("api/[controller]")]
[ApiController]
public class ShopController : ControllerBase
{
    private readonly AppDbContext _context;

    public ShopController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Shop>>> GetShops()
    {
        return await _context.Shops.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Shop>> CreateShop(Shop shop)
    {
        _context.Shops.Add(shop);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetShops), new { id = shop.ShopId }, shop);
    }
}
