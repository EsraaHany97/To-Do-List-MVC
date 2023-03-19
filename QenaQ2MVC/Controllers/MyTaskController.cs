using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QenaQ2MVC.Models;

namespace QenaQ2MVC.Controllers
{
    public class MyTaskController : Controller
    {
        LibraryContext db = new LibraryContext();


        public async Task<ActionResult> GetTasks()
        {

            //var Tasks = db.MyTasks.ToList();
            //return View("GetTasks", Tasks);
            IQueryable<MyTask> items = from i in db.MyTasks orderby i.ID select i;

            List<MyTask> Tasks = await items.ToListAsync();

            return View(Tasks);
        }

        

        //GET /todo/create
        public IActionResult Create() => View();

        // POST /todo/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MyTask item)
        {
            if (ModelState.IsValid)
            {
                db.Add(item);
                await db.SaveChangesAsync();

                TempData["Success"] = "The item has been added!";

                return RedirectToAction("GetTasks");
            }

            return View(item);

        }

        // GET /todo/edit/5
        public async Task<ActionResult> Edit(int id)
        {
            MyTask item = await db.MyTasks.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);

        }

        // POST /todo/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MyTask item)
        {
            if (ModelState.IsValid)
            {
                db.Update(item);
                await db.SaveChangesAsync();

                TempData["Success"] = "The item has been updated!";

                return RedirectToAction("GetTasks");
            }

            return View(item);
        }

        // GET /todo/delete/5
        public async Task<ActionResult> Delete(int id)
        {
            MyTask item = await db.MyTasks.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "The item does not exist!";
            }
            else
            {
                db.MyTasks.Remove(item);
                await db.SaveChangesAsync();

                TempData["Success"] = "The item has been deleted!";
            }

            return RedirectToAction("GetTasks");
        }

        // GET /todo/search/5
        public async Task<ActionResult> GetSearchTasks(string searchbox)
        {

            
            IQueryable<MyTask> items = from i in db.MyTasks  select i ;
            if (!string.IsNullOrEmpty(searchbox))
            {
                items=items.Where(t=>t.Name.Contains(searchbox));
            }

            

            return View(items.ToList());
        }
        public async Task<ActionResult> GetDetails(int id)
        {


            IQueryable<MyTask> items = from i in db.MyTasks select i;
           
           
                items = items.Where(t => t.ID==id);
            



            return View(items.ToList());
        }

        public async Task<ActionResult> GetFilterTasks(string statusfil)
        {


            IQueryable<MyTask> items = from i in db.MyTasks select i;
            if (!string.IsNullOrEmpty(statusfil))
            {
                
                items = items.Where(t => t.Status.Contains(statusfil));
            }



            return View(items.ToList());
        }




    }
}
