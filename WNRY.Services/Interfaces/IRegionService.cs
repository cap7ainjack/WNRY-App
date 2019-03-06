using System.Collections.Generic;
using WNRY.Models.ViewModels.Common;

namespace WNRY.Services.Interfaces
{
    public interface IRegionService
    {
        IEnumerable<TextAndValueBox> GetAll();
    }
}
