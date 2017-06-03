using EmUzerWeb.Models;
using EmUzerWeb.Tools.Weather;
using Newtonsoft.Json.Linq;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EmUzerWeb.Controllers
{
    public class SuggestionController : Controller
    {
        private const string WEATHER_API_KEY = "a1c52306b2406040f1763904d7f0163e";
        // GET: Suggestions
        public ActionResult Index(string latitude, string longtitude, string emotion = "Neutral")
        {
            string weather = this.GetWeather(latitude, longtitude);
            // TO-DO
            SpotifyWebAPI spotifyClient = new SpotifyWebAPI();
            spotifyClient.UseAuth = false;

            var emotionSearch = spotifyClient.SearchItems(emotion, SpotifyAPI.Web.Enums.SearchType.Playlist, 3)
                .Playlists.Items.Select(pl => pl.Uri).ToList();
            var weatherSearch = spotifyClient.SearchItems(weather, SpotifyAPI.Web.Enums.SearchType.Playlist, 3)
                 .Playlists.Items.Select(pl => pl.Uri).ToList();

            

            var model = new SuggestionViewModel()
            {
                Emotion = emotion,
                Weather = weather,
                EmotionResults = emotionSearch,
                WeatherResults = weatherSearch
            };

            return View(model);
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