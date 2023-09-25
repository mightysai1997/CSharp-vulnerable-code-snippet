using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

public class MyUserManager
{
    private UserManager<ApplicationUser> userManager;

    public MyUserManager()
    {
        var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
        userManager = new UserManager<ApplicationUser>(userStore);
    }

    public IdentityResult CreateUser(string username, string password)
    {
        var user = new ApplicationUser { UserName = username };
        return userManager.Create(user, password);
    }
}
