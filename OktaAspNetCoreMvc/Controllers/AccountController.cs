using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Okta.Sdk;
using Okta.Sdk.Configuration;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace OktaAspNetCoreMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IOktaClient _oktaClient;

        public AccountController(IOktaClient oktaClient)
        {
            this._oktaClient = oktaClient;
        }

        public IActionResult Login()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge(OpenIdConnectDefaults.AuthenticationScheme);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return SignOut(CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme);
            }

            return RedirectToAction("Index", "Home");
        }    
     
        [Authorize]
        public IActionResult Claims()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Me()
        {
            var currentUserId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "preferred_username")?.Value.ToString();
            dynamic userInfoWrapper = null;

            if (!string.IsNullOrEmpty(currentUserId)) {
                var userInfo = await _oktaClient.Users.GetUserAsync(currentUserId);
                userInfoWrapper = new ExpandoObject();
                userInfoWrapper.Profile = userInfo.Profile;
                userInfoWrapper.LastLogin = userInfo.LastLogin;
                userInfoWrapper.Groups = await userInfo.Groups.ToList();
            }
            
            return View(userInfoWrapper);
        }
    }
}
