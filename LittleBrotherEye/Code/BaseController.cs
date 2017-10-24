using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LittleBrotherEye.Code
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            var ex = filterContext.Exception;

            var log = new DataAccess.ErrorLog();

            log.Text = String.Format("Server exception : \n\nRequest: {0}\n\nException : {1}", Request.RawUrl, ex.GetType().Name + " - " + ex.Message);
            log.StackTrace = ex.StackTrace;
            log.TimeOfError = DateTime.Now;



            filterContext.ExceptionHandled = true;
        }
    }
}