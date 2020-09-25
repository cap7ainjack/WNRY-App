using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WNRY.Models.ViewModels;
using WNRY.Services.Interfaces;

namespace WNRY.API.ApiControllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productsService;

        public ProductsController(IProductService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet()]
        public IActionResult All()
        {
            IEnumerable<ProductVM> result = this.productsService.GetAll();
            return this.Ok(result);
        }
    }
}