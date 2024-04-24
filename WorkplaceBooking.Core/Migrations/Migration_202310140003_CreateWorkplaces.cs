using FluentMigrator;
using WorkplaceBooking.Core.Contracts.Entities;

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
            .WithColumn($"{nameof(Workplace.Id)}").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn($"{nameof(Workplace.RoomId)}").AsInt32().NotNullable().ForeignKey("Rooms", $"{nameof(Room.Id)}").OnDeleteOrUpdate(System.Data.Rule.Cascade)
            .WithColumn($"{nameof(Workplace.Name)}").AsString(50).NotNullable()
            .WithColumn($"{nameof(Workplace.Description)}").AsString(250).NotNullable();
        }
    }
}
