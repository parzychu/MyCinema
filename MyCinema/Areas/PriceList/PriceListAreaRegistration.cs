using System.Web.Mvc;

namespace MyCinema.Areas.PriceList
{
    public class PriceListAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PriceList";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PriceList_default",
                "PriceList/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}