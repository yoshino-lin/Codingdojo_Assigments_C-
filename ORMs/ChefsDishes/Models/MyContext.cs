using Microsoft.EntityFrameworkCore;
using ChefsDishes.Models;
namespace Context.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<Chef> Chef {get;set;}
    }
}
