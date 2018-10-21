using IdentityMVC.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentityMVC.Seeder
{
    public class SampleData
    {
        public static IEnumerable<IdentityRole> GetRoles()
            => new List<IdentityRole>()
        {
                new IdentityRole()
                {
                    Name = "Alpha",
                    NormalizedName = "ALPHA",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },
                new IdentityRole()
                {
                    Name = "Beta",
                    NormalizedName = "BETA",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },
                new IdentityRole()
                {
                    Name = "Charlie",
                    NormalizedName = "CHARLIE",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },
        };


        public static IEnumerable<IdentityUser> GetUsers()
            => SetPasswords(new List<IdentityUser>()
            {
                new IdentityUser()
                {
                    UserName = "snake",
                    Email = "snake@Develop.com",
                    NormalizedEmail = "SNAKE@DEVELOP.COM",
                    NormalizedUserName = "SNAKE",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true,
                },
                new IdentityUser()
                {
                    UserName = "ocelot",
                    Email = "ocelot@Develop.com",
                    NormalizedEmail = "OCELOT@DEVELOP.COM",
                    NormalizedUserName = "OCELOT",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new IdentityUser()
                {
                    UserName = "liquid",
                    Email = "liquid@Develop.com",
                    NormalizedEmail = "LIQUID@DEVELOP.COM",
                    NormalizedUserName = "LIQUID",
                    SecurityStamp = Guid.NewGuid().ToString(),
                },
            });

        public static IEnumerable<IdentityUserRole<string>> GetUserRole(List<IdentityRole> roles, List<IdentityUser> users)
            => new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>()
                {
                    RoleId = roles.Find(x => x.Name == "Charlie").Id,
                    UserId = users.Find(x => x.UserName == "ocelot").Id
                },
                new IdentityUserRole<string>()
                {
                    RoleId = roles.Find(x => x.Name == "Beta").Id,
                    UserId = users.Find(x => x.UserName == "liquid").Id
                },
                new IdentityUserRole<string>()
                {
                    RoleId = roles.Find(x => x.Name == "Alpha").Id,
                    UserId = users.Find(x => x.UserName == "snake").Id
                },
            };

        private static IEnumerable<IdentityUser> SetPasswords(List<IdentityUser> users)
        {
            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();

            foreach (var employee in users)
            {
                employee.PasswordHash = passwordHasher.HashPassword(employee, "Develop@90");
            }

            return users;
        }
    }
}
