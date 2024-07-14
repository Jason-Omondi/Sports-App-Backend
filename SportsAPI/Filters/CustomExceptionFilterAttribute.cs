using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace SportsAPI.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is DbUpdateException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("A database error occurred. Please try again."),
                    ReasonPhrase = "Database Error"
                };
            }
            else
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Something is not right. Please try again later."),
                    ReasonPhrase = "Internal Server Error"
                };
            }
        }
    }
}