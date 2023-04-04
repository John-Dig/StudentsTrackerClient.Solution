using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TrackerClient.Models;

namespace TrackerClient.Controllers;

public class CoachesController : Controller
{
     public IActionResult Details(int id)
    {
        Coach thisCoach = Coach.GetDetails(id);
        return View(thisCoach);
    }

    // public IActionResult Details()
    // {
    //     return View();
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
