using System;
using System.Collections.Generic;
using System.Text;
using WNRY.Core.Data.Interfaces;
using WNRY.Models.ViewModels;
using WNRY.Services.Interfaces;

namespace WNRY.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductsRepository _productsRepository;
        public ProductService(IProductsRepository productRepository)
        {
            _productsRepository = productRepository;
        }


        public IEnumerable<ProductVM> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
