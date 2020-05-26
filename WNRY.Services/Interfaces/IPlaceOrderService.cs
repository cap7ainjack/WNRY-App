
using WNRY.Models.ViewModels;

namespace WNRY.Services.Interfaces
{
    public interface IPlaceOrderService
    {
        bool PlaceOrder(PlaceOrderVM vm);
    }
}
