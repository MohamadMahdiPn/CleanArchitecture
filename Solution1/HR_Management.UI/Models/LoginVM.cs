using System.ComponentModel.DataAnnotations;

namespace HR_Management.UI.Models;

public class LoginVM
{
    [Required]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
   
    public string? ReturnUrl { get; set; }
}