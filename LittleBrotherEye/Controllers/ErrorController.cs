using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LittleBrotherEye.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            using (var daError = new DataAccess.DataAccessObjects.ErrorLog())
                return View(daError.ListErrors().ToList());
        }

#if DEBUG
        public ActionResult ThrowError()
        {
            throw new Exception("This is a test exception!!");
        }
#endif
    }
}