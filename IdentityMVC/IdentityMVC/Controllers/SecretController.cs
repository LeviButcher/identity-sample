using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityMVC.Controllers
{

    public class SecretController : Controller
    {
        public SignInManager<IdentityUser> SignIn { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }
        public ILogger Logger { get; }

        public SecretController(SignInManager<IdentityUser> signIn, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<SecretController> logger)
        {
            SignIn = signIn;
            UserManager = userManager;
            RoleManager = roleManager;
            Logger = logger;
        }

        public IActionResult Phrase()
        {
            //Gives access to our User
            if (User.IsInRole("Alpha"))
            {
                Logger.LogDebug("User is in Alpha Role");
            }
            if (User.IsInRole("Beta"))
            {
                Logger.LogDebug("User is in Beta Role");
            }

            return View();
        }
    }
}
