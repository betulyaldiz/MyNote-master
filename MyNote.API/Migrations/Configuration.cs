namespace MyNote.API.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MyNote.API.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyNote.API.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyNote.API.Models.ApplicationDbContext context)
        {  //https://stackoverflow.com/questions/19280527/mvc-5-seed-users-and-roles

            var userName = "betulbulut94@gmail.com";
            if (!context.Users.Any(u => u.UserName == userName))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = userName ,Email=userName,EmailConfirmed=true};

                manager.Create(user, "Password1.");

                for (int i = 1; i <= 5; i++)
                {
                context.Notes.Add(new Note
                {
                    AuthorId=user.Id,
                    Title= "Sample Note "+i,
                    Content= "Sed ut perspiciatis unde omnis iste natus error sit",
                    CreationTime=DateTime.Now,
                    ModificationTime=DateTime.Now
                });

                }
            }


        }
    }
}
