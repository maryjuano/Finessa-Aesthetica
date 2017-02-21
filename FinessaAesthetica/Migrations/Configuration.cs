namespace FinessaAesthetica.Migrations
{
    using FinessaAesthetica.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinessaAesthetica.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FinessaAesthetica.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Users.AddOrUpdate(p => p.UserName,
         new Users
         {
             EmployeeId = "Employee-001",
             UserName = "jcadiao",
             Password = "pass@word1",
             FirstName = "Joseph",
             MiddleName = "Fabillar",
             LastName = "Cadiao"
         },
         new Users
         {
             EmployeeId = "Employee-002",
             UserName = "gperdido",
             Password = "pass@word1",
             FirstName = "Gemo Ian",
             MiddleName = "",
             LastName = "Perdido"
         },
         new Users
         {
             EmployeeId = "Employee-003",
             UserName = "mdominguez",
             Password = "pass@word1",
             FirstName = "Alyssa Janelle",
             MiddleName = "Quilenderino",
             LastName = "Dominguez"
         });

            context.Status.AddOrUpdate(s => s.Description,
                new Status
                {
                    Description = "Active"
                },
                new Status
                {
                    Description = "Inactive"
                });

            //context.Colors.AddOrUpdate(c => c.Code,
            //    new Color
            //    {
            //        Code = "Red",
            //        Description = "Colorful",
            //        StatusId = 1,
            //        CreatedOn = DateTime.Now.ToUniversalTime(),
            //        LastModifiedOn = DateTime.Now.ToUniversalTime(),
            //        CreatedById = 1
            //    },
            //     new Color
            //     {
            //         Code = "Green",
            //         Description = "Colorful",
            //         StatusId = 1,
            //         CreatedOn = DateTime.Now.ToUniversalTime(),
            //         LastModifiedOn = DateTime.Now.ToUniversalTime(),
            //         CreatedById = 2
            //     },
            //      new Color
            //      {
            //          Code = "Blue",
            //          Description = "Colorful",
            //          StatusId = 1,
            //          CreatedOn = DateTime.Now.ToUniversalTime(),
            //          LastModifiedOn = DateTime.Now.ToUniversalTime(),
            //          CreatedById = 3
            //      });

            //context.Categories.AddOrUpdate(c => c.Code,
            //    new Category
            //    {
            //        Code = "CATEGORY-001",
            //        Description = "Category 001",
            //        StatusId = 1,
            //        CreatedOn = DateTime.Now.ToUniversalTime(),
            //        LastModifiedOn = DateTime.Now.ToUniversalTime(),
            //        CreatedById = 1
            //    },
            //    new Category
            //    {
            //        Code = "CATEGORY-002",
            //        Description = "Category 002",
            //        StatusId = 1,
            //        CreatedOn = DateTime.Now.ToUniversalTime(),
            //        LastModifiedOn = DateTime.Now.ToUniversalTime(),
            //        CreatedById = 2
            //    },
            //    new Category
            //    {
            //        Code = "CATEGORY-003",
            //        Description = "Category 003",
            //        StatusId = 1,
            //        CreatedOn = DateTime.Now.ToUniversalTime(),
            //        LastModifiedOn = DateTime.Now.ToUniversalTime(),
            //        CreatedById = 3
            //    });
        }
    }
}
