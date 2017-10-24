using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LittleBrotherEye.Code.Filters
{
    public class ErrorLogFilterAttribute : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            using (var daError = new DataAccess.DataAccessObjects.ErrorLog())
                daError.LogError(filterContext.Exception, filterContext.HttpContext.Request.RawUrl);

            filterContext.ExceptionHandled = false;
        }
    }
}