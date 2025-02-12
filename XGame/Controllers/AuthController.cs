using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using XGame.Entity;
using XGame.Models;

namespace XGame.Controllers
{
    public class AuthController : Controller
    {
        private readonly DataContext.DataContext _dbContext;

        public AuthController (DataContext.DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Login ( )
        {
            ViewBag.ShowFooter = false;
            return View ( "Login" );
        }

        [HttpPost]
        public async Task<IActionResult> Login (UserLoginDTO userLogin)
        {
            if (ModelState.IsValid)
            {
                var data = await _dbContext.Users.Where ( x => (x.UserName == userLogin.UserNameOrEmail || x.Email == userLogin.UserNameOrEmail) && x.Password == userLogin.Password ).FirstOrDefaultAsync ();
                if (data != null)
                {

                    var Climes = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,data.UserName),
                        new Claim(ClaimTypes.Role,"User")
                    };
                    var identity = new ClaimsIdentity ( Climes, CookieAuthenticationDefaults.AuthenticationScheme );
                    var claimPerincipal = new ClaimsPrincipal ( identity );
                    await HttpContext.SignInAsync ( CookieAuthenticationDefaults.AuthenticationScheme, claimPerincipal, new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTimeOffset.UtcNow.AddDays ( 7 ) } );
                    return RedirectToAction ( "Index", "Home" );
                }
            }
            return View ( userLogin );
        }

        [HttpGet]
        public async Task<IActionResult> Register ( )
        {
            ViewBag.ShowFooter = false;
            return View ( "Register" );
        }

        [HttpPost]
        public async Task<IActionResult> Register (UserDTO user)
        {
            ViewBag.ShowFooter = false;
            UserEntity data = new UserEntity ();
            if (ModelState.IsValid)
            {
                data.UserName = user.UserName;
                data.FullName = user.FullName;
                data.Email = user.Email;
                data.PhoneNumber = user.PhoneNumber;
                data.Password = user.Password;

                try
                {
                    await _dbContext.AddAsync ( data );
                    await _dbContext.SaveChangesAsync ();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError ( "", "Erorr DataBase" );
                    return RedirectToAction ( "Register" );

                }

                return RedirectToAction ( "Login" );
            }
            return View ( user );
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout ( )
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync ( CookieAuthenticationDefaults.AuthenticationScheme );
                return RedirectToAction ( "Login", "Auth" );
            }

            return RedirectToAction ( "Index", "Home" );
        }
    }
}
