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
    public class UpdateUserCommandHandlerTests
    {
        [Fact]
        public void Calling_Execute_On_UpdateUserCommandHandlerTests_UpdatesCommandAndReturns_IsSuccessTrue_If_PostFound()
        {
            //Given
            const string newMessage = "changed message";
            const string newTitle = "updated title";

            var user = new User("@handle", "solomon", "bbaale", "thing", "email@yahoo.com", "mybio");

            var post = new Post("Coding again", "Love it", user.Id, user);

            user.Posts.Add(post);

            var userCollection = new List<User> { user };

            var userRepositoryMock = new Mock<IRepository<User>>();

            userRepositoryMock.Setup(x => x.GetEntityById(user.Id))
                .Returns((Guid id) => userCollection.SingleOrDefault(x => x.Id == id));

            var updatePostCommand = new UpdatePostCommand(user.Id, post.Id, newMessage, newTitle);
             
            var createPostCommandHandler = new UpdatePostCommandHandler(userRepositoryMock.Object);

            //When
            var result = createPostCommandHandler.Execute(updatePostCommand);

            //Then
            result.IsSuccess.ShouldBeTrue();

            user.Posts.ShouldNotBeEmpty();

            var firstPost = user.Posts.First();

            firstPost.Message.ShouldBe(newMessage);

            firstPost.Title.ShouldBe(newTitle);

            userRepositoryMock.Verify(x => x.Save());
        }

        [Fact]
        public void Calling_Execute_On_UpdateUserCommandHandlerTests_Returns_IsSuccessFalse_If_UserOrPost_IsNotFound()
        {
            //Given
            const string newMessage = "changed message";
            const string newTitle = "updated title";

            var user = new User("@handle", "solomon", "bbaale", "thing", "email@yahoo.com", "mybio");

            var post = new Post("Coding again", "Love it", user.Id, user);

            var userCollection = new List<User> { user };

            var userRepositoryMock = new Mock<IRepository<User>>();

            userRepositoryMock.Setup(x => x.GetEntityById(user.Id))
                .Returns((Guid id) => userCollection.SingleOrDefault(x => x.Id == id));

            var updatePostCommand = new UpdatePostCommand(user.Id, post.Id, newMessage, newTitle);

            var createPostCommandHandler = new UpdatePostCommandHandler(userRepositoryMock.Object);

            //When
            var result = createPostCommandHandler.Execute(updatePostCommand);

            //Then
            result.IsSuccess.ShouldBeFalse();

            result.Errors.First().ShouldBe("Not Found");
        }
    }
}
