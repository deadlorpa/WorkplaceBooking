using FluentMigrator;

namespace WorkplaceBooking.Migrations
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
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("Name").AsString(50).NotNullable();
        }
    }
}
