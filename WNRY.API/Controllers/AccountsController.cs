using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WNRY.Core.Data;
using WNRY.Models.IdentityModels;
using WNRY.Models.ViewModels;
using WNRY.Services.Utils;

namespace WNRY.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
        private readonly WnryDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        // private readonly IMapper _mapper;

        public AccountsController(UserManager<AppUser> userManager, WnryDbContext appDbContext)
        {
            _userManager = userManager;
            // _mapper = mapper;
            _appDbContext = appDbContext;
        }


        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // var userIdentity = _mapper.Map<AppUser>(model);
            AppUser userIdentity = AccountsHelper.ConvertToDbObj(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            // await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");
        }
    }
}