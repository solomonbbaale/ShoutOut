using System;
using Microsoft.EntityFrameworkCore;

namespace ShoutOut.Tests.Infrastructure
{
    public class ShoutOutInMemoryDbContextFactory<T>:DbContextFactory<T>
    where T: DbContext
    {
        public override T Create(string databaseName)
        {
            var dbcontextOptions = new DbContextOptionsBuilder<T>()
                .UseInMemoryDatabase(databaseName).Options;
            var type = typeof(T);
            var context =(T) Activator.CreateInstance(type, new object[]{ dbcontextOptions });
            
            return context;
        }
    }
}