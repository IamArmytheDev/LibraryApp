using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Models;

namespace LibraryApp.Areas.Management.Controllers
{
    [Area("Management")]
    public class BookController : Controller
    {
        LibraryContext db = new LibraryContext();
        public IActionResult Index()
        {
            IEnumerable<Book> model = db.Books.Where(c => c.Status == true).ToList(); ;
            return View(model);
        }

        public IActionResult Details(int id)
        {
            Book? model = db.Books.Find(id);
            if (model == null)
            {
                return Redirect("/Management/Book/Index");
            }
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book model)
        {
            if (ModelState.IsValid)
            {
                model.Status = true;
                db.Books.Add(model);
                db.SaveChanges();
                return Redirect("/Management/Book/Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Book? model = db.Books.Find(id);
            if (model == null)
            {
                return Redirect("/Management/Book/Index");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Book model)
        {
            if (ModelState.IsValid)
            {
                Book? editModel = db.Books.Find(model.Id);
                if (editModel == null)
                {
                    return Redirect("/Management/Book/Index");
                }

                editModel.Name = model.Name;
                editModel.Subject = model.Subject;
                editModel.Author = model.Author;
                editModel.Description = model.Description;
                db.SaveChanges();
                return Redirect("/Management/Book/Index");

            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            Book? model = db.Books.Find(id);
            if (model == null)
            {
                return Redirect("/Management/Book/Index");
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Book? model = db.Books.Find(id);
            if (model == null)
            {
                return Redirect("/Management/Book/Index");
            }
            //soft delete (yazılımda silindi olarak göstermek) için
            model.Status = false;
            db.SaveChanges();

            //dbden tamamen silmek için
            //db.Books.Remove(model);
            //db.SaveChanges();

            return Redirect("/Management/Book/Index");
        }
    }
}
