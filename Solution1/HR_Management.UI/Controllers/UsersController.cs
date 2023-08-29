using HR_Management.UI.Contracts;
using HR_Management.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.UI.Controllers
{

    public class UsersController : Controller
    {
        #region Constructor

        private readonly IAuthenticateService _authenticateService;

        public UsersController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }


        #endregion


        #region Register

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Registration Failed!");
                return View(register);
            }

            var isCreated = await _authenticateService.Register(register);
            if (isCreated)
            {
                return LocalRedirect("/");
            }
            ModelState.AddModelError("", "Registration Failed!");
            return View(register);
        }

        #endregion

        #region Login

        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVm, string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            var isLoggedIn = await _authenticateService.Authenticate(loginVm.Email, loginVm.Password);

            if (isLoggedIn)
            {
                return LocalRedirect(returnUrl);
            }
            ModelState.AddModelError("", "Login Failed");
            return View(loginVm);
        }

        #endregion

        #region Logout

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _authenticateService.Logout();
            return LocalRedirect("/Users/login");
        }

        #endregion



    }
}
