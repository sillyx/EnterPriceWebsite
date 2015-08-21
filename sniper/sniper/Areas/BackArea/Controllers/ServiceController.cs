using System;
using System.Web.Mvc;
using service = sniper.service;
using model = sniper.service.Models;

namespace sniper.Areas.BackArea.Controllers
{
    public class ServiceController : Controller
    {
        //
        // GET: /BackArea/Service/

        public ActionResult Index()
        {
            var aService = new service.Service();
            var model = aService.Get();
            return View(model);
        }

        [ValidateInput(false)]
        public JsonResult Edit(model.Service us)
        {
            var res = false;
            if (us.Id == null || us.Id == Guid.Empty.ToString())
            {
                us.Id = Guid.NewGuid().ToString();
                res = new service.BaseService().Insert<model.Service>(us);
            }
            else
                res = new service.BaseService().Update<model.Service>(us);
            return Json(new { res = res });
        }

    }
}
