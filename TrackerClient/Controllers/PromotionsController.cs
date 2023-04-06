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

      // [Route("/api/promotions/create")]
        [HttpPost]
        public async Task<ActionResult<Promotion>> CreatePromotion(Student student, int coachId, DateTime promotionDate)
        {
            // #nullable enable
            // Promotion? promotion = _context.Promotions.FirstOrDefault(join => (join.PromotionId == coachId && join.StudentId == student.StudentId));
            // #nullable disable
            // if (promotion == null)
            // {
                _context.Promotions.Add(new Promotion() { StudentId = student.StudentId, PromotionId = coachId, PromotionDate = promotionDate });
                _context.SaveChanges();
                List<Promotion> promotionsList = await _context.Promotions.ToListAsync();
                Promotion mostRecentPromotion = promotionsList.Last();
            // }

//             rocking baby to sleep
            // i listening
            // does  api build ok ?
            return CreatedAtAction("GetPromotion", new { id = mostRecentPromotion.PromotionId }, mostRecentPromotion);
        }

    [HttpPost]
    public IActionResult Create(Promotion promotion)
    {

        Promotion.Post(promotion);
        return RedirectToAction("Index", "Home");
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