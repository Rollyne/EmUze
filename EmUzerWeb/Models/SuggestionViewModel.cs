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

        public List<string> EmotionResults { get; set; }

        public List<string> WeatherResults { get; set; }
    }
}