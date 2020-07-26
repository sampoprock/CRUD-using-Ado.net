using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MobileReview
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Mobile", action = "Index", id = UrlParameter.Optional }
            /*  
             Here I've changed the deafult controller from home to Mobile so the index page of that controller always opens first when we run the application
             */
            );
        }
    }
}
