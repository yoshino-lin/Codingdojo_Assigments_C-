using Microsoft.EntityFrameworkCore; 
namespace MyContext.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
            
            // "users" table is represented by this DbSet "Users"
        public DbSet<User> Users {get;set;}
    }
}
