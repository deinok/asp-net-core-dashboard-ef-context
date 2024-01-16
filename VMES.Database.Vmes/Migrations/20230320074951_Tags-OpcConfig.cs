using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class TagsOpcConfig : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK__Tags__OpcConfigI__04BA9F53",
				table: "Tags");

			migrationBuilder.AlterColumn<int>(
				name: "OpcConfigId",
				table: "Tags",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "IdPLC",
				table: "Tags",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AddForeignKey(
				name: "FK_Tags_OpcConfig_OpcConfigId",
				table: "Tags",
				column: "OpcConfigId",
				principalTable: "OpcConfig",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Tags_OpcConfig_OpcConfigId",
				table: "Tags");

			migrationBuilder.AlterColumn<int>(
				name: "OpcConfigId",
				table: "Tags",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AlterColumn<int>(
				name: "IdPLC",
				table: "Tags",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AddForeignKey(
				name: "FK__Tags__OpcConfigI__04BA9F53",
				table: "Tags",
				column: "OpcConfigId",
				principalTable: "OpcConfig",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}
	}
}
