using EmilyJonesBackend.Data;
using EmilyJonesBackend.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmilyJonesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ProductController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var furniture = await _dataContext.Furnitures.ToListAsync();

            return Ok(furniture);


            //  Id = 1,
            //  Name = "Cloud Couch",
            //  Description = "White Luxury four seat couch",
            //  Category = "Couch",
            //Price = 99.99M,
            //  ImageUrl = "https://d1jd0gutdomqkp.cloudfront.net/thumbnails/products/0200199_001_dahgwd_0697b73f_thumbnail_1024.webp"


        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var furniture = await _dataContext.Furnitures.FindAsync(id);
            if(furniture is null)
            {
                return BadRequest("Product Not Found");
            }

            return Ok(furniture);

        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
             _dataContext.Furnitures.Add(product);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Furnitures.ToListAsync());

        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product product)
        {
            var furniture = await _dataContext.Furnitures.FindAsync(product.Id);
            if (furniture is null)
            {
                return BadRequest("Product Not Found");
            }

            furniture.Name = product.Name;
            furniture.Description = product.Description;
            furniture.Price = product.Price;
            furniture.ImageUrl = product.ImageUrl;
            furniture.Category = product.Category;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Furnitures.ToListAsync());

        }

        [HttpDelete]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var furniture = await _dataContext.Furnitures.FindAsync(id);
            if (furniture is null)
            {
                return BadRequest("Product Not Found");
            }

            _dataContext.Furnitures.Remove(furniture);

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Furnitures.ToListAsync());

        }
    }
}
