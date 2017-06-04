using System.Data.Entity;
using Data.Models;
using EmuUzer.Models;
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
        
        public DbSet<SpotifyAccount> SpotifyAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(s => s.SpotifyAccount)
                .WithRequired(ad => ad.User);
            modelBuilder.Entity<SpotifyAccount>()
                .HasKey(a => a.UserId);
        }
    }
}
