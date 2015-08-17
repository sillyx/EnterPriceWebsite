using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sniper.service;
using sniper.service.Models;

namespace sniper.Controllers
{
    public class HomeController : Controller
    {
        BaseService baseService = null;
        public HomeController()
        {
            baseService = new BaseService();
        }

        public ActionResult Index()
        {
            var news = new News
            {
                Id = Guid.NewGuid().ToString(),
                Cont = "test",
                CreateTime = DateTime.Now,
                Title = "test"
            };
            var r = baseService.Insert<News>(news);
            return View();
        }

    }
}
