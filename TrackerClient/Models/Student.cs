using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.ComponentModel.DataAnnotations;

namespace TrackerClient.Models
{
  public class Student
  {
    public int StudentId { get; set; }
    public string FirstN { get; set; }
    public string LastN { get; set; }
    public string Email { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MMMM d, yyyy}", ApplyFormatInEditMode = false)]
    public DateTime DateEnrolled { get; set; }
    public string BeltId { get; set; }

    public static List<Student> GetStudents()
    {
      Task<string> apiCallTask = ApiHelper.GetAll("students");
      string result =  apiCallTask.Result;
      
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      
      List<Student> studentList = JsonConvert.DeserializeObject<List<Student>>(jsonResponse.ToString());      
      return studentList;
    }

    public static Student GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id, "students");
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Student student = JsonConvert.DeserializeObject<Student>(jsonResponse.ToString());

      return student;
    }

    public static void Post(Student student)
    {
      string jsonStudent = JsonConvert.SerializeObject(student);
      ApiHelper.Post(jsonStudent, "students");
    }

    public static void Put(Student editedStudent)
    {
      string jsonStudent = JsonConvert.SerializeObject(editedStudent);
      ApiHelper.Put(editedStudent.StudentId, jsonStudent, "students");
    }

    public static void Delete(int id)
    {
      ApiHelper.Delete(id, "students");
    }

  }
}