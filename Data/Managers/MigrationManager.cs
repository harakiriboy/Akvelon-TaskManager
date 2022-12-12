using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Akvelon_Task_Manager.Data.Managers
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication webapp)
        {
            using (var scope = webapp.Services.CreateScope())                          // Migrate database method to place in Program class
                                                                                       // Needed to make automated migrations 
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<AkvelonTaskManagerDbContext>())  // Getting our database context
                {
                    try 
                    {
                        appContext.Database.Migrate();  // Trying to migrate databases in our context
                    }
                    catch(Exception) 
                    {
                        throw;
                    }
                }
            }

            return webapp;
        }
    }
}