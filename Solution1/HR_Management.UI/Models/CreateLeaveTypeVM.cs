using System.ComponentModel.DataAnnotations;

namespace HR_Management.UI.Models;

public class CreateLeaveTypeVM
{
    [Required]
    public string Name { get; set; }
    [Required]
    [Display(Name = "Default Day")]
    public int DefaultDay { get; set; }
}