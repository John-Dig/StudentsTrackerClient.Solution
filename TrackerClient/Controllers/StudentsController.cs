using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TrackerClient.Models;

namespace TrackerClient.Controllers;

public class StudentsController : Controller
{
    public IActionResult Details(int id)
    {
        Student thisStudent = Student.GetDetails(id);
        return View(thisStudent);
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        Student.Post(student);
        return RedirectToAction("Index","Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}