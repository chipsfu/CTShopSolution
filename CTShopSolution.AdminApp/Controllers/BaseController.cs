using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CTShopSolution.AdminApp.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            //var session = HttpContext.Session.GetString("Token");
            //if(session==null)
            //     RedirectToAction("Login", "User");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sessions = context.HttpContext.Session.GetString("Token");
            if (sessions == null)
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
            base.OnActionExecuting(context);
        }
        
    }
}
