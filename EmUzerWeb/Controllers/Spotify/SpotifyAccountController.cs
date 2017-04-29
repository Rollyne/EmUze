﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System.Threading.Tasks;
using EmUzerWeb.Models;

namespace EmUzerWeb.Controllers.Spotify
{
    public class SpotifyAccountController : Controller
    {
        private static SpotifyWebAPI _spotify;
        private SpotifyAccount user;

        public async Task<SpotifyWebAPI> ConnectToSpotifyAsync(SpotifyWebAPI _spotify)
        {
            WebAPIFactory webApiFactory = new WebAPIFactory(
                "http://localhost",
                 44333,
                "509976e01ef2432c9135a8dd26085d9d",
                Scope.PlaylistModifyPrivate | Scope.PlaylistModifyPublic | Scope.Streaming | Scope.UserFollowModify |
                Scope.UserFollowRead | Scope.UserLibraryRead | Scope.UserReadPrivate | Scope.UserTopRead,
                TimeSpan.FromSeconds(20));

            try
            {
                //This will open the user's browser and returns once
                //the user is authorized.
                _spotify = await webApiFactory.GetWebApi();
            }
            catch (Exception ex)
            {
                user.ModelError = ex.Message;
            }

            if (_spotify == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return await Task.FromResult<SpotifyWebAPI>(_spotify);
            }
        }

        public async Task<ActionResult> AuthenticateAsync()
        {
            var user = await ConnectToSpotifyAsync(_spotify);
            return View(user);
        }
    }
}