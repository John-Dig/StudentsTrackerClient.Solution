using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TrackerClient.Models;

namespace TrackerClient.Controllers;

public class PromotionsController : Controller
{

    
    public IActionResult Index()
    {
        List<Promotion> promotions = Promotion.GetAll();
        return View(promotions);
    }
    public IActionResult Details(int id)
    {
        Promotion thisPromotion = Promotion.GetDetails(id);
        return View(thisPromotion);
    }

    [HttpPost]
    public IActionResult Create(int studentId, int coachId, DateTime promotionDate)
    {
        Promotion newPromotion = new Promotion() { StudentId = studentId, CoachId = coachId, PromotionDate = promotionDate };
        Promotion.Post(newPromotion);

        Student studentToPromote = Student.GetDetails(studentId);
        // studentToPromote.BeltId = int.Parse(studentToPromote.BeltId);

        // Student.Put(studentToPromote);

        return RedirectToAction("Details", "Students", new { id = studentId });
    }

    [HttpPost]
    public IActionResult Edit(Promotion promotion)
    {
        Promotion.Put(promotion);
        return RedirectToAction("Details","Promotions", new { id = promotion.PromotionId });
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        Promotion.Delete(id);
        return RedirectToAction("Index","Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}