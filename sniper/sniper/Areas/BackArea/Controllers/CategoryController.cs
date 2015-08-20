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
    public class CategoryController : Controller
    {
        //
        // GET: /BackArea/Category/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string GetList(int page, int rows)
        {
            var list = new CategoryService().Get();
            return list.ToJson(list.Count);
        }

        //public JsonResult AddNew(Category category)
        //{
        //    category.Id = Guid.NewGuid().ToSafeTrim();
        //    var res = new BaseService().Insert<Category>(category);
        //    if (res)
        //    {
        //        return Json(new { flag = res, msg = "添加成功！" });
        //    }
        //    else {
        //        return Json(new { flag = res, msg = "添加失败！" });
        //    }
        //}

        public JsonResult Edit(Category category)
        {
            var res = false;
            if (category.Id != null && category.Id != Guid.Empty.ToSafeTrim())
                res = new BaseService().Update<Category>(category);
            else
            {
                category.Id = Guid.NewGuid().ToSafeTrim();
                res = new BaseService().Insert<Category>(category);
            }
            if (res)
            {
                return Json(new { flag = res, msg = "操作成功！" });
            }
            else
            {
                return Json(new { flag = res, msg = "操作失败！" });
            }
        }

        public JsonResult DeleteItems(string idList)
        {
            var flag = false;
            var count = 0;
            if (idList != null)
            {
                count = idList.Split(',').Count();
                flag = new BaseService().Delete("Category", idList);
            }
            return Json(new { flag = flag, count = count });
        }
    }
}
