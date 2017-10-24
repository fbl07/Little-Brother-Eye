using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleBrotherEye.DataAccess.DataAccessObjects
{
    public class ErrorLog : BaseDataAccess
    {
        public void LogError(Exception ex, string url)
        {
            var log = new DataAccess.ErrorLog();

            log.Text = ex.GetType().Name + " - " + ex.Message;
            log.Request = url;
            log.StackTrace = ex.StackTrace;
            log.TimeOfError = DateTime.Now;

            int statusCode = 500;
            if (ex is HttpException)
            {
                statusCode = ((HttpException)ex).GetHttpCode();
                log.Text += "\n\nHttp Status Code : " + statusCode.ToString();
            }
            log.StatusCode = statusCode;

            Context.ErrorLogs.Add(log);
            Context.SaveChanges();
        }

        public IQueryable<DataAccess.ErrorLog> ListErrors(int number = 50)
        {
            return Context.ErrorLogs.OrderByDescending(x => x.TimeOfError).Take(number);
        }
    }
}