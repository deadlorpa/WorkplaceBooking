using FluentMigrator;
using WorkplaceBooking.Core.Contracts.Entities;

namespace WorkplaceBooking.Core.Migrations
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
            .WithColumn($"{nameof(User.Id)}").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn($"{nameof(User.FirstName)}").AsString(50).NotNullable()
            .WithColumn($"{nameof(User.LastName)}").AsString(50).NotNullable()
            .WithColumn($"{nameof(User.Email)}").AsString(60).NotNullable()
            .WithColumn($"{nameof(User.Role)}").AsString(10).NotNullable()
            .WithColumn($"{nameof(User.Password)}").AsString(50).NotNullable();
        }
    }
}
