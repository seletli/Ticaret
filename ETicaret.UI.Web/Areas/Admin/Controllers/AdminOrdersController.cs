using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ETicaret.Core.Model;
using ETicaret.Core.Model.Entity;

namespace ETicaret.UI.Web.Areas.Admin.Controllers
{

    public class AdminOrdersController : Controller
    {
        private DB db = new DB();

        // GET: Admin/AdminOrders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(x => x.Status).Include(x => x.User).Include(x => x.UserAddress).ToList();

            return View(orders);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }


        public ActionResult Delete(int? id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {

            var order = db.Orders.Find(id);




            User user = db.Users.Find(order.UserID);
            ViewBag.user = user.Name;

            var statusID = order.StatusID;

            var status = db.Statuses.Find(statusID);
            ViewBag.status = status.Name;


            Dictionary<int, string> statuses = new Dictionary<int, string>();
            statuses.Clear();

            foreach (var item in db.Statuses.ToList())
            {
                statuses.Add(item.ID, item.Name);
            }


            ViewBag.statuses = statuses;

            return View(order);
        }

       
        
        [HttpPost]
    public ActionResult edit(FormCollection form,int? id)
        {
            ETicaret.Core.Model.Entity.Order order=db.Orders.Find(id);

            var a = form.GetValue("Status");
            order.StatusID= Convert.ToInt32(a.AttemptedValue);
            DbEntityEntry entry = db.Entry(order);
            entry.CurrentValues.SetValues(order);
            db.SaveChanges();

            
            return RedirectToAction("Index");
        
        }
    
    
    }

}