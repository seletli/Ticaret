using ETicaret.Core.Model.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ETicaret.UI.Web.Controllers
{
    public class ProductController : AndControllerBase
    {
        // GET: Product
        [Route("Urun/{title}/{id}")]
        public ActionResult Detail(string title,int id)
        {
            var db = new DB();
            var prod = db.Products.Where(x => x.ID == id).FirstOrDefault();

            return View(prod);
        }
    }
}