using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BestRestaurant.Models;
using System.Collections.Generic;
using System.Linq;


namespace BestRestaurant.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly BestRestaurantContext _db;
  
  public RestaurantsController(BestRestaurantContext db)
  {
    _db = db;
  }

  public ActionResult Index()
  {
    List<Restaurant> model = _db.Restaurants.Include(restaurant =>restaurant.Cuisine).ToList();
    return View(model);
  }
  //get create()
  public ActionResult Create()
  {
    ViewBag.CuisineId = new SelectList (_db.Cuisines, "CuisineId", "Name");
    return View();
  }
  //post create()

  [HttpPost]
  public ActionResult Create(Restaurant restaurant)
  {
    _db.Restaurants.Add(restaurant);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  //get edit()
  public ActionResult Edit(int id)
  {
    var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
    ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
    return View(thisRestaurant);
  }
  //post edit()
  [HttpPost]
  public ActionResult Edit(Restaurant restaurant)
  {
    _db.Entry(restaurant).State = EntityState.Modified;
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  //get details
  public ActionResult Details(int id)
  {
    var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
    return View(thisRestaurant);
  }

  //get delete()

  public ActionResult Delete(int id)
  {
    var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
    return View(thisRestaurant);
  }
  //post delete()
  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    var thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
    _db.Remove(thisRestaurant);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  //get search
  public ActionResult Search()
  {
    return View();
  }
  //post search
  [HttpPost]
  public ActionResult Search(string name)
  {
    string searchName = name.ToLower();
    List <Restaurant> theseRestaurants = _db.Restaurants.Include(restaurant => restaurant.Cuisine).Where(restaurant => restaurant.Name.ToLower().Contains(searchName)).ToList();
    return View("Index", theseRestaurants);
  }
  }
}