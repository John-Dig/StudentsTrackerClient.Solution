using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TrackerClient.Models
{
  public class Coach
  {
    public int CoachId { get; set; }
    public string FirstN { get; set; }
    public string LastN { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int BeltId { get; set; }

    public static List<Coach> GetCoaches()
    {
      Task<string> apiCallTask = ApiHelper.GetAll("coaches");
      string result =  apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      
      List<Coach> coachList = JsonConvert.DeserializeObject<List<Coach>>(jsonResponse.ToString());      
      return coachList;
    }

    public static Coach GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id, "coaches");
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Coach coach = JsonConvert.DeserializeObject<Coach>(jsonResponse.ToString());

      return coach;
    }

    public static void Post(Coach coach)
    {
      string jsonCoach = JsonConvert.SerializeObject(coach);
      ApiHelper.Post(jsonCoach, "coaches");
    }

    public static void Put(Coach editedCoach)
    {
      string jsonCoach = JsonConvert.SerializeObject(editedCoach);
      ApiHelper.Put(editedCoach.CoachId, jsonCoach, "coaches");
    }

    public static void Delete(int id)
    {
      ApiHelper.Delete(id, "coaches");
    }

  }
}