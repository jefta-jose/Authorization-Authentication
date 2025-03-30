using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class Db_Context( DbContextOptions<Db_Context> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
