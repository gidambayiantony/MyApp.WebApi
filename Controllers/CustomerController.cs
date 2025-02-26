using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.WebApi.Models;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly AppDbContext _context;

    public CustomerController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
    {
        return await _context.Customers.Include(c => c.Shops).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
    {
         if (!string.IsNullOrEmpty(customer.AffId))
    {
        var affiliate = await _context.Affiliates.FindAsync(customer.AffId);
        if (affiliate == null)
        {
            return BadRequest("Invalid Affiliate ID");
        }
    }
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return Ok(customer);
    }

    [HttpPost("{customerId}/shops")]
public async Task<ActionResult<Customer>> CreateShop(int customerId, [FromBody] Shop shop)
{
    var customer = await _context.Customers.Include(c => c.Shops).FirstOrDefaultAsync(c => c.Id == customerId);

    if (customer == null)
    {
        return NotFound("Customer not found");
    }

    // Add the shop to the customer's Shops list
    customer.Shops.Add(shop);
    
    // Save changes to the database
    await _context.SaveChangesAsync();

    return Ok(customer);
}

}
