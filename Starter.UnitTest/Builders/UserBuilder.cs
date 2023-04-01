using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Starter.Domain.Entities;
using Starter.Persistence.Context;

public class UserBuilder
{
  private readonly DataContext dataContext;

  private UserBuilder(DataContext dataContext)
  {
    this.dataContext = dataContext;
  }

  public static UserBuilder New(DataContext dataContext)
  {
    return new UserBuilder(dataContext);
  }

  public async Task<User> BuildOne()
  {
    var users = await BuildMany(1);
    return users.Single();
  }

  public async Task<List<User>> BuildMany(int count)
  {
    var users = Enumerable.Range(0, count)
        .Select(_ =>
        {
          var userFaker = new Faker<User>()
          .RuleFor(u => u.Name, u => u.Person.FullName)
          .RuleFor(u => u.Email, u => u.Person.Email);

          var user = userFaker.Generate();
          
          dataContext.Add(user);

          return user;

        }).ToList();

    await dataContext.SaveChangesAsync();

    return users;
  }
}
