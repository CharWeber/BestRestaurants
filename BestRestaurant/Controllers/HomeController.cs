using Microsoft.AspNetCore.Mvc;

namespace BestRestaurant.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}