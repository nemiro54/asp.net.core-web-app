using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Display(Name = "Status")]
    public Role Role { get; set; }

    [Display(Name = "Registration Date")]
    [DataType(DataType.Date)]
    public DateTime RegistrationDate { get; set; }

    [Display(Name = "Last Login Date")]
    [DataType(DataType.Date)]
    public DateTime LastLoginDate { get; set; }
}