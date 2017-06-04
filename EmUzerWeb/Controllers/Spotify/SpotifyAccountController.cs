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
using Data.Repositories;
using EmUzerWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using EmuUzer.Models;

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

        public ActionResult RemoveSpotifyAccount(string accountId)
        {
            var userRepo = new UnitOfWork().GetUsersRepository();
            var repo = new UnitOfWork().GetSpotifyAccountsRepository();
            var user = userRepo.FirstOrDefault(i => i.Id == HttpContext.User.Identity.GetUserId());
            var actualAccountId = repo.FirstOrDefault(i => i.UserId == user.Id).SpotifyId;
            if (HttpContext.User.Identity.IsAuthenticated && actualAccountId == accountId)
            {
                
                var target = repo.FirstOrDefault(i => i.SpotifyId == accountId);
                repo.Delete(target);
                repo.Save();
            }

            return RedirectToAction("ManageLogins", "Manage");
        }

        [ActionName("SpotifyLogin")]
        public async Task<ActionResult> AuthenticateAsync(string returnUrl)
        {
            var authResult = await ConnectToSpotifyAsync(_spotify);
            var userInfo = authResult.GetPrivateProfile();
            user = new SpotifyAccount()
            {
                SpotifyId = userInfo.Id,
                Username = userInfo.DisplayName,
            };

            var userRepo = new UnitOfWork().GetUsersRepository();
            var spAccRepo = new UnitOfWork().GetSpotifyAccountsRepository();
            var appUser = userRepo.FirstOrDefault(i => i.Id == HttpContext.User.Identity.GetUserId());
            if (spAccRepo.FirstOrDefault(a => a.UserId == appUser.Id) == null)
            {
                try
                {
                    appUser.SpotifyAccount = user;
                    userRepo.Update(appUser);

                    userRepo.Save();
                }
                catch (Exception)
                {
                    
                }
            }
            

            this.Session["SpotifyToken"] =authResult.AccessToken;

            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                return RedirectToAction("ManageLogins", "Manage");
            }
            else
            {
                return this.Redirect(returnUrl);
            }
        }
    }
}