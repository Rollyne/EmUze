using EmUzerWeb.Models;
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
                return this.RedirectToAction("SpotifyLogin", "SpotifyAccount");
            }

            string weather = this.GetWeather(latitude, longtitude);
            
            // TO-DO
            SpotifyWebAPI spotifyClient = new SpotifyWebAPI()
            {
                UseAuth = true,
                AccessToken = this.Session["SpotifyToken"].ToString(),
                TokenType = "Bearer"
            };

            var emotionYoutube = this.GetYouTubeSuggestions(emotion);
            var weatherYoutube = this.GetYouTubeSuggestions(weather);

            var emotionSpotify = spotifyClient.SearchItems(emotion, SpotifyAPI.Web.Enums.SearchType.Playlist, 3)
                .Playlists.Items.Select(pl => pl.Uri).ToList();
            var weatherSpotify = spotifyClient.SearchItems(weather, SpotifyAPI.Web.Enums.SearchType.Playlist, 3)
                .Playlists.Items.Select(pl => pl.Uri).ToList();

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

        private List<string> GetYouTubeSuggestions(string keyword)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = YOUTUBE_API_KEY,
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = keyword;
            searchListRequest.MaxResults = 3;
            searchListRequest.VideoCategoryId = "10";
            searchListRequest.Type = "video";

            var searchListResponse = searchListRequest.ExecuteAsync().Result;
            return searchListResponse.Items.Select(i => i.Id.VideoId).ToList();
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