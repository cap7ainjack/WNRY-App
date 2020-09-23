using System;
using System.Collections.Generic;
using System.Text;
using WNRY.Models.CommonModels;

namespace WNRY.Core.Data.Interfaces
{
    public interface IProductsRepository : IDisposable
    {
        IEnumerable<Product> All();
    }
}
