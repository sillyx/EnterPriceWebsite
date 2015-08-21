using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using sniper.service;
//Download by http://www.codefans.net
namespace DemoSwfUpload
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    public class upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                HttpPostedFile file;
                for (int i = 0; i < context.Request.Files.Count; ++i)
                {
                    file = context.Request.Files[i];
                    if (file == null || file.ContentLength == 0 || string.IsNullOrEmpty(file.FileName)) continue;
                    var path = HttpContext.Current.Server.MapPath("/Content/" + file.FileName.Replace(file.FileName.Substring(0, file.FileName.IndexOf(".")), Guid.NewGuid().ToString()));
                    file.SaveAs(path);
                    var url = context.Request.UrlReferrer.Query;
                    var productId = url.Substring(url.IndexOf("=") + 1);
                    var image = new sniper.service.Models.ImageList
                    {
                        Id = Guid.NewGuid().ToString(),
                        ImgSrc = path.Replace(AppDomain.CurrentDomain.BaseDirectory, "\\").Replace("\\","/"),
                        ProductId = productId
                    };
                    new BaseService().Insert<sniper.service.Models.ImageList>(image);
                }
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.Write(ex.Message);
                context.Response.End();
            }
            finally
            {
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
