using EmUzerWeb.Models;
using EmUzerWeb.Tools.ExtensionMethods;
using EmUzerWeb.Tools.Weather;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Newtonsoft.Json.Linq;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EmUzerWeb.Controllers
{
    public class SuggestionController : Controller
    {
        private const string WEATHER_API_KEY = "a1c52306b2406040f1763904d7f0163e";
        private const string YOUTUBE_API_KEY = "AIzaSyBwifNeefkdiu_-nDW9QZI7hq4dkfrM0mA";

        // GET: Suggestions
        public ActionResult Index(string latitude, string longtitude, string emotion = "Neutral")
        {
            if (this.Session["SpotifyToken"] == null)
            {
                return this.RedirectToAction("SpotifyLogin", "SpotifyAccount", new
                {
                    returnUrl = $"/Suggestion?latitude={latitude}&longtitude={longtitude}&emotion={emotion}"
                });
            }

            string weather = this.GetWeather(latitude, longtitude);
            var emotionSpotify = new List<string>();
            var weatherSpotify = new List<string>();


            try
            {
                emotionSpotify = this.GetSpotifySuggestions(emotion);
                RedirectToAction("Playlist");
                emotionSpotify.Add(Session["GeneratedPlaylist"].ToString());
                weatherSpotify = this.GetSpotifySuggestions(weather);
            }
            catch (NullReferenceException)
            {
                return this.RedirectToAction("SpotifyLogin", "SpotifyAccount", new
                {
                    returnUrl = string.Format("/Suggestions/Index?latitude={0}&longtitude={1}&emotion={2}", latitude, longtitude, emotion)
                });
            }
            
            var emotionYoutube = this.GetYouTubeSuggestions(emotion);
            var weatherYoutube = this.GetYouTubeSuggestions(weather);

            

            var model = new SuggestionViewModel()
            {
                Emotion = emotion,
                Weather = weather,
                SpotifyEmotionResults = emotionSpotify,
                SpotifyWeatherResults = weatherSpotify,
                YoutubeEmotionResults = emotionYoutube,
                YoutubeWeatherResults = weatherYoutube
            };

            return View(model);
        }

        private List<string> GetSpotifySuggestions(string keyword)
        {
            SpotifyWebAPI spotifyClient = new SpotifyWebAPI()
            {
                UseAuth = true,
                AccessToken = this.Session["SpotifyToken"].ToString(),
                TokenType = "Bearer"
            };

            return spotifyClient.SearchItems(keyword, SpotifyAPI.Web.Enums.SearchType.Playlist, 20)
                   .Playlists.Items.Shuffle().Take(2).Select(pl => pl.Uri).ToList();

        }

        private List<string> GetYouTubeSuggestions(string keyword)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = YOUTUBE_API_KEY,
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = keyword;
            searchListRequest.MaxResults = 20;
            searchListRequest.VideoCategoryId = "10";
            searchListRequest.Type = "video";

            var searchListResponse = searchListRequest.ExecuteAsync().Result;
            return searchListResponse.Items.Shuffle().Take(3).Select(i => i.Id.VideoId).ToList();
        }

        private string GetWeather(string latitude, string longtitude)
        {
            var url = "/weather?lat=" + latitude + "&lon=" + longtitude;
            var apiUrl = "http://api.openweathermap.org/data/2.5";

            using (var client = new WebClient())
            {
                Trace.WriteLine("<HTTP - GET - " + url + " >");
                var response = client.DownloadString($"{apiUrl}{url}&appid={WEATHER_API_KEY}");
                var parsedResponse = JObject.Parse(response);
                var item = WeatherDeserializer.GetWeatherCurrent(parsedResponse);

                return item.Item.Title;
            }
        }
    }
}