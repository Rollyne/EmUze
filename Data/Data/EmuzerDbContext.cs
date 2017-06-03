﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IDbSet<Picture> Pictures { get; set; }

        public IDbSet<PictureProviderType> PictureProviderTypes { get; set; }

        public IDbSet<SpotifyAccount> SpotifyAccounts { get; set; }
    }
}
