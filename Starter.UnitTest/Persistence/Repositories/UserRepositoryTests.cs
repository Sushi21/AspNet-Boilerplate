using Starter.Persistence.Repositories;
using FluentAssertions;
using Xunit;
namespace Starter.UnitTest.Persistence.Repositories;

public class UserRepositoryTests : DatabaseTest
{
  [Fact]
  public async void UserRepository_GetAll_Returns_AllUsers()
  {
    var users = await UserBuilder.New(dataContext)
     .BuildMany(10);

    var userRepository = new UserRepository(dataContext);

    var result = await userRepository.GetAll(new System.Threading.CancellationToken());

    result.Should().NotBeNull();
    result.Should().BeEquivalentTo(users, options => options.Excluding(o => o.Id));
  }

  [Fact]
  public async void UserRepository_Get_Returns_User()
  {
    var user = await UserBuilder.New(dataContext)
     .BuildOne();

    var userRepository = new UserRepository(dataContext);

    var result = await userRepository.Get(user.Id, new System.Threading.CancellationToken());

    result.Should().NotBeNull();
    result.Should().BeSameAs(user);
  }

  [Fact]
  public async void UserRepository_Return_True_If_Email_Already_In_Dabatase()
  {
    var user = await UserBuilder.New(dataContext)
     .BuildOne();

    var userRepository = new UserRepository(dataContext);

    var result = await userRepository.IsEmailAlreadyExist(user.Email, new System.Threading.CancellationToken());

    result.Should().BeTrue();
  }
}