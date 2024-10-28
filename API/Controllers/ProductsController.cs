using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController :ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id){
            return Ok(await _context.Products.FindAsync(id));
        }

        
        [HttpPost]
        public async Task<IActionResult> insert(Product model){
            return Ok(await _context.Products.AddAsync(model));
        }
    }
}