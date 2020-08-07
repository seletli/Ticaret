using ETicaret.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.UI.Web.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {

        // GET: Admin/AdminLogin

        DB db = new DB();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String Email,String Password)
        {
            var data=db.Users.Where(x => x.Email == Email && x.Password == Password && x.IsActive==true && x.IsAdmin==true ).ToList();
            if (data.Count==1)
            {
                //dogru giriş
                Session["AdminLoginUser"] = data.FirstOrDefault();
                return Redirect("/admin");
            }
            else
            {
                //hatalı giriş
                return View();
            }

            
        }
    }
}