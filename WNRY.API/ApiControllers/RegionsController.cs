using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WNRY.Core.Data.Interfaces;
using WNRY.Models.CommonModels;
using WNRY.Models.ViewModels;

namespace WNRY.API.ApiControllers
{
    [Route("api/regions")]
    public class RegionsController : Controller
    {
        private IRegionRepository repository;

        public RegionsController(IRegionRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet()]
        public IActionResult All()
        {
            IEnumerable<Region> regions = this.repository.All();

            IEnumerable<RegionVM> result = AutoMapper.Mapper.Map<IEnumerable<RegionVM>>(regions);

            return this.Ok(result);
        }
    }
}
