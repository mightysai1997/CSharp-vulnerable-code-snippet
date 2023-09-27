using Microsoft.AspNetCore.Identity;

// Inside a method or controller action
var userManager = new UserManager<ApplicationUser>(userStore);

var user = new ApplicationUser
{
    UserName = "username", // Set the desired username
    // You can also set other user properties here
};

var result = await userManager.CreateAsync(user, "password123"); // Provide the desired password

if (result.Succeeded)
{
    // User creation was successful
    // You can add additional code here
}
else
{
    // User creation failed; handle errors
    foreach (var error in result.Errors)
    {
        // Log or handle each error
    }
}
