using System;
using System.Collections.Generic;
using System.Text;
using IdentityMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Changes default schema
            modelBuilder.HasDefaultSchema("MG");

            //Changes Table Name
            modelBuilder.Entity<User>(b =>
            {
                b.ToTable("User");
            });
        }
    }
}
