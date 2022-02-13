using System;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var server = "localhost";
        //    var port = "1433";
        //    var user = "sa";
        //    var password = "MyPass@word";
        //    var database = "SundayDb";

        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer($"Server={server}, {port};Initial Catalog={database};User ID={user};Password={password}");

        //}

        public DbSet<Book> Books { get; set; }
    }
}
