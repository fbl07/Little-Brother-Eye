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
    public class CodeTableController : ApiController
    {
        public Models.API.CodeTableDTO Get(int id, bool? sort = true)
        {
            using (var daCT = new DataAccess.DataAccessObjects.CodeTables())
            {
                var result = daCT.GetCodeTable(id);

                if (result == null)
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "This item does not exist."));
                else
                {
                    var list = daCT.DropDownForCodeTable((Constants.CodeTables)id, (sort.HasValue && sort.Value));

                    return new Models.API.CodeTableDTO()
                    {
                        Id = result.CodeTableId,
                        Description = result.Name,
                        Values = list.Select(x => new Models.API.CodeValueDTO()
                        {
                            CodeTableId = result.CodeTableId,
                            CodeValue = x.Key,
                            Description = x.Value
                        })
                    };
                }
            }
        }
    }
}
