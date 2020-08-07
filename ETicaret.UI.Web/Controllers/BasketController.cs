using ETicaret.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.UI.Web.Controllers
{
    public class BasketController : AndControllerBase
    {
        // GET: Basket
        [HttpPost]
        public JsonResult AddProduct(int productID,int quantity)
        {
            var db = new DB();
            db.Baskets.Add(new Core.Model.Entity.Basket
            {
                CreateDate = DateTime.Now,
                CreateUserID = LoginUserID,
                ProductID = productID,
                Quantity = quantity,
                UserID = LoginUserID
            });
            var rt=db.SaveChanges();
            return Json(rt,JsonRequestBehavior.AllowGet);

        }

        [Route("Sepetim")]
        public ActionResult Index()
        {
            var db = new DB();
            var data = db.Baskets.Include("Product").Where(x => x.UserID == LoginUserID).ToList();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var db = new DB();
            var deleteItem = db.Baskets.Where(x => x.ID == id).FirstOrDefault();

            db.Baskets.Remove(deleteItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}