
namespace BestRestaurant.Models
{
  public class Restaurant
  {
    public int RestaurantId {get;set;}
    public string Name {get; set;}
    public int Capacity {get;set;}
    public string OutdoorSeating {get;set;}
    public int CuisineId {get;set;}
  }
}