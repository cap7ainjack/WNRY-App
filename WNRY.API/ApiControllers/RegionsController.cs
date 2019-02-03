using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WNRY.Core.Data.Interfaces;
using WNRY.Models.CommonModels;
using WNRY.Models.ViewModels;
using WNRY.Services.Interfaces;

namespace WNRY.API.ApiControllers
{
    [Route("api/regions")]
    public class RegionsController : Controller
    {
        private IRegionService regionService;

        public RegionsController(IRegionService regionService)
        {
            this.regionService = regionService;
        }

        [HttpGet()]
        public IActionResult All()
        {
            IEnumerable<RegionVM> result = this.regionService.GetAll();

            return this.Ok(result);
        }
    }
}
