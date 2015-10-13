namespace ProjectManagementApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectManagementApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectManagementApp.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (roleManager.Roles.Count() != 0) return;
            var testPassword = "123456";
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var adminRole = new IdentityRole() { Id = "ProjectManager", Name = "ProjectManager" };
            roleManager.Create(adminRole);

            var officerRole = new IdentityRole() { Id = "User", Name = "User" };
            roleManager.Create(officerRole);

            var pm = new ApplicationUser()
            {
                Id = "94439738-1ca3-4782-b08d-e173e86dba01",
                UserName = "pm@projectmanager.com",
                Email = "pm@projectmanager.com"
            };

            userManager.Create(pm, testPassword);
            userManager.AddToRole(pm.Id, adminRole.Name);

            var user = new ApplicationUser()
            {
                Id = "d739ab26-36e9-424a-a383-c958b0531378",
                UserName = "user@projectmanager.com",
                Email = "user@projectmanager.com"
            };
            userManager.Create(user, testPassword);
            userManager.AddToRole(user.Id, adminRole.Name);
        }
    }
}
