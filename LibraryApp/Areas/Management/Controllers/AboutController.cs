using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MyBlog.Web.Models;

namespace LibraryApp.Areas.Management.Controllers
{
    [Area("Management")]
    public class AboutController : Controller
    {
        LibraryContext db = new LibraryContext();
        public IActionResult Index()
        {
            var model = db.Abouts.FirstOrDefault();
            return View();
        }

        public IActionResult Edit(int id)
        {
            var model = db.Abouts.Find(id);
            if (model == null)
            {
                return Redirect("/Management/About/Index");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(About model, IFormFile img)
        {
            if (ModelState.IsValid)
            {
                var editModel = db.Abouts.Find(model.Id);
                if (editModel == null)
                {
                    return Redirect("/Management/About/Index");
                }

                editModel.Title = model.Title;
                editModel.Description = model.Description;
                db.SaveChanges();
                return Redirect("/Management/About/Index");
            }
            return View(model);
        }
    }
}


