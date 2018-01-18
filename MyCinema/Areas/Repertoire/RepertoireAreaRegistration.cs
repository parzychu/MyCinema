using System.Web.Mvc;

namespace MyCinema.Areas.Repertoire
{
    public class RepertoireAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Repertoire";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Repertoire_default",
                "Repertoire/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}