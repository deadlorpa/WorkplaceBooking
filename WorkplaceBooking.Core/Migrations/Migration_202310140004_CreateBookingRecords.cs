using FluentMigrator;
using WorkplaceBooking.Core.Contracts.Entities;

namespace WorkplaceBooking.Core.Migrations
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
            .WithColumn($"{nameof(BookingRecord.Id)}").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn($"{nameof(BookingRecord.UserId)}").AsInt32().NotNullable().ForeignKey("Users", $"{nameof(User.Id)}").OnDeleteOrUpdate(System.Data.Rule.Cascade)
            .WithColumn($"{nameof(BookingRecord.WorkplaceId)}").AsInt32().NotNullable().ForeignKey("Workplaces", $"{nameof(Workplace.Id)}").OnDeleteOrUpdate(System.Data.Rule.Cascade)
            .WithColumn($"{nameof(BookingRecord.IsCanceled)}").AsBoolean().WithDefaultValue(false).NotNullable()
            .WithColumn($"{nameof(BookingRecord.StartBookingDateTime)}").AsDateTime().NotNullable()
            .WithColumn($"{nameof(BookingRecord.EndBookingDateTime)}").AsDateTime().NotNullable();
        }
    }
}
