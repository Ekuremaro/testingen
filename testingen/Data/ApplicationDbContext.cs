using System;
using Microsoft.EntityFrameworkCore;
using testingen.Models;

namespace testingen.Data
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<testingen.Models.Movie>? Movie { get; set; }
    }
}

