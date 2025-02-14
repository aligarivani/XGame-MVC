using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XGame.Entity;

namespace XGame.Controllers
{
    [Authorize ( Roles = "Admin" )]
    public class AdminPanel : Controller
    {
        private readonly DataContext.DataContext _dataContext;

        public AdminPanel (DataContext.DataContext _dataContext)
        {
            this._dataContext = _dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> ShowCategory ( )
        {
            List<CategoryEntity> categories = await _dataContext.Categories.ToListAsync ();
            ViewBag.cate = categories;
            ViewBag.ShowFooter = false;
            return View ( "ShowCategory", ViewBag.cate );
        }
    }
}
