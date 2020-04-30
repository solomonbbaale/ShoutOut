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
    public class CreatePostCommandHandlerTests
    {
        [Fact]
        public void Calling_Execute_On_CreatePostCommandHandler_Adds_Post_ToUsers_Posts_AndReturns_IsSuccess()
        {
            //Given
            var user = new User("@handle", "solomon", "bbaale", "thing", "email@yahoo.com", "mybio");

            var userCollection = new List<User> { user };

            var userRepositoryMock = new Mock<IRepository<User>>();

            userRepositoryMock.Setup(x => x.GetEntityById(user.Id))
                .Returns((Guid id) => userCollection.SingleOrDefault(x => x.Id == id));

            var post = new Post("Coding again", "Love it", user.Id, user);

            var unRegisterUserCommand = new CreatePostCommand(user.Id, post);

            var createPostCommandHandler = new CreatePostCommandHandler(userRepositoryMock.Object);

            //When
            var result = createPostCommandHandler.Execute(unRegisterUserCommand);


            //Then
            result.IsSuccess.ShouldBeTrue();

            user.Posts.ShouldNotBeEmpty();

            user.Posts.First().Message.ShouldBe("Love it");

            userRepositoryMock.Verify(x=>x.Save());
        }
    }
}