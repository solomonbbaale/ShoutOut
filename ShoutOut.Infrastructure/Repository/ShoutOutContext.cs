using Microsoft.EntityFrameworkCore;
using ShoutOut.Core.Entities;

namespace ShoutOut.Infrastructure.Repository
{
    public class ShoutOutContext : DbContext
    {
        public ShoutOutContext(DbContextOptions<ShoutOutContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}