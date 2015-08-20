using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using sniper.service.Models;
using sniper.service;

namespace sniper.Controllers
{
    public class ProductController : Controller
    {
        CategoryService categoryService = null;
        ProductService productService = null;
        public ProductController()
        {
            categoryService = new CategoryService();
            productService = new ProductService();
        }

        public ActionResult Index()
        {
            var model = categoryService.Get();
            return View(model);
        }

        public ActionResult SearchResult(string categoryId)
        {
            var productList = new List<Product>();
            if (string.IsNullOrEmpty(categoryId))
            {
                var total = 0;
                productList = productService.GetList(1, int.MaxValue, out total);
            }
            else
                productList = productService.GetListByCategory(categoryId);
            return View(productList);
        }

        public ActionResult Details(string productId)
        {
            var model = productService.Details(productId);
            model.Item1.CategoryId = categoryService.Get().FirstOrDefault(e => e.Id == model.Item1.CategoryId).Name;
            return View(model);
        }

    }
}
