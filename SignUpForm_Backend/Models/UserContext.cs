using Microsoft.EntityFrameworkCore;

namespace SignUpForm_Backend.Models
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
