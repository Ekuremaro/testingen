using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testingen.Migrations
{
    public partial class RenameMoviesColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("exec sp_rename 'dbo.Movie', 'Movies'");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
