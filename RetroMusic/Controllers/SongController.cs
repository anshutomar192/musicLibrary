using RetroMusic.BAL.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetroMusic.Controllers
{
    public class SongController : Controller
    {
        // GET: Songs
        public ActionResult Songs()
        {
            return View("Songs");
        }
        public ActionResult GetLibraries()
        {
            List<RetroMusic.BOL.Model.Song> songList = new SongBuilder().GetLibraries();
            return Json(new { data = songList }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetLibraryDetail(int songId)
        {
            RetroMusic.BOL.Model.Song songDetail = new SongBuilder().GetLibraryDetail(songId);
            return View("SongDetail", songDetail);
        }

        [HttpPost]
        public ActionResult UpdatePurchase(string songName, string email)
        {
            new SongBuilder().UpdatePurchase(songName, email);
            return RedirectToAction("Index","Home", new { area = "" });
        }



    }
}