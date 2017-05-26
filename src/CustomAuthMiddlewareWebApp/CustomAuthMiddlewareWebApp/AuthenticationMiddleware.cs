using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomAuthMiddlewareWebApp
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        private const string _SIGN_IN_PATH = "/Account/SignIn";

        private const string _SIGN_OUT_PATH = "/Account/SignOut";

        private const string _INDEX_PATH = "/Home/Index";

        private const string _COOKIE_NAME = "CustAuthTknCookie";

        private const bool _COOKIE_SECURE = false;

        private const int _COOKIE_DURATION = 60;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (!string.IsNullOrWhiteSpace(httpContext.Request.ContentType) && httpContext.Request.ContentType != "application/x-www-form-urlencoded")
            {
                await _next.Invoke(httpContext);
                return;
            }

            if (ValidateToken(httpContext.Request.Cookies[_COOKIE_NAME]))
            {
                if (httpContext.Request.Path.ToString().ToLower() == _SIGN_OUT_PATH.ToLower()/* && httpContext.Request.Method == "POST"*/)
                {

                    httpContext.Response.Cookies.Append(_COOKIE_NAME, string.Empty, new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(-1),
                        Secure = _COOKIE_SECURE
                    });
                    httpContext.Response.Redirect(_SIGN_IN_PATH);

                    //await _next.Invoke(httpContext); breaks the redirect
                    return;
                }

                await _next.Invoke(httpContext);
                return;
            }

            if (httpContext.Request.Path.ToString().ToLower() == _SIGN_IN_PATH.ToLower())
            {
                if (ValidateToken(httpContext.Request.Cookies[_COOKIE_NAME]))
                {
                    httpContext.Response.Redirect(_INDEX_PATH);
                    await _next.Invoke(httpContext);
                    return;
                }

                if (httpContext.Request.Method == "POST" && httpContext.Request.HasFormContentType)
                {
                    if (TryAuthenticateUser(httpContext.Request.Form["Username"], httpContext.Request.Form["Password"], out string _token) && ValidateToken(_token))
                    {
                        httpContext.Response.Headers["tkn"] = _token;
                        httpContext.Response.Redirect(_INDEX_PATH);

                        httpContext.Response.Cookies.Append(_COOKIE_NAME, _token, new CookieOptions
                        {
                            Expires = DateTime.Now.AddMinutes(_COOKIE_DURATION),
                            Secure = _COOKIE_SECURE
                        });

                        //await _next.Invoke(httpContext); breaks the redirect
                        return;
                    }
                }

                await _next.Invoke(httpContext);
                return;
            }

            if (!httpContext.User.Identity.IsAuthenticated)
            {
                httpContext.Response.Redirect(_SIGN_IN_PATH, false);
            }


            await _next.Invoke(httpContext);
        }

        private bool ValidateToken(string tkn) => !string.IsNullOrWhiteSpace(tkn);

        private bool TryAuthenticateUser(string username, string password, out string token)
        {
            token = null;

            if (string.IsNullOrWhiteSpace(username))
                return false;

            if (string.IsNullOrWhiteSpace(password))
                return false;

            if (username == "atorris" && password == "password")
            {
                token = "this_is_the_content_of_my_token";
                return true;
            }

            return false;
        }
    }

    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthentication(this IApplicationBuilder builder) => builder.UseMiddleware<AuthenticationMiddleware>();
    }
}