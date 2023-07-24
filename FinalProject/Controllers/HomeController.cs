using FinalProject.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private CookieManager _cookieManager;
        public HomeController()
        {
            _cookieManager = new CookieManager();
        }
        public ActionResult Index()
        {
            if (_cookieManager.checkCookieCredentials())
            {
                ViewBag.AuthorizedUser = true;
            }
            else
            {
                ViewBag.AuthorizedUser = false;
            }
            return View();
        }
    }
}