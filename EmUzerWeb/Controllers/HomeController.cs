using System.Web.Mvc;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web;
using EmUzerWeb.Models;
using System;

namespace EmUzerWeb.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        SpotifyWebAPI _spotify = new SpotifyWebAPI();
        AccountSpotifyModel _spotifyAccount = new AccountSpotifyModel();
        SimpleTrack _spotTrack = new SimpleTrack();


        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            

            return View();
        }


        public ActionResult Scanner()
        {
            _spotifyAccount.savedTracks = _spotify.GetSavedTracks(40, 0, "");
            foreach(var track in _spotifyAccount.savedTracks.Items)
            {
                if (_spotify.GetAudioFeatures(track.Track.Id).Acousticness > 0.6)
                {
                    _spotifyAccount.currentPlaylist.Add(track.Track);
                }
            }

            return View(_spotifyAccount);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}