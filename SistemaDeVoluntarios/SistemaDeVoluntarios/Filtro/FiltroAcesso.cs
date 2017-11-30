using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SistemaDeVoluntarios.Filtro
{
    public class FiltroAcess : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object usuarioLogin = filterContext.HttpContext.Session["usuarioLogin"];
            if (usuarioLogin == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new { action = "Index", controller = "Login" }));
            }

        }

        
    }
}