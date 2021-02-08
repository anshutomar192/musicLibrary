using RetroMusic.BAL.Song;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetroMusic.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DataTable table = new SongBuilder().GetViewedLibraries();
            return View("Home",table);
        }
    }
}