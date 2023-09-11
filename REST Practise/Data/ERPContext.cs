using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using REST_Practise.Model;

namespace REST_Practise.Data
{
    public class ERPContext : DbContext
    {
        public ERPContext(DbContextOptions <ERPContext> options) : base(options)
        {

        }

        

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Salary> Salarys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var roles = new List<Role>()
            {
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name= "admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp= ""

                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name= "user",
                    NormalizedName = "USER",
                    ConcurrencyStamp= ""
                },
            };
            //Seed difficulties to the database
            modelBuilder.Entity<Role>().HasData(roles);
            //////seed data for profiles
            //var profiles = new List<Profile>
            //{
            //    new Profile
            //    {
            //        Id = 1,
            //        UserName = "pasindu",
            //        Email = "pasindu@gmail.com",
            //        Password = "Test@123",
            //        RoleId = 1,
            //        EmployeeId = 1,
            //    }
            //};
            ////Seed difficulties to the database
            //modelBuilder.Entity<Profile>().HasData(profiles);
            //// Seed data for salaries

            //var salaries = new List<Salary>
            //{
            //    new Salary
            //    {
            //        Id = Guid.NewGuid(),
            //        BasicSalary = 100000,
            //        Bonus =60000,
            //        EmployeeId = 1,
            //    },
            //    new Salary
            //    {
            //        Id = Guid.NewGuid(),
            //        BasicSalary = 200000,
            //        Bonus =40000,
            //        EmployeeId = 2,
            //    }
            //};

            ////Seed difficulties to the database
            //modelBuilder.Entity<Salary>().HasData(salaries);

            //var employees = new List<Employee>
            //{
            //    new Employee
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Pasindu Uduwela",
            //        BOD = new DateTime(1996, 8, 17), // Replace with the actual date of birth
            //        Address = "100/128 padukka Road Horana",
            //        Position = "Associate",
            //        ProfileImage = "WWW.pasindu.lk",
            //        DepartmentId = Guid.Parse("17A6E53F-2D1B-416C-8C5D-1A2EBE8F93CB")
            //    },
            //    new Employee
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Kasun Akalanka",
            //        BOD = new DateTime(1990, 5, 15), // Replace with the actual date of birth
            //        Address = "100 Homagama Road Maharagama",
            //        Position = "Associate",
            //        ProfileImage = "WWW.kasun.lk",
            //        DepartmentId = Guid.Parse("2EFA30C4-43C8-4273-8B1D-EB1F46D26C2B")
            //    },

            //};

            ////Seed difficulties to the database
            //modelBuilder.Entity<Employee>().HasData(employees);

            // Seed data for Regions
            var departments = new List<Department>
            {
                new Department
                {
                    Id = Guid.NewGuid(),
                    DepartmentName = "Engineering"
                   
                },
                new Department
                {
                    Id = Guid.NewGuid(),
                    DepartmentName = "Quality Assuarance"

                },
                new Department
                {
                    Id = Guid.NewGuid(),
                    DepartmentName = "Human Resource"

                },
                new Department
                {
                    Id = Guid.NewGuid(),
                    DepartmentName = "Support"

                },
                new Department
                {
                    Id = Guid.NewGuid(),
                    DepartmentName = "Managed Services"

                },
            };
            modelBuilder.Entity<Department>().HasData(departments);
        }
        }
}
