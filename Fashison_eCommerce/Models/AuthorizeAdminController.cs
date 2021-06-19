using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fashison_eCommerce.Models
{
    public class AuthorizeAdminController : ActionFilterAttribute
    {
        DB_A6A231_DAQLTMDTEntities db = new DB_A6A231_DAQLTMDTEntities();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int id = 0;
            if (HttpContext.Current.Session["userID"] != null)
            {
                id = Convert.ToInt32(HttpContext.Current.Session["userID"].ToString());
            }

            var tbus = db.Users.Where(x => x.Id == id).FirstOrDefault();

            if (tbus != null)
            {
  
                if (tbus.RoleID != 1)
                {
                    filterContext.Result = new RedirectResult("~/Admin/Home/Login");
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Admin/Home/Login");
            }

        }
    }
}