using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BlogEngine.Models;

namespace UBH.TheITBlog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static BlogArticleRepository mainBlog;
        private string rootPath = @"C:\Development\Projects\UBH.TheITBlog\UBH.TheITBlog\blogFiles";

        protected void Application_Start()
        {
            // execute configuration methods
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // check path ad then load the blog entries from the text file
            if (rootPath == null)
            {
                throw new Exception("You have to set the rootPath to your blogFiles directory");
            }
            mainBlog = new BlogArticleRepository(rootPath, "blog.dat");
        }
    }
}
