using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Models;

public class DataSeed
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new WebApplication1Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<WebApplication1Context>>());

        if (context.Users.Any())
        {
            return;
        }

        context.Users.AddRange(
            new User()
            {
                Name = "admin_john",
                Email = "admin@gmail.com",
                RegistrationDate = DateTime.Parse("2022-9-20"),
                LastLoginDate = DateTime.Now
            },
                
            new User()
            {
                Name = "Katy",
                Email = "katy@yahoo.com",
                RegistrationDate = DateTime.Parse("2022-9-21"),
                LastLoginDate = DateTime.Now
            }
        );
        context.SaveChanges();
    }
}