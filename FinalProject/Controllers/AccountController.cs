using FinalProject.Models.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.Models.Managers;

namespace FinalProject.Controllers
{
    public class AccountController : Controller
    {
        private UserImp _Users;
        private CookieManager _cookieManager;

        public AccountController()
        {
            _Users = new UserImp();
            _cookieManager = new CookieManager();
        }

        public ActionResult Register(int ErrorCode = 0)
        {
            if ((_cookieManager.checkCookieCredentials()))
            {
                return RedirectToAction("SuratJalaseList", "SuratJalase");
            }

            ViewBag.message = StaticInfoes.ErrorCodes[ErrorCode];
            ViewBag.ErrorCode = ErrorCode;
            ViewBag.AuthorizedUser = false;
            return View();
        }

        [HttpPost]
        public ActionResult Register(string fname,string lname,string phonnumber,string codemelli,string password)
        {
            if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname) || string.IsNullOrEmpty(phonnumber) || string.IsNullOrEmpty(codemelli) || string.IsNullOrEmpty(password) )
            {
                return RedirectToAction("Register", "Account", new { ErrorCode = 3 });
            }

            _Users.SaveUser(new Models.Context.user()
            {
                codemelli = codemelli,
                fname = fname,
                lname = lname,
                phonnumber = phonnumber,
                password = password
            });
            _cookieManager.setCookieCredentials(codemelli, password);

            return RedirectToAction(controllerName: "SuratJalase", actionName: "SuratJalaseList");
        }

        public ActionResult Login(int ErrorCode=0)
        {
            if ((_cookieManager.checkCookieCredentials()))
            {
                return RedirectToAction("SuratJalaseList", "SuratJalase");
            }

            ViewBag.message = StaticInfoes.ErrorCodes[ErrorCode];
            ViewBag.ErrorCode = ErrorCode;
            ViewBag.AuthorizedUser = false;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string password,string codemelli)
        {
            if (_Users.checkCredential(codemelli,password))
            {
                _cookieManager.setCookieCredentials(codemelli, password);
                return RedirectToAction("SuratJalaseList", "SuratJalase");
            }

            return RedirectToAction(controllerName: "Account", actionName: "Login", routeValues:new { ErrorCode=1});
        }


        public ActionResult Logout()
        {
            _cookieManager.removeCookieCredentials();
            return RedirectToAction("Index", "Home");
        }


    }
}