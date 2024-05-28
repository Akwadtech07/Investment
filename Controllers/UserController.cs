using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using New_folder.Models.Dtos;
using New_folder.Services.Interfaces;

namespace New_folder.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InvestorBoard()
        {
            return View();
        }
        [HttpGet]
        public  IActionResult SuperBoard()
        {
            //var superadmin = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var supe = await _userService.GetUser(superadmin);
            return View();
        }
        //public async Task<IActionResult> Login(LoginRequestModel model)
        //{
        //    var user = await _userService.Login(model);

        //    if (user.Data != null)
        //    {
        //        var claims = new List<Claim>
        //        {

        //             new Claim(ClaimTypes.NameIdentifier, user.Data.Id.ToString()),
        //             new Claim(ClaimTypes.Email, user.Data.Email),
        //             new Claim(ClaimTypes.Name, user.Data.FirstName + " " + user.Data.LastName),
        //             new Claim(ClaimTypes.Role, user.Data.Role),
        //             new Claim("Image", user.Data.Image),

        //        };

        //        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //        var principal = new ClaimsPrincipal(identity);
        //        var properties = new AuthenticationProperties();

        //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);
        //        if (user.Success == true)
        //        {
        //            if (user.Data.Role == "SuperAdmin")
        //            {
        //                TempData["Success"] = "Login sucessful";
        //                return RedirectToAction("SuperBoard");
        //            }
        //            else if (user.Data.Role == "Broker")
        //            {

        //                TempData["Success"] = "Welcome";
        //                return RedirectToAction("BrokerBoard");
        //            }
        //            else if (user.Data.Role == "Investor")
        //            {

        //                TempData["Success"] = "Welcome";
        //                return RedirectToAction("InvestorBoard");
        //            }
        //        }
        //        else
        //        {

        //            TempData["Fail"] = "Username Or Password Not Correct";
        //            return View();
        //        }
        //    }
        //    TempData["Fail"] = "Invalid Credentials pls try again with correct details!";
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
