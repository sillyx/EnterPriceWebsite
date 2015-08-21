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
    public class ProductController : Controller
    {
        ProductService pService = null;
        public ProductController()
        {
            pService = new ProductService();
        }

        public ActionResult Index()
        {
            var categoryService = new CategoryService();
            ViewBag.categories = categoryService.Get();
            return View();
        }

        [HttpPost]
        public string GetList(int page, int rows)
        {
            var total = 0;
            var category = new CategoryService().Get();
            var list = pService.GetList(page, rows, out total);
            foreach (var item in list)
            {
                item.CategoryId = category.FirstOrDefault(e => e.Id == item.CategoryId).Name;
            }
            return list.ToJson(total);
        }

        public JsonResult DeleteItems(string idList)
        {
            var flag = false;
            var count = 0;
            if (idList != null)
            {
                count = idList.Split(',').Count();
                flag = new BaseService().Delete("Product", idList);
            }
            return Json(new { flag = flag, count = count });
        }

        public JsonResult Edit(Product product)
        {
            var total = 0;
            var pro = pService.GetList(1, int.MaxValue, out total).FirstOrDefault(x => x.Id == product.Id);
            product.CreateTime = pro.CreateTime;
            if (product.CategoryId.Length < 36)
                product.CategoryId = pro.CategoryId; //Request.Form["CategoryId"];
            if (new BaseService().Update<Product>(product))
                return Json(new { flag = true, msg = "修改成功！" });
            return Json(new { flag = false, msg = "修改失败" });
        }

        public JsonResult GetCategoryName(string categoryId)
        {
            var category = new CategoryService().Get().FirstOrDefault(e => e.Id == categoryId).Name;
            return Json(new { name = category });
        }

        public JsonResult AddNew(Product product)
        {
            try
            {
                if (product != null)
                {
                    product.Id = Guid.NewGuid().ToSafeTrim();
                    product.CreateTime = DateTime.Now;
                    if (new BaseService().Insert<Product>(product))
                        return Json(new { flag = true, msg = "添加成功" });
                }
                return Json(new { flag = false, msg = "添加失败" });
            }
            catch (Exception e)
            {
                return Json(new { flag = false, msg = "发生异常" });

            }
        }


        public string uploadProImage()
        {
            string memberHeadUrl = string.Empty;
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                MemberHeaderSize settings = new MemberHeaderSize();
                if (file != null && file.ContentLength > 0)
                {
                    try
                    {
                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/"),
                                                       settings.OriginHeaderImagePath);
                        string fileName = Path.Combine(DateTime.Now.ToString("yyyyMMdd"),
                                                       Guid.NewGuid() + Path.GetExtension(file.FileName));

                        ImageHelper.SaveImage(file.InputStream, Path.Combine(filePath, fileName));
                        foreach (KeyValuePair<string, ThumbImage> item in settings.HeaderImageSizes)
                        {
                            ImageHelper.MakeThumb(Path.Combine(filePath, fileName), fileName, item.Value);
                        }
                        memberHeadUrl = "/" + settings.MiddleHeaderImagePath + "/" + fileName;
                        memberHeadUrl = memberHeadUrl.Replace("//", "/").Replace("\\", "/");
                    }
                    catch { }
                }
            }
            return memberHeadUrl.ToJson();
        }
    }
}
