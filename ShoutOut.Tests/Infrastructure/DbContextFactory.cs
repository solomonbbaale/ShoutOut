using Microsoft.EntityFrameworkCore;

namespace ShoutOut.Tests.Infrastructure
{
    public abstract class DbContextFactory<T>
     where T: DbContext
    {
        public abstract T Create(string databaseName);
    }
}