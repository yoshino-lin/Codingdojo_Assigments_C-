using Microsoft.EntityFrameworkCore;
using LoginAndRegistration.Models;
namespace Context.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
    }
}
