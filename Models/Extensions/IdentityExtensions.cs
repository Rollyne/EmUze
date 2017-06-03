using System.Linq;
using System.Security.Principal;
using Data.Data;
using Microsoft.AspNet.Identity;

namespace Data.Models.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetProfilePicturePath(this IIdentity identity)
        {
            EmuzerDbContext db = new EmuzerDbContext();
            var userId = identity.GetUserId();
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            var picture = user.ProfilePicture;
            return picture.FilePath;
        }
    }
}
