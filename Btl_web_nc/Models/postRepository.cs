using Btl_web_nc.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore; 
using Microsoft.AspNetCore.Mvc;
namespace Btl_web_nc.Models
{
    public class PostRepository : IPostRepositories
    {
        private readonly AppDbContext _dbContext;
    
        public PostRepository(AppDbContext db)
        {
            _dbContext = db;
        }

        public async Task<Boolean> DeletePostAsync(int postId)
        {
            try
            {
                var post = await _dbContext.Posts.SingleOrDefaultAsync(p => p.postId.Equals(postId));
                if (post == null)
                {
                    return false;
                }
                _dbContext.Posts.Remove(post);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Xóa bài đăng không thành công", ex);
            }
        }

        public Task<Post> AddNewPost(Post post)
        {
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
            return Task.FromResult(post);
        }

        public List<Post> GetAllPosts()
        {
            return _dbContext.Posts.ToList<Post>();
        }

        public async Task<Post> GetPostByIdAsync(int postID)
        {
            var post = await _dbContext.Posts.SingleOrDefaultAsync(p => p.postId == postID);
            return post ?? new Post();
        }

        public async Task<PostManageViewModel> GetPostViewModelByIdAsync(int id)
        {
            var post = await _dbContext.Posts.SingleOrDefaultAsync(p => p.postId == id);
            if (post == null)
            {
                return null!;
            }
            return new PostManageViewModel(post);
        }

        public async Task<Post> UpdatePostAsync(PostManageViewModel post)
        {
            try
            {
                var existingPost = await _dbContext.Posts.FirstOrDefaultAsync(p => p.postId == post.PostId);
                if (existingPost != null)
                {
                    existingPost.title = post.Title;
                    existingPost.address = post.Address;
                    existingPost.description = post.Description;
                    existingPost.price = post.Price;
                    existingPost.status = post.Status;
                    existingPost.imageUrls = post.ImageUrls;
                    existingPost.typeId = post.TypeId;
                    existingPost.area = post.Area??0;
                    existingPost.updatedDate = DateTime.Now;
                    _dbContext.Entry(existingPost).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                }
                return existingPost!;
            }
            catch (Exception ex)
            {
                throw new Exception("Cập nhật bài đăng không thành công", ex);
            }
        }

        public Post GetPostById(long id)
        {
            Post post = _dbContext.Posts.FirstOrDefault(p => p.postId == id);
            return post;
        }

        public List<Post> GetPostsByUserId(long userId)
        {
            return _dbContext.Posts
                            .Where(p => p.userId == userId) // Giả sử Post có thuộc tính UserId
                            .ToList();
        }
        public List<Post> GetFavouritePostsByUserId(long userId)
        {
            return _dbContext.Favourites
                .Where(f => f.userId == userId)
                .Select(f => f.Post)
                .ToList();
        }
    }
}
