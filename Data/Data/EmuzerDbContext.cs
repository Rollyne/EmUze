using System.Data.Entity;
using Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data.Data
{
    public class EmuzerDbContext : IdentityDbContext<ApplicationUser>
    {
        public EmuzerDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static EmuzerDbContext Create()
        {
            return new EmuzerDbContext();
        }
        
        public IDbSet<SpotifyAccount> SpotifyAccounts { get; set; }
    }
}
