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

    public class ShoutOutRepository<T> : IRepository<T>
    where T : Entity
    {
        private readonly ShoutOutContext _context;
        private readonly DbSet<T> _dbset;

        public ShoutOutRepository(ShoutOutContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void Delete(T entity)
        {
            var item = _dbset.Remove(entity);
        }

        public void Save()
        {
           _context.SaveChanges();
        }
    }
}
