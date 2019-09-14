using Microsoft.AspNetCore.Mvc;

namespace Tone.LibraryManagement.Web.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}