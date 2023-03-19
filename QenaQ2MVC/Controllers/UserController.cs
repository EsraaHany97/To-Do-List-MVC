using Microsoft.AspNetCore.Mvc;
using QenaQ2MVC.Models;

namespace QenaQ2MVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult GetUser()
        {
            LibraryContext db = new LibraryContext();
            var Users = db.Users.ToList();
            return View("GetUser", Users);
        }
    }
}
