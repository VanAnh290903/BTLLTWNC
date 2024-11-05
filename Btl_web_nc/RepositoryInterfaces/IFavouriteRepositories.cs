using Btl_web_nc.Models;

namespace Btl_web_nc.RepositoryInterfaces
{
    public interface IFavouriteRepositories
    {
        public bool AddToFavourite(long postId, long userId);
        public bool RemoveFromFavourite(long favouriteId);
        public Favourite GetFavouriteId(long postId, long userId);
    }
}
