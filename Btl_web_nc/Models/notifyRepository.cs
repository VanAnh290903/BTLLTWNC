using Btl_web_nc.RepositoryInterfaces;

namespace Btl_web_nc.Models
{
    public class NotifyRepository : INotifyRepositories
    {
        private readonly AppDbContext _dbContext;

        public NotifyRepository(AppDbContext db)
        {
            _dbContext = db;
        }
        public Task<Notify> AddNotifyAsync(Notify notify)
        {
            _dbContext.Notifies.Add(notify);
            _dbContext.SaveChanges();
            return Task.FromResult(notify);
        }

        public async Task<bool> DeleteNotifiesByPostIdAsync(int postId)
    {
        var notifies = _dbContext.Notifies.Where(n => n.postId == postId);
        _dbContext.Notifies.RemoveRange(notifies);
        return await _dbContext.SaveChangesAsync() > 0;
    }
    }
}
