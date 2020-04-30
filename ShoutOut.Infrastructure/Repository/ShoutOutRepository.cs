using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShoutOut.Core.Entities;

namespace ShoutOut.Infrastructure.Repository
{
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

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }

        //This may or maynot return an entity could user maybe<t>
        public T GetEntityById(Guid id)
        {
            var result = _dbset.FirstOrDefault(entity => entity.Id == id);
            return result;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
