using System.ComponentModel.DataAnnotations;

namespace HR_Management.UI.Models;

public class RegisterVM
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}