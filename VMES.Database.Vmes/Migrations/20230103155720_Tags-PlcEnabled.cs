using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class TagsPlcEnabled : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "PlcEnabled",
				table: "Tags",
				nullable: false,
				defaultValue: false);
			migrationBuilder.Sql("UPDATE [Tags] SET [PlcEnabled] = 1 WHERE [IdPLC] >= 0;");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "PlcEnabled",
				table: "Tags");
		}
	}
}
