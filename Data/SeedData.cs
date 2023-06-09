﻿using Microsoft.AspNetCore.Identity;
using WebApp.Models;

namespace WebApp.Data
{
    public interface IIdentityDataInitializer
    {
        Task SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager);
    }

    public class IdentityDataInitializer : IIdentityDataInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public IdentityDataInitializer(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            // Add roles          
            await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("Member"));

            // Add super admin user
            var superAdminEmail = _configuration["SuperAdminDefaultOption:Email"];
            var superAdminUserName = _configuration["SuperAdminDefaultOption:Username"];
            var superAdminPassword = _configuration["SuperAdminDefaultOption:Password"];
            var superAdminUser = new ApplicationUser
            {
                Email = superAdminEmail,
                UserName = superAdminUserName,
                FirstName = "Đoàn",
                LastName = "Quang Huy",
                IsActive = true,
                AvatartPath = "/upload/avatar/blank_avatar.png"
            };
            var adminUser = new ApplicationUser
            {
                Email = "adminUser@gmail.com",
                UserName = "adminUser",
                FirstName = "Người Dùng",
                LastName = "1",
                IsActive = true,
                AvatartPath = "/upload/avatar/blank_avatar.png"
            };
            var memberUser = new ApplicationUser
            {
                Email = "memberUser@gmail.com",
                UserName = "memberUser",
                FirstName = "Khách Hàng",
                LastName = "1",
                IsActive = true,
                AvatartPath = "upload/avatar/blank_avatar.png"
            };

            var result1 = await userManager.CreateAsync(superAdminUser, superAdminPassword);
            var result2 = await userManager.CreateAsync(adminUser, superAdminPassword);
            var result3 = await userManager.CreateAsync(memberUser, superAdminPassword);


            if (result1.Succeeded && result2.Succeeded && result3.Succeeded)
            {
                await userManager.AddToRoleAsync(superAdminUser, "SuperAdmin");
                await userManager.AddToRoleAsync(adminUser, "Admin");
                await userManager.AddToRoleAsync(memberUser, "Member");
            }
        }
    }

}
