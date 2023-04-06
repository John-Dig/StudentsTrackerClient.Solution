using System.Threading.Tasks;
using RestSharp;
using System.Linq;


namespace TrackerClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAll(string modelType)
    {
      RestClient client = new RestClient("http://localhost:5288/");
      RestRequest request = new RestRequest($"api/{modelType}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id, string modelType)
    {
      RestClient client = new RestClient("http://localhost:5288/");
      RestRequest request = new RestRequest($"api/{modelType}/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async void Post(string newPerson, string modelType)
    {
      RestClient client = new RestClient("http://localhost:5288/");
      RestRequest request = new RestRequest($"api/{modelType}", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPerson);
      await client.PostAsync(request);
    }

    public static async void Put(int id, string editedPerson, string modelType)
    {
      RestClient client = new RestClient("http://localhost:5288/");
      RestRequest request = new RestRequest($"api/{modelType}/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(editedPerson);
      await client.PutAsync(request);
    }

    public static async void Delete(int id, string modelType)
    {
      RestClient client = new RestClient("http://localhost:5288/");
      RestRequest request = new RestRequest($"api/{modelType}/{id}", Method.Delete);
      request.AddHeader("Content-Type", "application/json");
      await client.DeleteAsync(request);
    }
  }
}
