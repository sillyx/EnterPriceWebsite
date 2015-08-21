using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sniper.service;
using System.IO;
using sniper.service.Models;

namespace sniper.Areas.BackArea.Controllers
{
    public class ImageListController : Controller
    {
        ImageListService pService = null;
        public ImageListController()
        {
            pService = new ImageListService();
        }

        public ActionResult Index(string productId)
        {
            ViewBag.productId = productId;
            return View();
        }


        public ActionResult Upload(string id)
        {
            ViewBag.productId = id;
            return View();
        }

         
        [HttpPost]
        public string GetList(int page, int rows, string productId)
        {
            var total = 0;
            var list = pService.GetList(page, rows, productId, out total);
            return list.ToJson(total);
        }
        public JsonResult DeleteItems(string idList)
        {
            var flag = false;
            var count = 0;
            if (idList != null)
            {
                count = idList.Split(',').Count();
                flag = new BaseService().Delete("ImageList", idList);
            }
            return Json(new { flag = flag, count = count });
        }
    }
}
