using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using WNRY.Models.ViewModels;
using WNRY.Models.ViewModels.Common;
using WNRY.Services.Interfaces;

namespace WNRY.API.ApiControllers
{
    [Route("api/Order")]
    public class PlaceOrderController : Controller
    {
        private readonly IPlaceOrderService placeOrderService;

        public PlaceOrderController(IPlaceOrderService placeOrderService)
        {
            this.placeOrderService = placeOrderService;
        }

        [HttpGet()]
        public IActionResult All()
        {
            // IEnumerable<TextAndValueBox> result = this.placeOrderService.GetAll();

            return this.Ok();
        }

        [HttpPost]
        public IActionResult Order([FromBody]PlaceOrderVM vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.ValidationState);
            }

            bool result = this.placeOrderService.PlaceOrder(vm);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
