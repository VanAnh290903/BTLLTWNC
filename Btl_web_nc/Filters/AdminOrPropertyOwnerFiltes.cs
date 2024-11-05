using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System;
using Btl_web_nc.Models;

public class AdminOrPropertyOwnerFilter : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {

        if (context.HttpContext.User?.Identity?.IsAuthenticated != true)
        {
            // Chưa đăng nhập, chuyển hướng đến trang đăng nhập
            context.Result = new RedirectResult("/Account/Login");
            return;
        }

        // Kiểm tra xem người dùng có quyền admin hay không
        if (!IsUserAdmin(context))
        {

            context.Result = new RedirectResult("/Account/AccessDenied");
            return;
        }
    }

    private bool IsUserAdmin(AuthorizationFilterContext context)
    {
        var userName = context.HttpContext.User?.Identity?.Name;
        if (string.IsNullOrEmpty(userName))
        {
            // Log lỗi hoặc thông báo không có UserId
            Console.WriteLine("UserId is null or empty.");
            return false;
        }

        // Sử dụng service provider để lấy DbContext
        var dbContext = context.HttpContext.RequestServices.GetService<AppDbContext>();

        if (dbContext == null)
        {
            // Log lỗi nếu không lấy được DbContext
            Console.WriteLine("DbContext is null.");
            return false;
        }

        // Kiểm tra user trong cơ sở dữ liệu
        var user = dbContext.Users.FirstOrDefault(u => u.username!.Equals(userName));

        if (user != null)
        {
            // Kiểm tra vai trò của người dùng
            var isAdmin = dbContext.Roles.Any(r => r.roleId == user.roleId && r.roleName == "PropertyOwner" ||  r.roleId == user.roleId && r.roleName == "Admin");

            return isAdmin;
        }
        else
        {
            // Log lỗi nếu không tìm thấy user
            Console.WriteLine($"User with userId '{userName}' not found in database.");
            return false;
        }
    }
}