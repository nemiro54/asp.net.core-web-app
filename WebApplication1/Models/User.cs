using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models;

public class User : IdentityUser
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    public string Status { get; set; }
    
    [Display(Name = "Registration Date")]
    [DataType(DataType.Date)]
    public DateTime RegistrationDate { get; set; }
    
    [Display(Name = "Last Login Date")]
    [DataType(DataType.Date)]
    public DateTime LastLoginDate { get; set; }
    
}