using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace LittleBrotherEye.Code.Filters
{
    public class APIKeyRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            bool validKey = false;

            if (actionContext.Request.Headers.TryGetValues("X-API-KEY", out var headerValue))
            {
                using(var daApiKey = new DataAccess.DataAccessObjects.APIKey())
                {
                    var key = headerValue.FirstOrDefault();
                    if (key != null)
                    {
                        var APIKey = daApiKey.LoadAPIKey(new Guid(key));

                        validKey = APIKey != null;
                    }
                }   
            }

            if (!validKey)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "You must include a valid API key by adding the 'X-API-KEY' header in the request.");
            }

        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Request.Headers.TryGetValues("X-API-KEY", out var headerValue))
            {
                using (var daApiKey = new DataAccess.DataAccessObjects.APIKey())
                {
                    var key = headerValue.FirstOrDefault();
                    if (key != null)
                    {
                        var APIKey = daApiKey.LoadAPIKey(new Guid(key));

                        APIKey.RequestCount += 1;
                        APIKey.LastRequestDt = DateTime.Now;

                        daApiKey.SaveAPIKey(APIKey);
                    }
                }
            }
        }
    }
}