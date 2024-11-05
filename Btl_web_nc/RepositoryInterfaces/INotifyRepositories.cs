using Btl_web_nc.Models;

namespace Btl_web_nc.RepositoryInterfaces
{
    public interface INotifyRepositories
    {
        public Task<Notify> AddNotifyAsync(Notify notify);
        public Task<bool> DeleteNotifiesByPostIdAsync(int postId);

    }

    
}
