using Btl_web_nc.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Btl_web_nc.Models
{
    public class FavouriteRepository:IFavouriteRepositories
    {
        private readonly AppDbContext _dbContext;

        public FavouriteRepository(AppDbContext db)
        {
            _dbContext = db;
        }
        public bool AddToFavourite(long postId, long userId)
        {
            Favourite favourite = new Favourite
            {
                postId = postId,
                userId = userId
            };
            _dbContext.Favourites.Add(favourite);
            _dbContext.SaveChanges();
            return true;
        }
        public bool RemoveFromFavourite(long favouriteId)
        {
            Favourite favourite = _dbContext.Favourites.FirstOrDefault(f => f.favouriteId == favouriteId);
            if (favourite != null)
            {
                _dbContext.Favourites.Remove(favourite);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public Favourite GetFavouriteId(long postId, long userId)
        {
            Favourite favourite = _dbContext.Favourites.FirstOrDefault(f => f.postId == postId && f.userId == userId);
            return favourite;
        }
    }
}
