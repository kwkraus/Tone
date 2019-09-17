using Microsoft.AspNetCore.Mvc;
using Tone.LibraryManagement.Core.Services;

namespace Tone.LibraryManagement.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IFileStorageService _fileSvc;

        public BooksController(IFileStorageService fileSvc)
        {
            _fileSvc = fileSvc;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}