using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Starter.Application.Features.UserFeatures.GetAllUser;
using Starter.Persistence.Repositories;
using Xunit;

namespace Starter.UnitTest.Application.Features.UserFeatures.GetAllUser;

[Collection("Database")]
public class GetAllUserHandlerTests : DatabaseTestCase
{
  private readonly GetAllUserHandler handler;

  public GetAllUserHandlerTests(DatabaseFixture databaseFixture) : base(databaseFixture)
  {
    handler = new GetAllUserHandler(new UserRepository(Context));
  }

  [Fact]
  async void Handler_should_return_all_users()
  {
    var users = await UserBuilder
      .New(Context)
      .BuildMany(10);

    var result = await handler.Handle(new GetAllUserRequest(), new CancellationToken());

    result.Should().NotBeNull();
    result.Data.Count.Should().Be(10);
    result.Data.Should().BeEquivalentTo(users, options =>
      options.Excluding(o => o.DateCreated)
             .Excluding(o => o.DateUpdated)
             .Excluding(o => o.DateDeleted)
      );
  }

  [Fact]
  async void Handler_should_return_empty_list_when_no_users_in_database()
  {
    var result = await handler.Handle(new GetAllUserRequest(), new CancellationToken());

    result.Data.Should().NotBeNull();
    result.Data.Count.Should().Be(0);
  }
}