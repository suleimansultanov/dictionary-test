﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            }

            return webHost;
        }
    }
}
