using FinalProject.Models.Context;
using FinalProject.Models.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models.Managers
{
    public class CookieManager
    {
        private UserImp _Users;

        private string codemelliCookieName = "codemelliMyCookie";
        private string passwordCookieName = "passwordMyCookie";


        public user AuthorizedUser;

        public CookieManager()
        {
            _Users = new UserImp();
            AuthorizedUser = new user();
        }


        /// <summary>
        /// یک تابع برای چک کردن اطلاعات حساب کاربری داخل کوکی ها
        /// </summary>
        /// <returns></returns>
        public bool checkCookieCredentials()
        {
            if (HttpContext.Current.Request.Cookies[codemelliCookieName] == null|| HttpContext.Current.Request.Cookies[passwordCookieName] == null)
            {
                return false;
            }

            var codemelli = HttpContext.Current.Request.Cookies.Get(codemelliCookieName).Value.ToString();
            var password = HttpContext.Current.Request.Cookies.Get(passwordCookieName).Value.ToString();
            if (codemelli == null) return false;
            if (password == null) return false;
            if (string.IsNullOrEmpty(codemelli)) return false;
            if (string.IsNullOrEmpty(password)) return false;

            if (_Users.checkCredential(codemelli,password))
            {
                AuthorizedUser = _Users.FindUser(codemelli);
                setCookieCredentials(codemelli, password);
                return true;
            }
            return false;
        }


        /// <summary>
        /// تابعی برای ست کردن اطلاعات حساب کاربری در کوکی ها
        /// </summary>
        /// <param name="codemelli"></param>
        /// <param name="password"></param>
        public void setCookieCredentials(string codemelli="",string password="")
        {
            HttpCookie codemelliCookie = new HttpCookie(codemelliCookieName);
            codemelliCookie.Value = codemelli;
            codemelliCookie.Expires = DateTime.Now.AddHours(1);
            HttpContext.Current.Response.Cookies.Remove(codemelliCookieName);
            HttpContext.Current.Response.SetCookie(codemelliCookie);

            HttpCookie passwordCookie = new HttpCookie(passwordCookieName);
            passwordCookie.Value = password;
            passwordCookie.Expires = DateTime.Now.AddHours(1);
            HttpContext.Current.Response.Cookies.Remove(passwordCookieName);
            HttpContext.Current.Response.SetCookie(passwordCookie);
        }


        public void removeCookieCredentials()
        {
          
            HttpCookie codemelliCookie = new HttpCookie(codemelliCookieName);
            codemelliCookie.Expires = DateTime.Now.AddHours(-1);
            HttpContext.Current.Response.SetCookie(codemelliCookie);

            HttpCookie passwordCookie = new HttpCookie(passwordCookieName);
            passwordCookie.Expires = DateTime.Now.AddHours(-1);
            HttpContext.Current.Response.SetCookie(passwordCookie);
        }
    }
}