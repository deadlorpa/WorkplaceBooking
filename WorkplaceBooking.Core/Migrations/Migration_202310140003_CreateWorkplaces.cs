using FluentMigrator;

namespace WorkplaceBooking.Core.Migrations
{
    [Migration(202310140003)]
    public class Migration_202310140003_CreateWorkplaces : Migration
    {
        public override void Down()
        {
            Delete.Table("Workplaces");
        }

        public override void Up()
        {
            Create.Table("Workplaces")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("RoomId").AsInt32().NotNullable().ForeignKey("Rooms", "Id").OnDeleteOrUpdate(System.Data.Rule.Cascade)
            .WithColumn("Name").AsString(50).NotNullable()
            .WithColumn("Description").AsString(250).NotNullable();
        }
    }
}
