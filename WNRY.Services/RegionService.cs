using System.Collections.Generic;
using System.Linq;
using WNRY.Core.Data.Interfaces;
using WNRY.Models.CommonModels;
using WNRY.Models.ViewModels.Common;
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

        public IEnumerable<TextAndValueBox> GetAll()
        {
            IEnumerable<Region> regions = _regionRepository.All();

            IEnumerable<TextAndValueBox> result = this.ConvertAllToVms(regions);

            return result;
        }

        private IEnumerable<TextAndValueBox> ConvertAllToVms(IEnumerable<Region> regions)
        {
            IEnumerable<TextAndValueBox> result = regions.Select(z => new TextAndValueBox()
            {
                Text = z.Name,
                Value = z.Id
            });

            return result;
        }
    }
}
