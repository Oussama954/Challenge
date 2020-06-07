using System;
using System.Web.Mvc;

namespace Challenge.Web.Filters
{
    public class ExceptionHandler : ActionFilterAttribute, IExceptionFilter

    {
        public void OnException(ExceptionContext filterContext)

        {
            Exception e = filterContext.Exception;

            filterContext.ExceptionHandled = true;

            filterContext.Result = new ViewResult()

            {
                ViewName = "Error"
            };
        }

    }
}