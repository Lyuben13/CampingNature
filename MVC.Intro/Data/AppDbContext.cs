using Microsoft.EntityFrameworkCore;
using MVC.Intro.Models;

namespace MVC.Intro.Data
{
    public class AppDbContext : DbContext
    {
        public string DbPath { get; }

        public AppDbContext()
            : this(new DbContextOptions<AppDbContext>())
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "products.db");
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<CampingTent> CampingTents { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite($"Data Source={DbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CampingTent>().HasData(
                new CampingTent
                {
                    Id = 1,
                    Name = "Палатка Експлорер",
                    Price = 450.00m,
                    Description = "Луксозна палатка за 4-ма души с водоустойчиво покритие и вентилация",
                    ImagePath = "images/palatka1.jpg",
                    Capacity = 4,
                    IsWaterproof = true,
                    HasVentilation = true,
                    Features = "Водоустойчива, Вентилация, 4-ма души",
                    CreatedAt = new DateTime(2024, 1, 1)
                },
                new CampingTent
                {
                    Id = 2,
                    Name = "Палатка Авантюрист",
                    Price = 280.00m,
                    Description = "Компактна и лека палатка за 2-ма души, идеална за планински преходи",
                    ImagePath = "images/palatka2.jpg",
                    Capacity = 2,
                    IsWaterproof = true,
                    HasVentilation = false,
                    Features = "Лека, Планинска, 2-ма души",
                    CreatedAt = new DateTime(2024, 1, 1)
                },
                new CampingTent
                {
                    Id = 3,
                    Name = "Палатка Семейна",
                    Price = 620.00m,
                    Description = "Голяма семейна палатка с две стаи и тераса за комфорт",
                    ImagePath = "images/palatka3.jpg",
                    Capacity = 6,
                    IsWaterproof = true,
                    HasVentilation = true,
                    Features = "Две стаи, Тераса, 6-ма души",
                    CreatedAt = new DateTime(2024, 1, 1)
                }
            );
        }
    }
}
