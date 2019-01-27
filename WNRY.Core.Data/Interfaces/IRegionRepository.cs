using System;
using System.Collections.Generic;
using WNRY.Models.CommonModels;

namespace WNRY.Core.Data.Interfaces
{
    public interface IRegionRepository : IDisposable
    {
        IEnumerable<Region> All();
    }
}
