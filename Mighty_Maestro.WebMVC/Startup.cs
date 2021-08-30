using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Mighty_Maestro.Data;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mighty_Maestro.WebMVC.Startup))]
namespace Mighty_Maestro.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // Tried seeding data/venues here. Nope! Done in the Configuration.cs!
        }

        //private void createRolesandUsers()  // Doesn't look like any of this method/code is doing anything
        //{
        //    ApplicationDbContext context = new ApplicationDbContext();

        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        //    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

        //    if (!roleManager.RoleExists("Instructor"))
        //    {
        //        var role = new IdentityRole();
        //        role.Name = "Instructor";
        //        roleManager.Create(role);
        //    }

        //    var user = new ApplicationUser();
        //    user.UserName = "Maesto_Moderator";
        //    user.Email = "mmaestro@maestro.net";

        //    string userPWD = "maestr0M@gic";

        //    var chkUser = UserManager.Create(user, userPWD);

        //    if (chkUser.Succeeded)
        //    {
        //        UserManager.AddToRole(user.Id, "Instructor");
        //    }
        //}
    }
}
    //        if (!roleManager.RoleExists("Manager"))
    //        {
    //            var role = new IdentityRole();
    //    role.Name = "Manager";
    //            roleManager.Create(role);
    //        }
    //        if (!roleManager.RoleExists("Employeee"))
    //        {
    //            var role = new IdentityRole();
    //role.Name = "Employeee";
    //            roleManager.Create(role);
    //        }