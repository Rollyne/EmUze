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
        
        public DbSet<SpotifyAccount> SpotifyAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(s => s.SpotifyAccount) // Mark Address property optional in Student entity
                .WithRequired(ad => ad.User); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student
        }
    }
}
