using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class Printer : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<Guid>(
				name: "DefaultPrinterId",
				table: "InformesLibUsuarios",
				nullable: true);

			migrationBuilder.AddColumn<Guid>(
				name: "DefaultPrinterId",
				table: "InformesLib",
				nullable: true);

			migrationBuilder.CreateTable(
				name: "Printers",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					Name = table.Column<string>(maxLength: 64, nullable: false),
					Type = table.Column<byte>(nullable: false),
					Url = table.Column<string>(maxLength: 64, nullable: true),
					WindowsName = table.Column<string>(maxLength: 64, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Printers", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "PrintJobs",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					PrinterId = table.Column<Guid>(nullable: false),
					Status = table.Column<byte>(nullable: false),
					Timestamp = table.Column<DateTimeOffset>(nullable: false),
					Copies = table.Column<int>(nullable: false),
					Content = table.Column<byte[]>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PrintJobs", x => x.Id);
					table.ForeignKey(
						name: "FK_PrintJobs_Printers_PrinterId",
						column: x => x.PrinterId,
						principalTable: "Printers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_InformesLibUsuarios_DefaultPrinterId",
				table: "InformesLibUsuarios",
				column: "DefaultPrinterId");

			migrationBuilder.CreateIndex(
				name: "IX_InformesLib_DefaultPrinterId",
				table: "InformesLib",
				column: "DefaultPrinterId");

			migrationBuilder.CreateIndex(
				name: "IX_PrintJobs_PrinterId",
				table: "PrintJobs",
				column: "PrinterId");

			migrationBuilder.AddForeignKey(
				name: "FK_InformesLib_Printers_DefaultPrinterId",
				table: "InformesLib",
				column: "DefaultPrinterId",
				principalTable: "Printers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_InformesLibUsuarios_Printers_DefaultPrinterId",
				table: "InformesLibUsuarios",
				column: "DefaultPrinterId",
				principalTable: "Printers",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_InformesLib_Printers_DefaultPrinterId",
				table: "InformesLib");

			migrationBuilder.DropForeignKey(
				name: "FK_InformesLibUsuarios_Printers_DefaultPrinterId",
				table: "InformesLibUsuarios");

			migrationBuilder.DropTable(
				name: "PrintJobs");

			migrationBuilder.DropTable(
				name: "Printers");

			migrationBuilder.DropIndex(
				name: "IX_InformesLibUsuarios_DefaultPrinterId",
				table: "InformesLibUsuarios");

			migrationBuilder.DropIndex(
				name: "IX_InformesLib_DefaultPrinterId",
				table: "InformesLib");

			migrationBuilder.DropColumn(
				name: "DefaultPrinterId",
				table: "InformesLibUsuarios");

			migrationBuilder.DropColumn(
				name: "DefaultPrinterId",
				table: "InformesLib");
		}
	}
}
