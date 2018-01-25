using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PokedexCore.Manual.Models;
using PokedexCore.Manual.Models.ViewModels;
using AutoMapper;
using PokedexCore.Manual.Data;
using PokedexCore.Manual.Helpers;

namespace PokedexCore.Manual.Controllers
{
    [Route( "api/[controller]" )]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager, ApplicationDbContext dbContext, IMapper mapper) {
            _userManager = userManager;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // api/Account
        [HttpPost]
        public async Task<IActionResult> Post( [FromBody] RegistrationViewModel model ) {
            if ( !ModelState.IsValid ) {
                return BadRequest(ModelState);
            }

            AppUser userIdentity = _mapper.Map<AppUser>(model);

            IdentityResult identityResult = await _userManager.CreateAsync(userIdentity, model.Password);

            if ( !identityResult.Succeeded ) {
                return new BadRequestObjectResult(Errors.AddErrorsToModelState( identityResult, ModelState));
            }

            await _dbContext.Customers.AddAsync(new Customer() {
                IdentityId = userIdentity.Id
            } );

            await _dbContext.SaveChangesAsync();

            return new OkObjectResult("Account Created");
        }
    }
}