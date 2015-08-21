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
    public class NewsController : Controller
    {
        NewsService pService = null;
        public NewsController()
        {
            pService = new NewsService();
        }
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public string GetList(int page, int rows)
        {
            var total = 0;
            var list = pService.GetList(page, rows, out total);
            return list.ToJson(total);
        }

        public JsonResult DeleteItems(string idList)
        {
            var flag = false;
            var count = 0;
            if (idList != null)
            {
                count = idList.Split(',').Count();
                flag = new BaseService().Delete("News", idList);
            }
            return Json(new { flag = flag, count = count });
        }

        public JsonResult AddNew(News news)
        {
            try
            {
                if (news != null)
                {
                    news.Id = Guid.NewGuid().ToSafeTrim();
                    news.CreateTime = DateTime.Now;
                    if (new BaseService().Insert<News>(news))
                        return Json(new { flag = true, msg = "添加成功" });
                }
                return Json(new { flag = false, msg = "添加失败" });
            }
            catch (Exception e)
            {
                return Json(new { flag = false, msg = "发生异常" });

            }
        }
        [ValidateInput(false)]
        public JsonResult Edit(News news)
        {
            var total = 0;
            var pro = pService.GetList(1, int.MaxValue, out total).FirstOrDefault(x => x.Id == news.Id);
            news.CreateTime = pro.CreateTime;
            if (new BaseService().Update<News>(news))
                return Json(new { flag = true, msg = "修改成功！" });
            return Json(new { flag = false, msg = "修改失败" });
        }

    }
}
