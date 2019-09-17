using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tone.LibraryManagement.Web.Models;

namespace Tone.LibraryManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var client = new TelemetryClient();

            client.TrackEvent("This is an event from the telemetry client for my demo with Tamar Zamba");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
