using ShoutOut.Core.Entities;

namespace ShoutOut.Infrastructure.Repository
{
    public interface IRepository<in T>where T :Entity
    {
        void Add(T entity);
        void Delete(T entity);
        void Save();
    }
}