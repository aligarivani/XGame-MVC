using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace XGame.Controllers
{
    [Authorize ( Roles = "Admin" )]
    public class AdminPanel : Controller
    {
        [HttpGet]
        public async Task<IActionResult> AddCategory ( )
        {
            ViewBag.ShowFooter = false;
            return View ( "AddCategory" );
        }
    }
}
