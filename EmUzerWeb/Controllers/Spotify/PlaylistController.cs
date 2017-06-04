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

        private void EmotionTemplate(string artistId_1, string genre_1, string trackId_1, string artistId_2 = "", string genre_2 = "", string trackId_2 = "")
        {

        
        
            SpotifyWebAPI spotify = new SpotifyWebAPI
            {
                UseAuth = true,
                AccessToken = Session["SpotifyToken"].ToString(),
                TokenType = "Bearer",
            };

            

            var recommendedSongs = spotify.GetRecommendations(
                new List<string>() { artistId_1, artistId_2 },
                new List<string>() { genre_1, genre_2},
                new List<string>() { trackId_1, trackId_2},
                null, null, null, 50, "BG");

            var seededTracksUris = new List<string>();
            recommendedSongs.Tracks.ForEach(item => seededTracksUris.Add(item.Uri));

            var playlist = spotify.CreatePlaylist(this.Session["UserId"].ToString(), "SadTest");
            spotify.FollowPlaylist(this.Session["UserId"].ToString(), playlist.Id);
            spotify.AddPlaylistTracks(this.Session["UserId"].ToString(), playlist.Id, seededTracksUris);

            this.Session["GeneratedPlaylist"] = playlist.Id;

            
        }

       
        public ActionResult Happiness() 
        {
            
            EmotionTemplate("6OqhFYFJDnBBHas02HopPT ", "pop", "3LuLUNgRmmgcr14dTIWH2S", null, "dance", null );

            return View();
        } 

        public EmptyResult Anger()
        {

            EmotionTemplate("RADpgYLOuS2ZxDq7ggYYH", "pop", "5iAet1Smzk6SWMBR6eWNBz", "30U8fYtiNpeA5KH6H87QUV", "heavy-metal", null);

            return new EmptyResult();
;
        }

        public EmptyResult Contempt() 
        {
            EmotionTemplate("0wNZvrIMNUCs24G0wFg2D6", "punk-rock", "4YX32mhnhrnbUeeTe846it", "6A7uqgC2N1nUhrCLAytHxN", "pop-punk", null);


            return new EmptyResult();
        }

        public EmptyResult Surprise() 
        {
            EmotionTemplate("0wNZvrIMNUCs24G0wFg2D6", "noise-pop", "4J5htL1ewHiMh3c60U5Ddx", "1aDpQ3bo57IlYWmsG5sdlp", "noise-rock", null);

            return new EmptyResult();
        }

        public EmptyResult Fear() 
        {
            EmotionTemplate("6uVeWolwyRDrT84lLsaZyW", "noise", "1yDMqzf9oZzjn2UJtaQAuP", null, "blackgaze", null);

            return new EmptyResult();
        }

        public EmptyResult Disgust()
        {
            EmotionTemplate("655AEE6ifgDJ3TYkhHdP48", "doom-metal", "34dkZZNQJzEJRqPkywYmEY", null, "sludge-metal", null);

            return new EmptyResult();
        }

        public EmptyResult Sadness()
        {
            EmotionTemplate("5VnYwYnG7QmpzQtxyubIwh", "slowcore", "25ia1zWRMAwPpA2LsHwPv2", null, "shoegaze", null);

            return new EmptyResult();
        }

        public EmptyResult Neutral()
        {
            EmotionTemplate("1HY2Jd0NmPuamShAr6KMms", "pop", "6I9VzXrHxO9rA9A5euc8Ak", "1Xyo4u8uXC1ZmMpatF05PJ", null, null);

            return new EmptyResult();
        }
    }
}