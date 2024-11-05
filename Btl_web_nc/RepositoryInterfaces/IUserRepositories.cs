using Btl_web_nc.Models;
using System.Threading.Tasks;

namespace Btl_web_nc.RepositoryInterfaces
{
    public interface IUserRepositories
    {
        // Xác thực người dùng bằng tên đăng nhập và mật khẩu
        public Task<User> AuthenticateUserAsync(string userName, string password);

        // Lấy thông tin người dùng theo tên đăng nhập
        public Task<User> GetUserByUserNameAsync(string userName);

        // Lấy thông tin người dùng theo ID
        public User GetUserById(long userId);

        // Kiểm tra xem người dùng có tồn tại không
        public Task<bool> UserExistsAsync(int userName);


        //Dang ky

        //kiểm tra tên người dùng đã tồn tại chưa
        Task<User> GetByUsernameAsync(string username);
        Task CreateUserAsync(User user);

        //kiểm tra sđt đã sử dụng chưa
        Task<User> GetUserByPhoneNumberAsync(string phoneNumber);


        //Quản lý tài khoản
        IEnumerable<User> GetAllUsers();
        User MaGetUserById(long id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        User GetUserByUsername(string username);


        /* //Thông tin cá nhân 
         User ProGetUserById(int userId);
         User ProetUserByUsername(string username);
         void ProUpdateUser(User user);*/
        public Task<bool> ChangePasswordAsync(User user, string currentPassword, string newPassword);

    }
}
