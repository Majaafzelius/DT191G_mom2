using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using uppgift1.Models;

namespace uppgift1.Controllers
{
    public class DataController : Controller
    {
        private readonly ILogger<DataController> _logger;

        public DataController(ILogger<DataController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult About()
        {
            List<SongModel> songModels = new List<SongModel>()
            {
                new SongModel {Name="Is it over now?", Artist="Taylor Swift", Album="1989(Taylors Version)"}
            };
            AboutModel aboutModel = new AboutModel();
            aboutModel.First_Name = "Maja";
            aboutModel.Last_Name = "Afzelius";
            aboutModel.Age = 23;
            aboutModel.Songs = songModels;
            return View(aboutModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}