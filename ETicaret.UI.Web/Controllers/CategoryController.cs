using ETicaret.Core.Model.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ETicaret.UI.Web.Controllers
{
    public class CategoryController : AndControllerBase
    {
        // GET: Category
        [Route("Kategori/{isim}/{id}")]
        public ActionResult Index(string isim,int id)
        {
            var db = new DB();
            var data=db.Products.Where(x => x.IsActive == true && x.CategoryID == id).ToList();
            ViewBag.category = db.Categories.Where(x => x.ID == id).FirstOrDefault();
            return View(data);
        }
    }
}