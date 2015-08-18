using System.Web;
using System.Web.Mvc;
using sniper.service;
using sniper.service.Models;

namespace sniper.Controllers
{
    public class AboutUsController : Controller
    {
        //
        // GET: /AboutUs/

        public ActionResult Index()
        {
            var aboutService = new AboutUsService();
            var model = aboutService.Get();
            return View(model);
        }

    }
}
