using System.Web;
using System.Web.Mvc;

namespace LittleBrotherEye
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorHandler.AiHandleErrorAttribute());
            filters.Add(new Code.Filters.CustomActionFilterAttribute());
            filters.Add(new Code.Filters.ErrorLogFilterAttribute());
        }
    }
}
