using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using uppgift1.Models;

namespace uppgift1.Controllers
{
    public class SongController : Controller
    {
        [HttpGet]
        public IActionResult AddSong()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddSong(SongModel sm)
        {
            HttpContext.Response.Cookies.Append("user_id", "1");
            string s = JsonConvert.SerializeObject(sm);
            HttpContext.Session.SetString("mySession", s);
            return RedirectToAction("ViewSong");
        }
        [HttpGet]
        public IActionResult ViewSong()
        {
            var userId = HttpContext.Request.Cookies["user_id"];
            ViewBag.cookiecontent = userId;
            ViewBag.sessioncontent = HttpContext.Session.GetString("mySession");

            SongModel sm = new SongModel();
            string jsonstring = HttpContext.Session.GetString("mySession");

            if (string.IsNullOrEmpty(jsonstring))
            {
                 return RedirectToAction("AddSong");
            }
            sm = JsonConvert.DeserializeObject<SongModel>(jsonstring);
            if (sm == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.jsonstring = jsonstring;
            return View(sm);

        }
    }
}
