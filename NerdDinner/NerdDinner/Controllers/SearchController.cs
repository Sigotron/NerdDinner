using System;
using System.Linq;
using System.Web.Mvc;
using NerdDinner.Models;

public class JsonDinner
{
    public int DinnerId { get; set; }
    public string Title { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Description { get; set; }
    public int RSVPCount { get; set; }
}

public class SearchController : Controller
{

    DinnerRepository _dinnerRepo = new DinnerRepository();

    //
    // AJAX: /Search/SearchByLocation

    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult SearchByLocation(float longitude, float latitude)
    {

        var dinners = _dinnerRepo.FindByLocation(latitude, longitude);
        var jsonDinners = from dinner in dinners
                          select new JsonDinner
                          {
                              DinnerId = dinner.DinnerId,
                              Latitude = (double) dinner.Latitude,
                              Longitude = (double) dinner.Longitude,
                              Title = dinner.Title,
                              Description = dinner.Description,
                              RSVPCount = dinner.RSVPs.Count,
                          };
        var listOfDinners = jsonDinners.ToList();
        return Json(listOfDinners);
    }
}