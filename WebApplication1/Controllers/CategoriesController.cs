using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public ViewResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }
        public ViewResult Create()
        {
            return View( new Category());
        }

        public IActionResult Add(Category request) {
            if (ModelState.IsValid)
            {
                context.Categories.Add(request);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create",request);
            }

        }
        public ViewResult Details(int id)
        {
            var category = context.Categories.Find(id);
            return View(category);
        }

        public IActionResult Delete(int id) {
            var category = context.Categories.Find(id);
            if(category is null)
            {
                return View("NotFound");
            }
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index"); 

        }
    }
}
