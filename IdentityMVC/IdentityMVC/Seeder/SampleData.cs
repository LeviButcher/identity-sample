using IdentityMVC.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using IdentityMVC.Models;

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


        public static IEnumerable<User> GetUsers()
            => SetPasswords(new List<User>()    
            {
                new User()
                {
                    UserName = "snake@Develop.com",
                    Email = "snake@Develop.com",
                    NormalizedEmail = "SNAKE@DEVELOP.COM",
                    NormalizedUserName = "SNAKE@DEVELOP.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true,
                },
                new User()
                {
                    UserName = "ocelot@Develop.com",
                    Email = "ocelot@Develop.com",
                    NormalizedEmail = "OCELOT@DEVELOP.COM",
                    NormalizedUserName = "OCELOT@DEVELOP.COM",
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new User()
                {
                    UserName = "liquid@Develop.com",
                    Email = "liquid@Develop.com",
                    NormalizedEmail = "LIQUID@DEVELOP.COM",
                    NormalizedUserName = "LIQUID@DEVELOP.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                },
            });

        public static IEnumerable<IdentityUserRole<string>> GetUserRole(List<IdentityRole> roles, List<User> users)
            => new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>()
                {
                    RoleId = roles.Find(x => x.Name == "Charlie").Id,
                    UserId = users.Find(x => x.UserName == "ocelot@Develop.com").Id
                },
                new IdentityUserRole<string>()
                {
                    RoleId = roles.Find(x => x.Name == "Beta").Id,
                    UserId = users.Find(x => x.UserName == "liquid@Develop.com").Id
                },
                new IdentityUserRole<string>()
                {
                    RoleId = roles.Find(x => x.Name == "Alpha").Id,
                    UserId = users.Find(x => x.UserName == "snake@Develop.com").Id
                },
            };

        private static IEnumerable<User> SetPasswords(List<User> users)
        {
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            foreach (var employee in users)
            {
                employee.PasswordHash = passwordHasher.HashPassword(employee, "Develop@90");
            }

            return users;
        }
    }
}
