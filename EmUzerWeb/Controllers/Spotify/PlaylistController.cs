using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;


namespace EmUzerWeb.Controllers.Spotify
{
    public class PlaylistController : Controller
    {
        private static SpotifyWebAPI _spotify;

        // GET: Playlist
        public ActionResult Sad()
        {
            //if (Session["Emotion"] == null)
            //{
            //    return View("Error");
            //}
            //else
            //{
            //    var tracksList = _spotify.GetRecommendations(trackSeed:)
            //}
            return View();
        }
    }
}