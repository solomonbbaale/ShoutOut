using System.Linq;
using Shouldly;
using ShoutOut.Core.Entities;
using ShoutOut.Infrastructure.Repository;
using Xunit;

namespace ShoutOut.Tests.Infrastructure
{
    public class ShoutOutUserRepositoryTests
    {
        private readonly User _user;
        public ShoutOutUserRepositoryTests()
        {
            _user = new User("@henrydollars", "Henry", "Got your money", "Father, Son, good person",
                "henrymoney@stole.yourbank", "How stole are you");
        }

        [Fact]
        public void CallingAdd_On_Repository_AddsEntity_ToUnderlyingDbSet()
        {
            var context = new ShoutOutInMemoryDbContextFactory<ShoutOutContext>()
                           .Create("shoutoutdb1");

            var shoutOutRepository = new ShoutOutRepository<User>(context);

            shoutOutRepository.Add(_user);

            shoutOutRepository.Save();

            context.Users.Count().ShouldBe(1);
        }


        [Fact]
        public void CallingUpdate_On_Repository_UpdatesEntity_ToUnderlyingDbSet()
        {
            //Given
            var context = new ShoutOutInMemoryDbContextFactory<ShoutOutContext>()
                .Create("shoutoutdb2");

            var shoutOutRepository = new ShoutOutRepository<User>(context);

            shoutOutRepository.Add(_user);

            shoutOutRepository.Save();

            //When
            _user.UpdateUser("@newHandle","newName",_user.LastName,_user.Bio,_user.Email,_user.Profile);

            context.SaveChanges();

            //Then
            var user = shoutOutRepository.GetEntityById(_user.Id);

            user.Handle.ShouldBe("@newHandle");

            user.FirstName.ShouldBe("newName");
        }

        [Fact]
        public void CallingDelete_on_Repository_DeletesEntity_FromUnderlyingDbSet()
        {
            //Given
            var context = new ShoutOutInMemoryDbContextFactory<ShoutOutContext>()
                .Create("shoutoutdb3");

            var shoutOutRepository = new ShoutOutRepository<User>(context);

            shoutOutRepository.Add(_user);

            shoutOutRepository.Save();

            //When
            shoutOutRepository.Delete(_user);

            shoutOutRepository.Save();

            //Then
            var user = shoutOutRepository.GetEntityById(_user.Id);

            user.ShouldBeNull();
        }

        [Fact]
        public void Creating_AnewEntity_AssignAnIdId()
        {
            //Given
            var context = new ShoutOutInMemoryDbContextFactory<ShoutOutContext>()
                .Create("shoutoutdb4");

            var shoutOutRepository = new ShoutOutRepository<User>(context);

            shoutOutRepository.Add(_user);

            shoutOutRepository.Save();

            //Then
            _user.Id.ShouldNotBeNull();

            shoutOutRepository.GetEntityById(_user.Id).ShouldNotBeNull();
        }
    }
}
