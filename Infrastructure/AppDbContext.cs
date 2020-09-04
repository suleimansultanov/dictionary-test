using System.Collections.Generic;
using System.IO;
using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Infrastructure
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Word> Words { get; set; }
        public DbSet<Language> Language { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(new Language {Id = 1, Name = "Русский"}, new Language{Id = 2, Name = "Английский"});

            DbContextJsonSeeder.SeedJsonData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
