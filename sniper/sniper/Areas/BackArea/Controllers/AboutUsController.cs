using System;
using System.Web.Mvc;
using sniper.service;
using sniper.service.Models;

namespace sniper.Areas.BackArea.Controllers
{
    public class AboutUsController : Controller
    {
        //
        // GET: /BackArea/AboutUs/

        public ActionResult Index()
        {
            var aService = new AboutUsService();
            var model = aService.Get();
            return View(model);
        }

        [ValidateInput(false)]
        public JsonResult Edit(AboutUs us)
        {
            var res = false;
            if (us.Id == null || us.Id == Guid.Empty.ToSafeTrim())
            {
                us.Id = Guid.NewGuid().ToSafeTrim();
                res = new BaseService().Insert<AboutUs>(us);
            }
            else
                res = new BaseService().Update<AboutUs>(us);
            return Json(new { res = res });
        }

    }
}
