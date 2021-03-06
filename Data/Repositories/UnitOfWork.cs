﻿using Data.Models;
using EmuUzer.Models;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<ApplicationUser> GetUsersRepository() => new UsersRepository();

        public IRepository<SpotifyAccount> GetSpotifyAccountsRepository() => new SpotifyAccountsRepository();
    }
}
