using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TrackerClient.Models;

namespace TrackerClient.Controllers;

public class CoachesController : Controller
{

        public IActionResult Index()
    {
        List<Coach> coaches = Coach.GetCoaches();
        return View(coaches);
    }
    public IActionResult Details(int id)
    {
        Coach thisCoach = Coach.GetDetails(id);
        return View(thisCoach);
    }

    [HttpPost]
    public IActionResult Create(Coach coach)
    {
        Coach.Post(coach);
        return RedirectToAction("Index","Home");
    }

    [HttpPost]
    public IActionResult Edit(Coach coach)
    {
        Coach.Put(coach);
        return RedirectToAction("Details","Coaches", new { id = coach.CoachId });
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        Coach.Delete(id);
        return RedirectToAction("Index","Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}