using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class OpcConfigAddDiscoveryUrl : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "DiscoveryUrl",
				table: "OpcConfig",
				maxLength: 256,
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "DiscoveryUrl",
				table: "OpcConfig");
		}
	}
}
