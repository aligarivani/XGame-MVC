using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace XGame.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index ( )
        {
            return View ( "Index" );
        }

        [HttpGet ( "Contact" )]
        public async Task<IActionResult> Contact ( )
        {
            return View ( "Contact" );
        }

        [HttpGet]
        public async Task<IActionResult> Shop ( )
        {
            return View ();
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetails ( )
        {
            return View ();
        }
    }
}
