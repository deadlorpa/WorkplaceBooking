using FluentMigrator;

namespace WorkplaceBooking.Migrations
{
    [Migration(202310140001)]
    public class Migration_202310140001_CreateUsers : Migration
    {
        public override void Down()
        {
            Delete.Table("Users");
        }

        public override void Up()
        {
            Create.Table("Users")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
            .WithColumn("FirstName").AsString(50).NotNullable()
            .WithColumn("LastName").AsString(50).NotNullable()
            .WithColumn("Email").AsString(60).NotNullable()
            .WithColumn("Role").AsString(10).NotNullable()
            .WithColumn("Password").AsString(50).NotNullable();
        }
    }
}
