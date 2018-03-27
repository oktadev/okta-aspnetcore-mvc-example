using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Okta.Sdk;
using Okta.Sdk.Configuration;
using System.Dynamic;
using System.Linq;

namespace OktaAspNetCoreMvc.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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
        public async System.Threading.Tasks.Task<IActionResult> Me()
        {
           var oktaClient = new OktaClient(
                new OktaClientConfiguration()
                {
                    OrgUrl = Configuration["okta:OrgUrl"],
                    Token = Configuration["okta:APIToken"]
                });

            var currentUserId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "preferred_username")?.Value.ToString();
            dynamic userInfoWrapper = null;

            if (!string.IsNullOrEmpty(currentUserId)) {
                var userInfo = await oktaClient.Users.GetUserAsync(currentUserId);
                userInfoWrapper = new ExpandoObject();
                userInfoWrapper.Profile = userInfo.Profile;
                userInfoWrapper.LastLogin = userInfo.LastLogin;
                userInfoWrapper.Groups = await userInfo.Groups.ToList();
            }
            
            return View(userInfoWrapper);
        }
    }
}
