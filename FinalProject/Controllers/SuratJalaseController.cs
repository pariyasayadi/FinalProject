using FinalProject.Models.Filters;
using FinalProject.Models.Implementations;
using FinalProject.Models.InputModel;
using FinalProject.Models.Managers;
using FinalProject.Models.NetworkModels;
using FinalProject.Models.OutputModels;
using FinalProject.Models.ViewModels.MinuteController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class SuratJalaseController : Controller
    {
        private CookieManager _cookieManager;
        private suratJalaseImp _suratJalaseImp;
        private bandImp _bandImp;
        private typeImp _typeImp;

        public SuratJalaseController()
        {
            _cookieManager = new CookieManager();
            _suratJalaseImp = new suratJalaseImp();
            _bandImp = new bandImp();
            _typeImp = new typeImp();
        }

        public ActionResult SuratJalaseList()
        {
            var model = new SuratJalaseListViewModel();
            if (!(_cookieManager.checkCookieCredentials()))
            {
                return RedirectToAction("Login", "Account", new { ErrorCode = 2 });
            }

            #region reading data from DB

            var SuratJalaseha = _suratJalaseImp
                .filterSuratJalaseha(new suratJalaseFilter()
                {
                    IsUserRelated=true,userNumber=_cookieManager.AuthorizedUser.codemelli
                });

            #endregion
            
            model.suratJalaseha = SuratJalaseha;
            ViewBag.AuthorizedUser = true;
            return View(model);
        }


      
        public ActionResult AddSuratJalase(string Message="")
        {
            var model = new AddSuratJalaseViewModel();
            if (!(_cookieManager.checkCookieCredentials()))
            {
                return RedirectToAction("Login", "Account", new { ErrorCode = 2 });
            }

            model.typeha = _typeImp.Filtertype(new typeFilter());
            ViewBag.message = Message;
            ViewBag.AuthorizedUser = true;
            return View(model);
        }


        [HttpPost]
        public JsonResult AddSuratJalase(AddSuratJalaseInputModel input)
        {
            var response = new AddSuratJalaseOutputModel();

            var suratJalase = input.suratJalase.castTo(new Models.Context.suratJalase());
            suratJalase.date = DateTime.Now;

            List<Models.Context.band> bandha = new List<Models.Context.band>();
            foreach (var item in input.bandha)
            {
                bandha.Add(item.castTo(new Models.Context.band()));
            }
            _suratJalaseImp.saveSuratJalase(suratJalase, bandha);
            
            return Json(response);
        }
    }
}