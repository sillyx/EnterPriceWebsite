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
                new { controller = "SOS", action = "LoginOn", id = UrlParameter.Optional },
                new string[] { "sniper.Areas.BackArea.Controllers" }
            );
        }
    }
}
