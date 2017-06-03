using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpotifyAPI.Local.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;


namespace EmUzerWeb.Controllers.Spotify
{
    public class PlaylistController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sad()
        { 
            SpotifyWebAPI spotify = new SpotifyWebAPI
            {
                UseAuth = true,
                AccessToken = Session["SpotifyToken"].ToString(),
                TokenType = "Bearer",
            };

            var recommendedSongs = spotify.GetRecommendations(
                new List<string>(){ "5VnYwYnG7QmpzQtxyubIwh" }, 
                new List<string>(){ "slowcore" }, 
                new List<string>(){ "25ia1zWRMAwPpA2LsHwPv2" }, 
                null, null, null, 50, "BG");

            var seededTracksUris = new List<string>();
            recommendedSongs.Tracks.ForEach(item => seededTracksUris.Add(item.Uri));

            var playlist = spotify.CreatePlaylist(this.Session["UserId"].ToString(), "SadTest");
            spotify.FollowPlaylist(this.Session["UserId"].ToString(), playlist.Id);
            spotify.AddPlaylistTracks(this.Session["UserId"].ToString(), playlist.Id, seededTracksUris);

            return View();
        }
    }
}