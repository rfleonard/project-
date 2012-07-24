<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OOPenaltyPoints
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              "Search", // Route name
              "DriverOffence/Search/{id}", // URL with parameters
               new { controller = "DriverOffence", action = "Search" } // Parameter defaults
            );

            routes.MapRoute(
             "Statistics", // Route name
             "DriverOffence/Statistics/{id}", // URL with parameters
              new { controller = "DriverOffence", action = "Statistics" } // Parameter defaults
           );

            routes.MapRoute(
             "DailyTasks", // Route name
             "DriverOffence/DailyTasks/{id}", // URL with parameters
              new { controller = "DriverOffence", action = "DailyTasks" } // Parameter defaults
           );


            //routes.MapRoute(
            //     "ListedOffences", // Route name
            //     "{controller}/{action}/{id}", // URL with parameters
            //      new { controller = "ListedOffence", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            //);



           routes.MapRoute(
                "Default", // Route name
               "{controller}/{action}/{id}", // URL with parameters
               new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
           );






        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OOPenaltyPoints
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              "Search", // Route name
              "DriverOffence/Search/{id}", // URL with parameters
               new { controller = "DriverOffence", action = "Search" } // Parameter defaults
            );

            routes.MapRoute(
             "Statistics", // Route name
             "DriverOffence/Statistics/{id}", // URL with parameters
              new { controller = "DriverOffence", action = "Statistics" } // Parameter defaults
           );

            routes.MapRoute(
             "DailyTasks", // Route name
             "DriverOffence/DailyTasks/{id}", // URL with parameters
              new { controller = "DriverOffence", action = "DailyTasks" } // Parameter defaults
           );


            //routes.MapRoute(
            //     "ListedOffences", // Route name
            //     "{controller}/{action}/{id}", // URL with parameters
            //      new { controller = "ListedOffence", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            //);



           routes.MapRoute(
                "Default", // Route name
               "{controller}/{action}/{id}", // URL with parameters
               new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
           );






        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
>>>>>>> Added Unit Test & soa
}