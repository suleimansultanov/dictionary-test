using System.Collections.Generic;
using System.IO;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Infrastructure
{
    internal static class DbContextJsonSeeder
    {
        internal static void SeedJsonData(ModelBuilder modelBuilder)
        {
            var currentPath = Directory.GetCurrentDirectory();
            var path = currentPath + "\\words.json";
            var jsonData = JsonConvert.DeserializeObject<List<Word>>(File.ReadAllText(path));

            modelBuilder.Entity<Word>().HasData(jsonData);
        }
    }
}
