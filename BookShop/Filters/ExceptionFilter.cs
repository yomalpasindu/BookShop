using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace BookShop.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            throw new NotImplementedException();
            //Log.Logger.Error(context.Exception, "An unhandled exception occurred.");


            //if (context.Exception != null)
            //{
            //    Log.Logger.ForContext("SourceContext", context.Exception.Source)
            //               .Error("An unhandled exception occurred. Details: {Exception}", context.Exception);
            //}


            //context.Result = new ObjectResult(new
            //{
            //    StatusCode = 500,
            //    Message = "An error occurred while processing your request."
            //})
            //{
            //    StatusCode = 500
            //};
            //context.ExceptionHandled = true;
        }
    }
}
