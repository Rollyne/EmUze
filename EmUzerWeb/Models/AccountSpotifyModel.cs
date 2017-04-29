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
      public Paging<SavedTrack> savedTracks { get; set; }
      public List<FullTrack> currentPlaylist { get; set; }

    }
}