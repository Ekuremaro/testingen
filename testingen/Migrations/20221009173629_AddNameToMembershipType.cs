using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testingen.Migrations
{
    public partial class AddNameToMembershipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscountRrate",
                table: "MembershipType",
                newName: "DiscountRate");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MembershipType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql("UPDATE MembershipType SET Name = 'Pay as You Go' WHERE Id = 1");
            migrationBuilder.Sql("UPDATE MembershipType SET Name = 'Monthly' WHERE Id = 2");
            migrationBuilder.Sql("UPDATE MembershipType SET Name = 'Quarterly' WHERE Id = 3");
            migrationBuilder.Sql("UPDATE MembershipType SET Name = 'Annual' WHERE Id = 4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "MembershipType");

            migrationBuilder.RenameColumn(
                name: "DiscountRate",
                table: "MembershipType",
                newName: "DiscountRrate");
        }
    }
}
