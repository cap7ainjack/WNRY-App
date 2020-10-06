using System;
using System.Collections.Generic;
using System.Linq;
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
            var products = this._productsRepository
                .All()
                .Select(z => new ProductVM()
                {
                    Id = z.Id,
                    Price = z.Price,
                    PhotoUrl = z.PhotoUrl,
                    DisplayName = z.DisplayName,
                    WineColor = z.WineColor,
                    Description = z.Description,
                    Kind = z.Kind,
                    Size = z.Size
                });

            return products;
        }
    }
}
