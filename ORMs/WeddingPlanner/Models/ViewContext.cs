using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Models{
    public class MyContext : DbContext{
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
