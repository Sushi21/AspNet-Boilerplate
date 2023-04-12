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
          .AsDateTimeOffset()
          .NotNullable()
          .WithDefaultValue(DateTime.Now);

      self.WithColumn("DateUpdated")
          .AsDateTimeOffset()
          .Nullable();

      self.WithColumn("DateDeleted")
          .AsDateTimeOffset()
          .Nullable();

      return self;
    }
  }
}