using System.Web.Mvc;

namespace sniper.Areas.BackArea
{
    public class BackAreaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BackArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BackArea_default",
                "BackArea/{controller}/{action}/{id}",
                new { control = "Product", action = "Index", id = UrlParameter.Optional },
                new string[] { "sniper.Areas.BackArea.Controllers" }
            );
        }
    }
}
