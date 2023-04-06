using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.ComponentModel.DataAnnotations;

namespace TrackerClient.Models
{
public class Promotion
  {
    public int PromotionId { get; set; }

    public int StudentId { get; set; }

    public int CoachId { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MMMM d, yyyy}", ApplyFormatInEditMode = false)]
    public DateTime PromotionDate { get; set; }

    public Student Student { get; set; }

    public Coach Coach { get; set; }


     public static List<Promotion> GetAll()
    {
        Task<string> apiCallTask = ApiHelper.GetAll("promotions");
      string result =  apiCallTask.Result;
      
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      
      List<Promotion> promotionList = JsonConvert.DeserializeObject<List<Promotion>>(jsonResponse.ToString());      
      return promotionList;
    }

    // public static List<Promotion> GetPromotionsForPair(int studentId, int coachId)
    // {
    //   // var apiCallTask = ApiHelper.Get(id, "promotions");
    //   // var result = apiCallTask.Result;

    //   // JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
    //   // Promotion promotion = JsonConvert.DeserializeObject<Promotion>(jsonResponse.ToString());
    //   List<Promotion> filteredList = GetAll().Where(x => x.StudentId == studentId && x.CoachId == coachId).ToList();

    //   return filteredList;
    // }
    public static Promotion GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id, "promotions");
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Promotion promotion = JsonConvert.DeserializeObject<Promotion>(jsonResponse.ToString());

      return promotion;
    }
    
    public static void Post(Promotion promotion)
    {
      string jsonPromotion = JsonConvert.SerializeObject(promotion);
      
      ApiHelper.PostPromotion(jsonPromotion);
    }

    public static void Put(Promotion editedPromotion)
    {
      string jsonPromotion = JsonConvert.SerializeObject(editedPromotion);
      ApiHelper.Put(editedPromotion.PromotionId, jsonPromotion, "promotions");
    }

    public static void Delete(int id)
    {
      ApiHelper.Delete(id, "promotions");
    }
  }




    // public ActionResult AddEngineer(int id)
    // {
    //   Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
    //   ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "FirstName");
    //   return View(thisMachine);
    // }

    // [HttpPost]
    // public ActionResult AddEngineer(Machine machine, int engineerId)
    // {
    //   #nullable enable
    //   EngineerMachine? joinEntity = _db.EngineerMachines.FirstOrDefault(join => (join.EngineerId == engineerId && join.MachineId == machine.MachineId));
    //   #nullable disable
    //   if (joinEntity == null && engineerId != 0)
    //   {
    //     _db.EngineerMachines.Add(new EngineerMachine() { MachineId = machine.MachineId, EngineerId = engineerId });
    //     _db.SaveChanges();
    //   }
    //   return RedirectToAction("Details", new { id = machine.MachineId });
    // }

    // [HttpPost]
    // public ActionResult DeleteJoin(int joinId, int machineId)
    // {
    //   EngineerMachine joinEntry = _db.EngineerMachines.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
    //   _db.EngineerMachines.Remove(joinEntry);
    //   _db.SaveChanges();
    //   return RedirectToAction("Details", new { id = machineId });
    // }
}