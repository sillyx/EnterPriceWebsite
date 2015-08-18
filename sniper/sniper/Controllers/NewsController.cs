using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using sniper.service.Models;
using sniper.service;

namespace sniper.Controllers
{
    public class NewsController : Controller
    {


        public ActionResult Index()
        {
            var newsService = new NewsService();
            var model = newsService.GetList(1, int.MaxValue);
            return View(model);
        }

        public ActionResult Details(string id)
        {
            var news = new NewsService().Details(id);
            return View(news);
        }

    }
}
