using ECommerce.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.InfraData.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                IdentityResult result = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult result = _roleManager.CreateAsync(role).Result;
            }
        }


        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("admin@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.Email = "admin@gmail.com";
                user.NormalizedEmail = "ADMIN@GMAIL.COM";
                user.UserName = "admin@gmail.com";
                user.NormalizedUserName = "ADMIN@GMAIL.COM";
                user.LockoutEnabled = false;
                user.EmailConfirmed = true;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "@Linkedin23k+").Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("user@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.Email = "user@gmail.com";
                user.NormalizedEmail = "USER@GMAIL.COM";
                user.UserName = "user@gmail.com";
                user.NormalizedUserName = "USER@GMAIL.COM";
                user.LockoutEnabled = false;
                user.EmailConfirmed = true;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "@Linkedin23k+").Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
        }
    }
}
