using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmUzerWeb.Models
{
    public class SuggestionViewModel
    {
        public string Emotion { get; set; }

        public string Weather { get; set; }

        public List<string> SpotifyEmotionResults { get; set; }

        public List<string> SpotifyWeatherResults { get; set; }

        public List<string> YoutubeEmotionResults { get; set; }

        public List<string> YoutubeWeatherResults { get; set; }
    }
}