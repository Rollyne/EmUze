using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System.Threading.Tasks;
using Data.Models;

namespace EmUzerWeb.Controllers.Spotify
{
    public class SpotifyAccountController : Controller
    {
        public const string SPOTIFY_API_KEY = "509976e01ef2432c9135a8dd26085d9d";

        private static SpotifyWebAPI _spotify;
        private SpotifyAccount user;

        public async Task<SpotifyWebAPI> ConnectToSpotifyAsync(SpotifyWebAPI _spotify)
        {
            WebAPIFactory webApiFactory = new WebAPIFactory(
                "http://localhost",
                44333,
                SPOTIFY_API_KEY,
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
                ViewBag.AuthError = ex.Message;
            }

            if (_spotify == null)
            {
                throw new NullReferenceException();
            }

            return await Task.FromResult<SpotifyWebAPI>(_spotify);
        }

        [ActionName("SpotifyLogin")]
        public async Task<ActionResult> AuthenticateAsync(string returnUrl)
        {
            var authResult = await ConnectToSpotifyAsync(_spotify);
            var userInfo = authResult.GetPrivateProfile();
            user = new SpotifyAccount()
            {
                AccountId = userInfo.Id,
                AccessToken = authResult.AccessToken,
                Username = userInfo.DisplayName,
            };

            this.Session["SpotifyToken"] = user.AccessToken;

            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                return View();
            }
            else
            {
                return this.Redirect(returnUrl);
            }
        }
    }
}