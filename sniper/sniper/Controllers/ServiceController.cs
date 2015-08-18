using System.Web.Mvc;

namespace sniper.Controllers
{
    public class ServiceController : Controller
    {
        //
        // GET: /Service/

        public ActionResult Index()
        {
            var service = new sniper.service.Service();
            var model = service.Get();
            return View(model);
        }

    }
}
