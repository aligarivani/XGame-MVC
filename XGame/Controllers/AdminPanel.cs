using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XGame.Entity;
using XGame.Models;

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

        [HttpPost]
        public async Task<IActionResult> ShowCategory (CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                CategoryEntity data = new CategoryEntity ();
                data.Title = category.Title;
                data.TitleFarsi = category.TitleFarsi;
                data.Description = category.Description;
                try
                {
                    await _dataContext.Categories.AddAsync ( data );
                    await _dataContext.SaveChangesAsync ();

                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError ( "", "Erorr Update DB" );
                    return View ( "ShowCategory" );
                }
            }
            return View ( "ShowCategory" );
        }
    }
}
