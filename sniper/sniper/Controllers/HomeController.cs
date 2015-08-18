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
            //查找15个产品和4条新闻
            var product = new ProductService().GetList(1, 15);
            var news = new NewsService().GetList(1, 4);
            var model = Tuple.Create<List<Product>, List<News>>(product, news);
            return View(model);
        }

    }
}
