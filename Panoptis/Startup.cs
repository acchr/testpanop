using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Panoptis.Models;

[assembly: OwinStartupAttribute(typeof(Panoptis.Startup))]
namespace Panoptis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website      
                var user1 = new ApplicationUser();
                user1.UserName = "admin@admin.com";
                user1.Email = "admin@admin.com";

                string userPWD = "test123";

                var chkUser = UserManager.Create(user1, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user1.Id, "Admin");



                }


            }
            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Requestor"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Requestor";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website      
                var user1 = new ApplicationUser();
                user1.UserName = "requestor@admin.com";
                user1.Email = "requestor@admin.com";

                string userPWD = "test123";

                var chkUser = UserManager.Create(user1, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user1.Id, "Requestor");



                }


            }
            if (!roleManager.RoleExists("Journalist"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Journalist";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website      
                var user1 = new ApplicationUser();
                user1.UserName = "Journalist@admin.com";
                user1.Email = "Journalist@admin.com";

                string userPWD = "test123";

                var chkUser = UserManager.Create(user1, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user1.Id, "Journalist");



                }


            }

        }
    }

   
}
