using System.Linq;
using Shouldly;
using ShoutOut.Core.Entities;
using ShoutOut.Infrastructure.Repository;
using Xunit;

namespace ShoutOut.Tests.Infrastructure
{
    public class ShoutOutRepositoryTests
    {
        private readonly User _user;
        public ShoutOutRepositoryTests()
        {
            _user = new User("@henrydollars", "Henry", "Got your money", "Father, Son, good person",
                "henrymoney@stole.yourbank", "How stole are you");
        }

        [Fact]
        public void CallingAdd_On_Repository_AddsEntity_ToUnderlyingDbSet()
        {
            var context = new ShoutOutInMemoryDbContextFactory<ShoutOutContext>()
                           .Create("shoutoutone");

            var shoutOutRepository = new ShoutOutRepository<User>(context);

            shoutOutRepository.Add(_user);

            shoutOutRepository.Save();

            context.Users.Count().ShouldBe(1);
        }

        [Fact]
        public void CallingDelete_on_Repository_DeletesEntity_FromUnderlyingDbSet()
        {
            var context = new ShoutOutInMemoryDbContextFactory<ShoutOutContext>()
                .Create("shoutout");

            var shoutOutRepository = new ShoutOutRepository<User>(context);

            shoutOutRepository.Add(_user);

            shoutOutRepository.Save();

            shoutOutRepository.Delete(_user);

            shoutOutRepository.Save();
        }

        [Fact]
        public void Creating_AnewEntity_AssignAnIdId()
        {

            var context = new ShoutOutInMemoryDbContextFactory<ShoutOutContext>()
                .Create("shoutout");

            var shoutOutRepository = new ShoutOutRepository<User>(context);

            shoutOutRepository.Add(_user);

            shoutOutRepository.Save();

            _user.Id.ShouldNotBeNull();

            shoutOutRepository.GetEntityById(_user.Id).ShouldNotBeNull();
        }
    }
}
