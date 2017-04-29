using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Newtonsoft.Json.Linq;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System.Threading.Tasks;

namespace EmUzerWeb.Models
{
    public class SpotifyAccount
    {
        public int ID { get; set; }

        public string AccessToken { get; set; }

        public string Username { get; set; }

        public string ModelError { get; set; }
    }
}