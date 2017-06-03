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

        public ActionResult Happiness() 
        {
            SpotifyWebAPI spotify = new SpotifyWebAPI
            {
                UseAuth = true,
                AccessToken = Session["SpotifyToken"].ToString(),
                TokenType = "Bearer",
            };

            var recommendedSongs = spotify.GetRecommendations(
                new List<string>() { "6OqhFYFJDnBBHas02HopPT" },
                new List<string>() { "pop", "dance" },
                new List<string>() { "3LuLUNgRmmgcr14dTIWH2S" },
                null, null, null, 50, "BG");

            var seededTracksUris = new List<string>();
            recommendedSongs.Tracks.ForEach(item => seededTracksUris.Add(item.Uri));

            var playlist = spotify.CreatePlaylist(this.Session["UserId"].ToString(), "SadTest");
            spotify.FollowPlaylist(this.Session["UserId"].ToString(), playlist.Id);
            spotify.AddPlaylistTracks(this.Session["UserId"].ToString(), playlist.Id, seededTracksUris);

            return View();
        } 


        public ActionResult Anger()
        {
            SpotifyWebAPI spotify = new SpotifyWebAPI
            {
                UseAuth = true,
                AccessToken = Session["SpotifyToken"].ToString(),
                TokenType = "Bearer",
            };

            var recommendedSongs = spotify.GetRecommendations(
                new List<string>() { "5RADpgYLOuS2ZxDq7ggYYH", "30U8fYtiNpeA5KH6H87QUV" },
                new List<string>() { "punk-rock", "heavy-metal" },
                new List<string>() { "5iAet1Smzk6SWMBR6eWNBz" },
                null, null, null, 50, "BG");

            var seededTracksUris = new List<string>();
            recommendedSongs.Tracks.ForEach(item => seededTracksUris.Add(item.Uri));

            var playlist = spotify.CreatePlaylist(this.Session["UserId"].ToString(), "SadTest");
            spotify.FollowPlaylist(this.Session["UserId"].ToString(), playlist.Id);
            spotify.AddPlaylistTracks(this.Session["UserId"].ToString(), playlist.Id, seededTracksUris);

            return View();
        }


        public ActionResult Contempt() 
        {
            SpotifyWebAPI spotify = new SpotifyWebAPI
            {
                UseAuth = true,
                AccessToken = Session["SpotifyToken"].ToString(),
                TokenType = "Bearer",
            };

            var recommendedSongs = spotify.GetRecommendations(
                new List<string>() { "0wNZvrIMNUCs24G0wFg2D6", "6A7uqgC2N1nUhrCLAytHxN" },
                new List<string>() { "punk-rock", "pop-punk" },
                new List<string>() { "4YX32mhnhrnbUeeTe846it" },
                null, null, null, 50, "BG");

            var seededTracksUris = new List<string>();
            recommendedSongs.Tracks.ForEach(item => seededTracksUris.Add(item.Uri));

            var playlist = spotify.CreatePlaylist(this.Session["UserId"].ToString(), "SadTest");
            spotify.FollowPlaylist(this.Session["UserId"].ToString(), playlist.Id);
            spotify.AddPlaylistTracks(this.Session["UserId"].ToString(), playlist.Id, seededTracksUris);

            return View();
        }


        public ActionResult Surprise() //unfinished
        {
            SpotifyWebAPI spotify = new SpotifyWebAPI
            {
                UseAuth = true,
                AccessToken = Session["SpotifyToken"].ToString(),
                TokenType = "Bearer",
            };

            var recommendedSongs = spotify.GetRecommendations(
                new List<string>() { "0wNZvrIMNUCs24G0wFg2D6", "1aDpQ3bo57IlYWmsG5sdlp" },
                new List<string>() { "noise-pop", "noise-rock" },
                new List<string>() { "4J5htL1ewHiMh3c60U5Ddx" },
                null, null, null, 50, "BG");

            var seededTracksUris = new List<string>();
            recommendedSongs.Tracks.ForEach(item => seededTracksUris.Add(item.Uri));

            var playlist = spotify.CreatePlaylist(this.Session["UserId"].ToString(), "SadTest");
            spotify.FollowPlaylist(this.Session["UserId"].ToString(), playlist.Id);
            spotify.AddPlaylistTracks(this.Session["UserId"].ToString(), playlist.Id, seededTracksUris);

            return View();
        }



        public ActionResult Fear() //unfinished
        {
            SpotifyWebAPI spotify = new SpotifyWebAPI
            {
                UseAuth = true,
                AccessToken = Session["SpotifyToken"].ToString(),
                TokenType = "Bearer",
            };

            var recommendedSongs = spotify.GetRecommendations(
                new List<string>() { "6uVeWolwyRDrT84lLsaZyW" },
                new List<string>() { "noise", "blackgaze" },
                new List<string>() { "1yDMqzf9oZzjn2UJtaQAuP" },
                null, null, null, 50, "BG");

            var seededTracksUris = new List<string>();
            recommendedSongs.Tracks.ForEach(item => seededTracksUris.Add(item.Uri));

            var playlist = spotify.CreatePlaylist(this.Session["UserId"].ToString(), "SadTest");
            spotify.FollowPlaylist(this.Session["UserId"].ToString(), playlist.Id);
            spotify.AddPlaylistTracks(this.Session["UserId"].ToString(), playlist.Id, seededTracksUris);

            return View();
        }




        public ActionResult Disgust()
        {
            SpotifyWebAPI spotify = new SpotifyWebAPI
            {
                UseAuth = true,
                AccessToken = Session["SpotifyToken"].ToString(),
                TokenType = "Bearer",
            };

            var recommendedSongs = spotify.GetRecommendations(
                new List<string>() { "655AEE6ifgDJ3TYkhHdP48", "" },
                new List<string>() { "doom-metal"},
                new List<string>() { "34dkZZNQJzEJRqPkywYmEY" },
                null, null, null, 50, "BG");

            var seededTracksUris = new List<string>();
            recommendedSongs.Tracks.ForEach(item => seededTracksUris.Add(item.Uri));

            var playlist = spotify.CreatePlaylist(this.Session["UserId"].ToString(), "SadTest");
            spotify.FollowPlaylist(this.Session["UserId"].ToString(), playlist.Id);
            spotify.AddPlaylistTracks(this.Session["UserId"].ToString(), playlist.Id, seededTracksUris);

            return View();
        }



        public ActionResult Sadness()
        { 
            SpotifyWebAPI spotify = new SpotifyWebAPI
            {
                UseAuth = true,
                AccessToken = Session["SpotifyToken"].ToString(),
                TokenType = "Bearer",
            };

            //TuneableTrack min = new TuneableTrack()
            //{
            //    Danceability = 0.562f,
            //    Energy = 0.187f,
            //    Liveness = 0.132f,
            //};
            //TuneableTrack max = new TuneableTrack()
            //{
            //    Danceability = 0.438f,
            //    Energy = 0.940f,
            //    Liveness = 0.300f,
            //};

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


        public ActionResult Neutral()
        {
            SpotifyWebAPI spotify = new SpotifyWebAPI
            {
                UseAuth = true,
                AccessToken = Session["SpotifyToken"].ToString(),
                TokenType = "Bearer",
            };

            var recommendedSongs = spotify.GetRecommendations(
                new List<string>() { "1HY2Jd0NmPuamShAr6KMms", "1Xyo4u8uXC1ZmMpatF05PJ" },
                new List<string>() { "pop"},
                new List<string>() { "6I9VzXrHxO9rA9A5euc8Ak" },
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