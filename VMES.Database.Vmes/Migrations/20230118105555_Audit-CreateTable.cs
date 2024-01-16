using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class AuditCreateTable : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Audits",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Timestamp = table.Column<DateTime>(nullable: false),
					Hostname = table.Column<string>(maxLength: 256, nullable: false),
					StackTrace = table.Column<string>(nullable: true),
					User = table.Column<string>(maxLength: 64, nullable: true),
					Ip = table.Column<string>(maxLength: 64, nullable: true),
					Mac = table.Column<string>(maxLength: 64, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Audits", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AuditTables",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					AuditId = table.Column<int>(nullable: false),
					Table = table.Column<string>(maxLength: 128, nullable: false),
					State = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AuditTables", x => x.Id);
					table.ForeignKey(
						name: "FK_AuditTables_Audits_AuditId",
						column: x => x.AuditId,
						principalTable: "Audits",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AuditColumns",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					AuditTableId = table.Column<int>(nullable: false),
					Column = table.Column<string>(maxLength: 128, nullable: false),
					OldValue = table.Column<string>(maxLength: 256, nullable: true),
					NewValue = table.Column<string>(maxLength: 256, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AuditColumns", x => x.Id);
					table.ForeignKey(
						name: "FK_AuditColumns_AuditTables_AuditTableId",
						column: x => x.AuditTableId,
						principalTable: "AuditTables",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_AuditColumns_AuditTableId",
				table: "AuditColumns",
				column: "AuditTableId");

			migrationBuilder.CreateIndex(
				name: "IX_AuditTables_AuditId",
				table: "AuditTables",
				column: "AuditId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "AuditColumns");

			migrationBuilder.DropTable(
				name: "AuditTables");

			migrationBuilder.DropTable(
				name: "Audits");
		}
	}
}
