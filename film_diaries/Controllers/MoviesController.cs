using System.Web.Mvc;

namespace film_diaries.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
