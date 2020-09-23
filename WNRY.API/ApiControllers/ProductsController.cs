using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WNRY.Models.ViewModels.Common;
using WNRY.Services.Interfaces;

namespace WNRY.API.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRegionService regionService;

        public ProductsController(IRegionService regionService)
        {
            this.regionService = regionService;
        }

        [HttpGet()]
        public IActionResult All()
        {
            IEnumerable<TextAndValueBox> result = this.regionService.GetAll();

            return this.Ok(result);
        }
    }
}