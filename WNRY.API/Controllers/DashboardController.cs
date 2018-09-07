using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WNRY.Core.Data;
using WNRY.Models.IdentityModels;

namespace WNRY.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Policy = "ApiUser")]
    public class DashboardController : Controller
    {
        private readonly ClaimsPrincipal _caller;

        public DashboardController(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
        }

        // GET api/dashboard/home
        [HttpGet]
        public async Task<IActionResult> Home()
        {
            // retrieve the user info
            //HttpContext.User
            var userId = _caller.Claims.Single(c => c.Type == "id");

            return new OkObjectResult("Success!");
        }
    }
}