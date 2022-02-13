using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Identity
{
    public class DataInitializer
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public DataInitializer(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {  
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            var roles = new List<string>
            {
                Roles.Member.ToString(),
                Roles.Admin.ToString()
            };

            foreach (var role in roles)
            {
                if (await _roleManager.RoleExistsAsync(role))
                    continue;

                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}
