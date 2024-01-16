using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class Orden_ModuloVariables : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<float>(
				name: "ModuloVariables0",
				table: "Ordenes",
				nullable: false,
				defaultValue: 0f);

			migrationBuilder.AddColumn<float>(
				name: "ModuloVariables1",
				table: "Ordenes",
				nullable: false,
				defaultValue: 0f);

			migrationBuilder.AddColumn<float>(
				name: "ModuloVariables2",
				table: "Ordenes",
				nullable: false,
				defaultValue: 0f);

			migrationBuilder.AddColumn<float>(
				name: "ModuloVariables3",
				table: "Ordenes",
				nullable: false,
				defaultValue: 0f);

			migrationBuilder.AddColumn<float>(
				name: "ModuloVariables4",
				table: "Ordenes",
				nullable: false,
				defaultValue: 0f);

			migrationBuilder.AddColumn<float>(
				name: "ModuloVariables5",
				table: "Ordenes",
				nullable: false,
				defaultValue: 0f);

			migrationBuilder.AddColumn<float>(
				name: "ModuloVariables6",
				table: "Ordenes",
				nullable: false,
				defaultValue: 0f);

			migrationBuilder.AddColumn<float>(
				name: "ModuloVariables7",
				table: "Ordenes",
				nullable: false,
				defaultValue: 0f);

			migrationBuilder.AddColumn<float>(
				name: "ModuloVariables8",
				table: "Ordenes",
				nullable: false,
				defaultValue: 0f);

			migrationBuilder.AddColumn<float>(
				name: "ModuloVariables9",
				table: "Ordenes",
				nullable: false,
				defaultValue: 0f);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "ModuloVariables0",
				table: "Ordenes");

			migrationBuilder.DropColumn(
				name: "ModuloVariables1",
				table: "Ordenes");

			migrationBuilder.DropColumn(
				name: "ModuloVariables2",
				table: "Ordenes");

			migrationBuilder.DropColumn(
				name: "ModuloVariables3",
				table: "Ordenes");

			migrationBuilder.DropColumn(
				name: "ModuloVariables4",
				table: "Ordenes");

			migrationBuilder.DropColumn(
				name: "ModuloVariables5",
				table: "Ordenes");

			migrationBuilder.DropColumn(
				name: "ModuloVariables6",
				table: "Ordenes");

			migrationBuilder.DropColumn(
				name: "ModuloVariables7",
				table: "Ordenes");

			migrationBuilder.DropColumn(
				name: "ModuloVariables8",
				table: "Ordenes");

			migrationBuilder.DropColumn(
				name: "ModuloVariables9",
				table: "Ordenes");
		}
	}
}
