using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LittleBrotherEye.Controllers
{
    public class DeveloperController : Controller
    {
        // GET: Developer
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult register()
        {
            return View(new Models.APIRegisterModel());
        }

        [HttpPost]
        public ActionResult register (Models.APIRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                using (var daApiKeys = new DataAccess.DataAccessObjects.APIKey())
                {
                    if (daApiKeys.LoadAPIKey(model.Email) != null)
                    {
                        ModelState.AddModelError("Email", "An API key is already registered to this email. To ask for your API key to be resent <a href=\"/developer/recover\">click here</a>");
                        return View(model);
                    }
                    else
                    {
                        daApiKeys.SaveAPIKey(new DataAccess.APIKey()
                        {
                            Email = model.Email,
                            RequestCount = 0
                        });
                        Code.Utilities.SendAPIKey(model.Email);
                        model.confirmation = true;
                    }

                }
            }
            return View(model);
        }

    }
}