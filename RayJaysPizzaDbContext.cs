using Microsoft.EntityFrameworkCore;
using RayJaysPizza.Models;
using System.ComponentModel.DataAnnotations;

namespace RayJaysPizza
{
    public class RayJaysPizzaDbContext : DbContext
    {

        [Key]
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Ratings> Ratings { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }

       
        public RayJaysPizzaDbContext(DbContextOptions<RayJaysPizzaDbContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
