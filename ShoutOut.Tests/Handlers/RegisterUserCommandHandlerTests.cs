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
    public class RegisterUserCommandHandlerTests
    {
        [Fact]
        public void Calling_ExecuteOnRegisterUserCommandHandler_AddsUser_Repository()
        {
            //Given

            var userCollection = new List<User>();

            var userRepositoryMock = new Mock<IRepository<User>>();

            userRepositoryMock.Setup(x => x.Add(It.IsAny<User>()))
                .Callback<User>(t => userCollection.Add(t));

            var registerUserCommand = new RegisterUserCommand("@handle", "solomon", "bbaale", "thing", "email@yahoo.com", "mybio");

            var registerUserCommandHandler = new RegisterUserCommandHandler(userRepositoryMock.Object);

            //When

            var result = registerUserCommandHandler.Execute(registerUserCommand);


            //Then
            var userResult = userCollection.First();

            userResult.ShouldNotBeNull();

            userResult.Id.ShouldBeOfType<Guid>();

            userResult.Bio.ShouldBe("thing");

            result.IsSuccess.ShouldBeTrue();
        }

        //TODO:Test for when this should fail i.e validity of the command before it is executed, are all the parameters filled in 
        //TODO: required to create a valid user e.t.c
    }
}
