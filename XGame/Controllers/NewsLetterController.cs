using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XGame.Entity;
using XGame.Models;

namespace XGame.Controllers
{
    public class NewsLetterController : Controller
    {
        private readonly DataContext.DataContext _dbContext;

        public NewsLetterController (DataContext.DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> EmailSubmit (NewsletterDTO newsletter)
        {
            if (ModelState.IsValid)
            {
                NewsletterEntity data = new NewsletterEntity ();
                var data1 = await _dbContext.Newsletter.Where
                   ( option => option.Email == newsletter.Email ).FirstOrDefaultAsync ();
                if (data.Email == null)
                {
                    data.Email = newsletter.Email;
                    try
                    {
                        await _dbContext.Newsletter.AddAsync ( data );
                        await _dbContext.SaveChangesAsync ();
                    }
                    catch (DbUpdateException ex)
                    {
                        ModelState.AddModelError ( "", "Error Update DB" );
                        return RedirectToAction ( "Contact", "Home" );
                    }
                }
            }
            return RedirectToAction ( "Index", "Home" );
        }
    }
}
