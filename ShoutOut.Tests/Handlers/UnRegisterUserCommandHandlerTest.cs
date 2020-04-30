using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Shouldly;
using ShoutOut.ApplicationLayer.CommandHandlers;
using ShoutOut.Core.Commands;
using ShoutOut.Core.Entities;
using ShoutOut.Infrastructure.Repository;
using Xunit;

namespace ShoutOut.Tests.Handlers
{
    public class UnRegisterUserCommandHandlerTest
    {
        [Fact]
        public void Calling_Execute_On_UnRegisterUserCommandHandler_RemovesUser_If_Found_Repository_AndReturn_IsSuccess()
        {
            //Given
            var user = new User("@handle", "solomon", "bbaale", "thing", "email@yahoo.com", "mybio");

            var userCollection = new List<User> { user };

            var userRepositoryMock = new Mock<IRepository<User>>();

            userRepositoryMock.Setup(x => x.GetEntityById(user.Id))
                .Returns(user);

            userRepositoryMock.Setup(x => x.Delete(user))
                .Callback<User>(t => userCollection.Remove(t));

            var unRegisterUserCommand = new UnRegisterUserCommand(user.Id);

            var unRegisterUserCommandHandler = new UnRegisterUserCommandHandler(userRepositoryMock.Object);

            //When

            var result = unRegisterUserCommandHandler.Execute(unRegisterUserCommand);


            //Then
            var userResult = userCollection.FirstOrDefault();

            userResult.ShouldBeNull();

            result.IsSuccess.ShouldBeTrue();

            userRepositoryMock.Verify(x=>x.Save());
        }

        [Fact]
        public void Calling_Execute_On_UnRegisterUserCommandHandler_Returns_Failed_If_UserNotFound_In_Repository()
        {
            //Given
            var user = new User("@handle", "solomon", "bbaale", "thing", "email@yahoo.com", "mybio");

            var userCollection = Enumerable.Empty<User>().ToList();

            var userRepositoryMock = new Mock<IRepository<User>>();

            userRepositoryMock.Setup(x => x.GetEntityById(user.Id))
                .Returns((Guid id) => userCollection.SingleOrDefault(x => x.Id == id));

            userRepositoryMock.Setup(x => x.Delete(user))
                .Callback<User>(t => userCollection.Remove(t));

            var unRegisterUserCommand = new UnRegisterUserCommand(user.Id);

            var unRegisterUserCommandHandler = new UnRegisterUserCommandHandler(userRepositoryMock.Object);

            //When
            var result = unRegisterUserCommandHandler.Execute(unRegisterUserCommand);


            //Then
            result.IsSuccess.ShouldBeFalse();

            result.Errors.ShouldNotBeEmpty();

            result.Errors.First().ShouldBeSameAs("User not found");
        }
    }
}
