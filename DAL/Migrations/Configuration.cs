namespace DAL.Migrations
{
    using Entity.Identity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Context.AliBabaContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            ContextKey = "DAL.Context.AliBabaContext";
        }

        //protected override void Seed(DAL.Context.AliBabaContext context)
        //{
        //    if (context.Kategori.Any())
        //    {
        //        var store = new UserStore<ApplicationUser>(context);
        //        var manager = new UserManager<ApplicationUser, string>(store);
        //        var user = new ApplicationUser() { Email = "osmanulusan34@gmail.com", UserName = "osmanulusan34@gmail.com" };
        //        Task<Microsoft.AspNet.Identity.IdentityResult> task = Task.Run(() => manager.CreateAsync(user, "Osman.12345"));
        //        var result = task.Result;
        //        context.SaveChanges();
        //    }
        //}
    }
}
