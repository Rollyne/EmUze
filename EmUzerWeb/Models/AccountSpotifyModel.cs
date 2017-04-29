using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web;


namespace EmUzerWeb.Models
{
    public class AccountSpotifyModel
    {  
      public List<SimpleTrack> savedTracks { get; set; }
      public List<SimpleTrack> currentPlaylist { get; set; }

      
    }
}