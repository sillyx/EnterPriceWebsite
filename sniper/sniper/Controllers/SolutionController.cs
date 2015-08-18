using System.Web.Mvc;
using sniper.service;

namespace sniper.Controllers
{
    public class SolutionController : Controller
    {
        //
        // GET: /Solution/

        public ActionResult Index()
        {
            var service=new SolutionService();
            var model=service.Get();
            return View(model);
        }

    }
}
