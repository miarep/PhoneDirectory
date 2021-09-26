using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneDirectory.Domain.Entity;
using System.IO;

namespace PhoneDirectory.Domain.DAL.EF
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            //Database.Migrate();
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            
            modelBuilder.Entity<Department>()
            .HasOne(a => a.Parent)
            .WithMany(p => p.Childrens)
            .HasForeignKey(p => p.ParentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
            .HasMany(a => a.Positions)
            .WithOne(p => p.Department)
            .HasForeignKey(p => p.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Position>()
            .HasMany(a => a.Employees)
            .WithOne(p => p.Position)
            .HasForeignKey(p => p.PositionId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Department>().HasData(
               new Department { Id = 1, FullName = "Аппарат управления", ShortName = "АУ" },
               new Department { Id = 2, FullName = "Руководство", ShortName = "Руководство", ParentId = 1 },
               new Department { Id = 3, FullName = "Службы генерального директора", ShortName = "СГД", ParentId = 1 },
               new Department { Id = 4, FullName = "Служба общественных коммуникаций", ShortName = "СОК", ParentId = 3 },
               new Department { Id = 5, FullName = "Юридический отдел", ShortName = "ЮО", ParentId = 3 },
               new Department { Id = 6, FullName = "Службы главного инженера", ShortName = "СГИ", ParentId = 1 }
               );

            modelBuilder.Entity<Position>().HasData(
                new Position { Id = 1, Name = "Генеральный директор", DepartmentId = 2 },
                new Position { Id = 2, Name = "Главный инженер", DepartmentId = 2 },
                new Position { Id = 3, Name = "Начальник службы", DepartmentId = 4 },
                new Position { Id = 4, Name = "Ведущий специалист", DepartmentId = 4 },
                new Position { Id = 5, Name = "Специалист 1 категории", DepartmentId = 4 },
                new Position { Id = 6, Name = "Специалист 2 категории", DepartmentId = 4 },
                new Position { Id = 7, Name = "Начальник отдела", DepartmentId = 5 }
                );

            modelBuilder.Entity<Employee>().HasData(
               new Employee { Id = 1, FIO = "Иванов Иван Иванович", BirthDate = System.DateTime.Now, Email = "ivanov@mail.ru", MobilePhone = "+7-777-777-77-77", Phone = "40-40-40", Password = "1234", PhotoPath = "/worker.png", PositionId = 1, TabelNumber = 1 },
               new Employee { Id = 2, FIO = "Петров Иван Иванович", BirthDate = System.DateTime.Now, Email = "petrov@mail.ru", MobilePhone = "+7-888-777-77-77", Phone = "50-40-40", Password = "1234", PhotoPath = "/worker.png", PositionId = 2, TabelNumber = 2 },
               new Employee { Id = 3, FIO = "Сидоров Иван Иванович", BirthDate = System.DateTime.Now, Email = "sidorov@mail.ru", MobilePhone = "+7-999-777-77-77", Phone = "60-40-40", Password = "1234", PhotoPath = "/worker.png", PositionId = 3, TabelNumber = 3 },
               new Employee { Id = 4, FIO = "Сергеев Иван Иванович", BirthDate = System.DateTime.Now, Email = "sergeev@mail.ru", MobilePhone = "+7-111-777-77-77", Phone = "70-40-40", Password = "1234", PhotoPath = "/worker.png", PositionId = 4, TabelNumber = 4 },
               new Employee { Id = 5, FIO = "Антонов Иван Иванович", BirthDate = System.DateTime.Now, Email = "antonov@mail.ru", MobilePhone = "+7-222-777-77-77", Phone = "80-40-40", Password = "1234", PhotoPath = "/worker.png", PositionId = 5, TabelNumber = 5 },
               new Employee { Id = 6, FIO = "Тестов Антон Сергеевич", BirthDate = System.DateTime.Now, Email = "testov@mail.ru", MobilePhone = "+7-33-777-77-77", Phone = "90-40-40", Password = "1234", PhotoPath = "/worker.png", PositionId = 6, TabelNumber = 6 }
               );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("PhoneDirectory");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

    }
}
