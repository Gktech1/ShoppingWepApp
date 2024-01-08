using Microsoft.AspNetCore.Mvc;
using Shopping.API.Data;
using Shopping.API.Models;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
            private readonly ILogger<ProductController> _logger;

            public ProductController(ILogger<ProductController> logger)
            {
                _logger = logger;
            }


        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> Get()
        {
           var products = ProductContext.Products;
            return products;
        }
        
       /* [HttpGet(Name = "GetProducts")]
            public IEnumerable<Product> Get()
            {
                return Enumerable.Range(1, 5).Select(index => new Product
                {
                    Name = "gkt"
                })
                .ToArray();
            }*/
        
    }
}

