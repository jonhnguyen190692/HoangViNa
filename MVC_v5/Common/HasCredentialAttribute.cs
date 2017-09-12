using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_v5.Common
{
    public class HasCredentialAttribute : AuthorizeAttribute
    {
        public string RoleID { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //var isAuthorized = base.AuthorizeCore(httpContext);
            //if (!isAuthorized)
            //{
            //    return false;
            //}
            var session = (UserLogin) HttpContext.Current.Session[CommonConstants.USER_SESSION];
            if (session==null)
            {
                return false;
            }
            List<string> privilegeLevels = GetCredentialByLoggedInUser(session.UserName);
            if (privilegeLevels.Contains(this.RoleID)||session.GroupID==global::Common.CommonConstants.ADMIN_GROUP)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/Shared/401.cshtml"
            };
        }

        private List<String> GetCredentialByLoggedInUser(string userName)
        {
            var credentials = (List<String>) HttpContext.Current.Session[CommonConstants.SESSION_CREDENTIALS];
            return credentials;
        }
    }
}