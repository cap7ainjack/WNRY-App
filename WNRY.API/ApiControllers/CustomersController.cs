using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WNRY.Core.Data;
using WNRY.Core.Data.Interfaces;
using WNRY.Models.IdentityModels;
using WNRY.Models.ViewModels;

namespace WNRY.API.ApiControllers
{
    public class CustomersController : Controller // TODO: Admin only
    {
        private IRepository<Customer> repository;

        public CustomersController(IRepository<Customer> repository)
        {
            this.repository = repository;
        }

        //[HttpGet]
        //public IActionResult All()
        //{
        //    var todoItems = this.repository.All().To<CustomerVM>().ToList();

        //    return this.Ok(todoItems);
        //}
    }
}
