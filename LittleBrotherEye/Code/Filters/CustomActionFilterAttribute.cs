using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace LittleBrotherEye.Code.Filters
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            filterContext.Controller.ViewBag.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            filterContext.Controller.ViewBag.EnableModMode = Convert.ToBoolean(ConfigurationManager.AppSettings["enableModMode"] ?? "false");

        }
    }
}