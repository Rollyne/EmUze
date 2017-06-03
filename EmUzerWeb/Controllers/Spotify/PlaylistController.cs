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
            if (Session["Emotion"] == null)
            {
                return View("Error");
            }
            else
            {
                SpotifyWebAPI spotify = new SpotifyWebAPI
                {
                    UseAuth = true,
                    AccessToken = Session["SpotifyToken"].ToString(),
                    TokenType = "Bearer",
                };

                TuneableTrack min = new TuneableTrack()
                {
                    Danceability = 0.562f,
                    Energy = 0.187f,
                    Liveness = 0.132f,
                };
                TuneableTrack max = new TuneableTrack()
                {
                    Danceability = 0.438f,
                    Energy = 0.940f,
                    Liveness = 0.300f,
                };

                FullTrack trck = spotify.GetTrack("25ia1zWRMAwPpA2LsHwPv2");
                var stuff = spotify.GetAudioFeatures("25ia1zWRMAwPpA2LsHwPv2");
                TuneableTrack target = new TuneableTrack
                {
                    Acousticness = stuff.Acousticness,
                    Danceability = stuff.Danceability,
                    DurationMs = stuff.DurationMs,
                    Energy = stuff.Energy,
                    Instrumentalness = stuff.Instrumentalness,
                    Key = stuff.Key,
                    Liveness = stuff.Liveness,
                    Loudness = stuff.Loudness,
                    Mode = stuff.Mode,
                    Popularity = 38,
                    Speechiness = stuff.Speechiness,
                    Tempo = stuff.Tempo,
                    TimeSignature = stuff.TimeSignature,
                    Valence = stuff.Valence,
                };

                var recommendedSongs = spotify.GetRecommendations(null, null, null, target, null, null, 50, "BG");
                var seededTracksUris = new List<string>();
                recommendedSongs.Tracks.ForEach(item => seededTracksUris.Add(item.Uri));
                var playlist = spotify.CreatePlaylist(this.Session["UserId"].ToString(), "SadTest");
                spotify.FollowPlaylist(this.Session["UserId"].ToString(), playlist.Id);
                spotify.AddPlaylistTracks(this.Session["UserId"].ToString(), playlist.Id, seededTracksUris);
            }
            return View();
        }
    }
}