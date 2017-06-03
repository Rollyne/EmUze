using Data.Models;

namespace Data.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<ApplicationUser> GetUsersRepository();

        IRepository<SpotifyAccount> GetSpotifyAccountsRepository();
    }
}
