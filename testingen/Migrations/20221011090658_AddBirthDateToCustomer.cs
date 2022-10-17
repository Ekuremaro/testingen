using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testingen.Migrations
{
    public partial class AddBirthDateToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Customers",
                type: "datetime2",
                nullable: true
                );



            migrationBuilder.Sql("UPDATE Customers SET BirthDate = '2014-03-16 00:00:00.000' WHERE Id = 1");
            migrationBuilder.Sql("UPDATE Customers SET BirthDate = '2016-09-11 00:00:00.000' WHERE Id = 2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "BirthDate",
            //    table: "Customers",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2",
            //    oldNullable: true);
        }
    }
}
