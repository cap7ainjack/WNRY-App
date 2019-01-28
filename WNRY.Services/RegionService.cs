using System.Collections.Generic;
using WNRY.Core.Data.Interfaces;
using WNRY.Models.CommonModels;
using WNRY.Models.ViewModels;
using WNRY.Services.Interfaces;

namespace WNRY.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public IEnumerable<RegionVM> GetAll()
        {
            IEnumerable<Region> regions = _regionRepository.All();

            IEnumerable<RegionVM> result = AutoMapper.Mapper.Map<IEnumerable<RegionVM>>(regions);

            return result;
        }
    }
}
