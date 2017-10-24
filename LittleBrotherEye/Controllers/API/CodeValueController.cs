using LittleBrotherEye.Code.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LittleBrotherEye.Controllers.API
{
    [APIKeyRequired]
    public class CodeValueController : ApiController
    {
        public Models.API.CodeValueDTO Get(int id)
        {
            using (var daCT = new DataAccess.DataAccessObjects.CodeTables())
            {
                var result = daCT.GetCodeValue(id);

                if (result == null)
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "This item does not exist."));
                else
                    return new Models.API.CodeValueDTO()
                    {
                        CodeTableId = result.CodeTableId,
                        CodeValue = result.CodeValue1,
                        Description = result.Description
                    };
            }
        }
    }
}
