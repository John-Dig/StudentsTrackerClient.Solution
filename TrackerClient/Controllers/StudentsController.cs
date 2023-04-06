using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TrackerClient.Models;

namespace TrackerClient.Controllers;

public class StudentsController : Controller
{

    
    public IActionResult Index()
    {
        List<Student> students = Student.GetStudents();
        return View(students);
    }
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

    [HttpPost]
    public IActionResult Edit(Student student)
    {
        Student.Put(student);
        return RedirectToAction("Details","Students", new { id = student.StudentId });
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        Student.Delete(id);
        return RedirectToAction("Index","Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}