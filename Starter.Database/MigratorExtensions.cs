using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace Starter.Database
{
  public static class Extensions
  {
    public static ICreateTableWithColumnSyntax WithBaseEntityColumn(this ICreateTableWithColumnSyntax self)
    {
      self.WithColumn("DateCreated")
          .AsDateTime()
          .NotNullable()
          .WithDefaultValue(DateTime.Now);

      self.WithColumn("DateUpdated")
          .AsDateTime();

      self.WithColumn("DateDeleted")
          .AsDateTime();

      return self;
    }
  }
}