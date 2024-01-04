using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Web.Models;

namespace LibraryApp.Areas.Management.Controllers
{
	public class CategoryController : Controller
	{
		LibraryContext db = new LibraryContext();
		public IActionResult Index()
		{
			var model = db.Categories.FirstOrDefault();
			return View();
		}
		public IActionResult Details(int id)
		{
			Category? model = db.Categories.Find(id);
			if (model == null)
			{
				return Redirect("/Management/Category/Index");
			}
			return View(model);
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Category model)
		{
			if (ModelState.IsValid)
			{
				db.Categories.Add(model);
				db.SaveChanges();
				return Redirect("/Management/Category/Index");
			}
			return View(model);
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			Category? model = db.Categories.Find(id);
			if (model == null)
			{
				return Redirect("/Management/Category/Index");
			}
			return View(model);
		}
		[HttpPost]
		public IActionResult Edit(Category model)
		{
			if (ModelState.IsValid)
			{
				Category? editModel = db.Categories.Find(model.Id);
				if (editModel == null)
				{
					return Redirect("/Management/Category/Index");
				}

				editModel.Name = model.Name;
				editModel.Description = model.Description;
				db.SaveChanges();
				return Redirect("/Management/Category/Index");

			}
			return View(model);
		}
		public IActionResult Delete(int id)
		{
			Category? model = db.Categories.Find(id);
			if (model == null)
			{
				return Redirect("/Management/Category/Index");
			}
			return View(model);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			Category? model = db.Categories.Find(id);
			if (model == null)
			{
				return Redirect("/Management/Category/Index");
			}
			//soft delete (yazılımda silindi olarak göstermek) için
			db.SaveChanges();

			//dbden tamamen silmek için
			//db.Categories.Remove(model);
			//db.SaveChanges();

			return Redirect("/Management/Category/Index");
		}
	}
}
