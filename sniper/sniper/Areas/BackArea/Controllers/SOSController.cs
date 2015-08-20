using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sniper.service;

namespace sniper.Areas.BackArea.Controllers
{
    public class SOSController : Controller
    {
        //
        // GET: /BackArea/SOS/

        public ActionResult LoginOn()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LogIn(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                if (password.ToMD5().CompareIgnoreCase(ConfigurationManager.AppSettings["aPassword"].ToSafeTrim()))
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie("admin", false);
                    return Json(new { flag = true, msg = "登录成功" });
                }
            }
            return Json(new { flag = false, msg = "密码错误，请重试！" });
        }
    }
}
