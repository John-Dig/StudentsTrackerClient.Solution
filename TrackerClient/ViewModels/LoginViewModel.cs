using System.ComponentModel.DataAnnotations;

namespace TrackerClient.ViewModels
{
  public class LoginViewModel
  {
    [Required(ErrorMessage = "Please add an email!")]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
  }
}