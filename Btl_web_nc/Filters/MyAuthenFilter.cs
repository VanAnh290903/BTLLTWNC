using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System;

public class MyAuthenFilter : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        
        // Nếu chưa đăng nhập
        if (context.HttpContext.User?.Identity?.IsAuthenticated != true)
        {
              // Lưu lại URL ban đầu
            var returnUrl = context.HttpContext.Request.Path + context.HttpContext.Request.QueryString;
            var loginUrl = $"/Account/Login?returnUrl={Uri.EscapeDataString(returnUrl)}";

            // Chuyển hướng đến trang đăng nhập với return URL
            context.Result = new RedirectResult(loginUrl);
        }
    }
}