using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SimpleAutherizationFilter_ForStartupWebApi.Authentications
{
    public class BasicAuthentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);

            }
            else
            {
                var token = actionContext.Request.Headers.Authorization.Parameter;
                var detoken = Encoding.ASCII.GetString(Convert.FromBase64String(token));
                string username = detoken.Substring(0,detoken.IndexOf(":"));
                string password = detoken.Substring(detoken.IndexOf(":")+1);



                if (username != "admin" || password != "abc")
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }

            }
            base.OnActionExecuting(actionContext);
        }
    }
}