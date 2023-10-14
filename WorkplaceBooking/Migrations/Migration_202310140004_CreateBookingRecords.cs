using FluentMigrator;

namespace WorkplaceBooking.Migrations
{
    [Migration(202310140004)]
    public class Migration_202310140004_CreateBookingRecords : Migration
    {
        public override void Down()
        {
            Delete.Table("BookingRecords");
        }

        public override void Up()
        {
            Create.Table("BookingRecords")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("UserId").AsInt32().NotNullable().ForeignKey("Users", "Id")
            .WithColumn("WorkplaceId").AsInt32().NotNullable().ForeignKey("Workplaces", "Id")
            .WithColumn("IsCanceled").AsBoolean().WithDefaultValue(false).NotNullable()
            .WithColumn("StartBookingDateTime").AsDateTime().NotNullable()
            .WithColumn("EndBookingDateTime").AsDateTime().NotNullable();
        }
    }
}
