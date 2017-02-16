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
            ContextKey = "FinessaAesthetica.Models.ApplicationDbContext";
        }

        protected override void Seed(FinessaAesthetica.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            // add default users
            context.Users.AddOrUpdate(
                p => p.EmployeeId,
                new Users
                {
                    EmployeeId = "employee-001",
                    UserName = "alydominguez",
                    Password = "pass@word1",
                    FirstName = "Alyssa Janelle",
                    LastName = "Dominguez",
                    MiddleName = "Quilenderino"
                },
                new Users
                {
                    EmployeeId = "employee-002",
                    UserName = "jcadiao",
                    Password = "pass@word1",
                    FirstName = "Joseph",
                    LastName = "Cadiao",
                    MiddleName = "Fabillar"
                },
                new Users
                {
                    EmployeeId = "employee-003",
                    UserName = "gperdido",
                    Password = "pass@word1",
                    FirstName = "Gemo",
                    LastName = "Perdido",
                    MiddleName = "Ian"
                });
          
        }
    }
}
