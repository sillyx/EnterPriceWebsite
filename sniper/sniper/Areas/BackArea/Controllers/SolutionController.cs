using System;
using System.Web.Mvc;
using sniper.service;
using sniper.service.Models;

namespace sniper.Areas.BackArea.Controllers
{
    public class SolutionController : Controller
    {

        public ActionResult Index()
        {
            var solutionService = new SolutionService();
            var model = solutionService.Get();
            return View(model);
        }

        [ValidateInput(false)]
        public JsonResult Edit(Solution solution)
        {
            var res = false;
            if (solution.Id == null || solution.Id == Guid.Empty.ToSafeTrim())
            {
                solution.Id = Guid.NewGuid().ToSafeTrim();
                res = new BaseService().Insert<Solution>(solution);
            }
            else
                res = new BaseService().Update<Solution>(solution);
            return Json(new { res = res });
        }

    }
}
