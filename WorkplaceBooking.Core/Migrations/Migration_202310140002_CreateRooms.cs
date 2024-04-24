using FluentMigrator;
using WorkplaceBooking.Core.Contracts.Entities;

namespace WorkplaceBooking.Core.Migrations
{
    [Migration(202310140002)]
    public class Migration_202310140002_CreateRooms : Migration
    {
        public override void Down()
        {
            Delete.Table("Rooms");
        }

        public override void Up()
        {
            Create.Table("Rooms")
            .WithColumn($"{nameof(Room.Id)}").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn($"{nameof(Room.Name)}").AsString(50).NotNullable();
        }
    }
}
