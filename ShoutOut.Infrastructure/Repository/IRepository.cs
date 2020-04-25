using System;
using ShoutOut.Core.Entities;

namespace ShoutOut.Infrastructure.Repository
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);
        void Delete(T entity);
        void Save(); 
        void Update(T entity);
        T GetEntityById(Guid id);
    }
}