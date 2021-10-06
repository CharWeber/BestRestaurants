using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}