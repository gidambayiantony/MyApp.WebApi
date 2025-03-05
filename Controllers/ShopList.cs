using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.WebApi;
using MyApp.WebApi.DTO.Requests;
using MyApp.WebApi.Models;

[Route("api/[controller]")]
public class ShopListController : ControllerBase{
 
 private readonly AppDbContext _context;
public ShopListController(AppDbContext context)
{
    _context = context;

}
//get all shops
[HttpGet("GetShopList")]
public async Task<ActionResult> GetShops(string userid)
{
    var shoplist = await _context.Shops.Where(a => a.Ownerid == userid).ToListAsync();
    // return await _context.Shops.ToListAsync();

    List<ShopListResponse> shopListResponses = new List<ShopListResponse>();    

    foreach (var shop in shoplist)
    {
        ShopListResponse shopListResponse = new ShopListResponse();
        shopListResponse.Shop_Id = shop.Shopid;
        shopListResponse.ShopName = shop.Name;
        shopListResponse.Id = shop.Id;
        shopListResponse.Datejoined = shop.Datejoined;
        shopListResponse.Lastseen = shop.Lastseen;
        // shopListResponse.ShopDescription = shop.Shopdescription;
        shopListResponse.CountryCode = shop.CountryCode;
        // shopListResponse.OwnerId = shop.Ownerid;
        // shopListResponse.CreatedOn = shop.Createdon;
        // shopListResponse.ShopType = shop.Shoptype;
        // shopListResponse.ShopCategory = shop.Shopcategory;

        shopListResponses.Add(shopListResponse);
         

}

return Ok(shopListResponses);

}}