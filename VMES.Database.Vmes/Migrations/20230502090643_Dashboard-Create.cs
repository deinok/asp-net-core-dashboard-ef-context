using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class DashboardCreate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Dashboards",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					Name = table.Column<string>(maxLength: 64, nullable: false),
					Value = table.Column<string>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Dashboards", x => x.Id);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Dashboards");
		}
	}
}
