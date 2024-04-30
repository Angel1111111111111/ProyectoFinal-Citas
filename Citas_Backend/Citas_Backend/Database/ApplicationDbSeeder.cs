using Microsoft.AspNetCore.Identity;
using todo_list_backend.Entities;

namespace Citas_Backend.Database
{
    public static class ApplicationDbSeeder
    {
        public static async Task LoadDataAsync(
            UserManager<UserEntity> userManager, //crear y modificar usuarios
            RoleManager<IdentityRole> roleManager, //crud con el tema de roles 
            ILoggerFactory loggerFactory //salida de consola para poder ver si funciono bien
            )
        {
            try
            {
                if (!roleManager.Roles.Any())
                {
                    await roleManager.CreateAsync(new IdentityRole("USER"));
                    await roleManager.CreateAsync(new IdentityRole("ADMIN"));
                }

                if (!userManager.Users.Any())
                {
                    var userAdmin = new UserEntity
                    {
                        FirstName = "Juan",
                        LastName = "Perez",
                        Email = "jperez@me.com",
                        UserName = "jperez@me.com"
                    };

                    await userManager.CreateAsync(userAdmin, "Temporal001*");
                    await userManager.AddToRoleAsync(userAdmin, "ADMIN");

                    var normalUser = new UserEntity
                    {
                        FirstName = "Maria",
                        LastName = "Perez",
                        Email = "mperez@me.com",
                        UserName = "mperez@me.com"
                    };

                    await userManager.CreateAsync(normalUser, "Temporal001*");
                    await userManager.AddToRoleAsync(normalUser, "USER");
                }
            }
            catch (Exception e)
            {

                var logger = loggerFactory.CreateLogger<ApplicationDbContext>();
                logger.LogError(e.Message);
            }
        }
    }
}