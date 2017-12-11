using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PokedexCore.Models;

namespace PokedexCore.Controllers.Api {
    public class BaseApiController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        protected string UserName
        {
            get
            {
                return _userManager.GetUserName( HttpContext.User );
            }
        }
        public BaseApiController( UserManager<ApplicationUser> userManager ) {
            _userManager = userManager;
        }
    }
}