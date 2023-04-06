using FluentMigrator;
using FluentMigrator.Builders.Create.Table;
using Starter.Database;

namespace Test;
[Migration(20230406102000)]
public class AddUserTable : Migration
{
  public override void Up()
  {
    Execute.Sql("CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\";");

    Create.Table("User")
        .WithColumn("Id").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
        .WithColumn("Email").AsString().NotNullable()
        .WithColumn("Name").AsString().NotNullable()
        .WithBaseEntityColumn();
  }

  public override void Down()
  {
    Delete.Table("User");
  }
}