using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using QenaQ2MVC.Models;

namespace QenaQ2MVC.Controllers
{
    public class CategoryTaskController : Controller
    {
        LibraryContext db = new LibraryContext();
        public async Task<ActionResult> GetCategories()
        {
          
            IQueryable<CategoryTask> items = from i in db.CategoryTasks orderby i.ID select i;

            List<CategoryTask> categories = await items.ToListAsync();

            return View(categories);

        }

        

        //GET /todo/create
        public IActionResult CreateCategory() => View();

        // POST /todo/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCategory(CategoryTask item)
        {
            if (ModelState.IsValid)
            {
                db.Add(item);
                await db.SaveChangesAsync();

                TempData["Success"] = "The item has been added!";

                return RedirectToAction("GetCategories");
            }

            return View(item);

        }

        // GET /todo/edit/5
        public async Task<ActionResult> EditCategory(int id)
        {
            CategoryTask item = await db.CategoryTasks.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);

        }

        // POST /todo/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditCategory(CategoryTask item)
        {
            if (ModelState.IsValid)
            {
                db.Update(item);
                await db.SaveChangesAsync();

                TempData["Success"] = "The item has been updated!";

                return RedirectToAction("GetCategories");
            }

            return View(item);
        }

        // GET /todo/delete/5
        public async Task<ActionResult> DeleteCategory(int id)
        {
            CategoryTask item = await db.CategoryTasks.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "The item does not exist!";
            }
            else
            {
                db.CategoryTasks.Remove(item);
                await db.SaveChangesAsync();

                TempData["Success"] = "The item has been deleted!";
            }

            return RedirectToAction("GetCategories");
        }

        // GET /todo/search/5
       
        public async Task<ActionResult> GetCategoryDetails(int id)
        {


            IQueryable<CategoryTask> items = from i in db.CategoryTasks select i;


            items = items.Where(t => t.ID == id);




            return View(items.ToList());
        }

    }
}
