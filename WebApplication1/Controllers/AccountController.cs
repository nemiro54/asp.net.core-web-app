using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModels;
using WebApplication1.Models;
using Microsoft.AspNetCore.Identity;
 
namespace WebApplication1.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
 
    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if(ModelState.IsValid)
        {
            User user = new User { Email = model.Email, UserName = model.Email};
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            } 
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }
        return View(model);
    }
}