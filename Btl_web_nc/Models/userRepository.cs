using Btl_web_nc.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;


namespace Btl_web_nc.Models
{
    public class UserRepository : IUserRepositories
    {

        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext db)
        {
            _dbContext = db;
        }

        public async Task<User> AuthenticateUserAsync(string userName, string password)
        {

            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.username == userName);

            if (user == null)
            {
                // Tên đăng nhập không tồn tại
                return null!;
            }

            // So sánh mật khẩu, giả sử mật khẩu đã được mã hóa và lưu trữ
            bool isPasswordValid = VerifyPassword(password, user.password!);

            if (isPasswordValid)
            {
                return user;
            }

            // Mật khẩu không hợp lệ
            return null!;
        }
        private bool VerifyPassword(string password, string hashedPassword)
        {
            if (password == hashedPassword)
                return true;
            return false;
        }

        public User GetUserById(long userId)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.userId.Equals(userId));
            return user ?? new User();
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.username == userName);
            return user ?? new User();
        }

        public async Task<bool> UserExistsAsync(int UserId)
        {
            return await _dbContext.Users.AnyAsync(u => u.userId.Equals(UserId));
        }

        public async Task<bool> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            // Xác minh mật khẩu hiện tại
            if (user.password != currentPassword)
            {
                return false;
            }

            // Thay đổi mật khẩu
            user.password = newPassword;
            _dbContext.Users.Update(user);
            return await _dbContext.SaveChangesAsync() > 0;
        }



        //Dang ky
        public async Task CreateUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.username == username);
        }
        public async Task<User> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.phoneNumber == phoneNumber);
        }



        //Quản lý tài khoản
        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User MaGetUserById(long id)
        {
            return _dbContext.Users.Find(id);
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _dbContext.Users.Find(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public User GetUserByUsername(string username)
        {
            return _dbContext.Users.FirstOrDefault(u => u.username == username);
        }


        /*//Thông tin cá nhân
        public User ProGetUserById(int userId)
        {
            return _dbContext.Users.Find(userId);
        }

        public User ProGetUserByUsername(string username)
        {
            return _dbContext.Users.FirstOrDefault(u => u.username == username);
        }

        public void ProUpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }*/
    }
}
