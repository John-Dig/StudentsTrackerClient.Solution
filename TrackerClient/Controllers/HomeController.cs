using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TrackerClient.Models;
using TrackerClient.ViewModels;

namespace TrackerClient.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult RegisterIndex(RegisterViewModel registerError)
    {
        List<Student> students = Student.GetStudents();
        List<Coach> coaches = Coach.GetCoaches();
        ViewBag.Students = students;
        ViewBag.Coaches = coaches;
        if (registerError != null)
        {
            return  View(registerError);
        } else {
            return View();
        }
    }

    public IActionResult Index()
    {
        List<Student> students = Student.GetStudents();
        List<Coach> coaches = Coach.GetCoaches();
        ViewBag.Students = students;
        ViewBag.Coaches = coaches;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
