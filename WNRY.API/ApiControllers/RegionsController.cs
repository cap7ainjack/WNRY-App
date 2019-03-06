using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WNRY.Models.ViewModels.Common;
using WNRY.Services.Interfaces;

namespace WNRY.API.ApiControllers
{
    [Route("api/regions")]
    public class RegionsController : Controller
    {
        private readonly IRegionService regionService;

        public RegionsController(IRegionService regionService)
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
