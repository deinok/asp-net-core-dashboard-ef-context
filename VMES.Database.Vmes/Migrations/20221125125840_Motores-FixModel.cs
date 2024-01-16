using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class MotoresFixModel : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK__Motores__OpcConf__5634BA94",
				table: "Motores");

			migrationBuilder.AlterColumn<string>(
				name: "TAG",
				table: "Motores",
				maxLength: 64,
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(50)",
				oldMaxLength: 50,
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "OpcConfigId",
				table: "Motores",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "idPLC",
				table: "Motores",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AddForeignKey(
				name: "FK_Motores_OpcConfig_OpcConfigId",
				table: "Motores",
				column: "OpcConfigId",
				principalTable: "OpcConfig",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Motores_OpcConfig_OpcConfigId",
				table: "Motores");

			migrationBuilder.AlterColumn<string>(
				name: "TAG",
				table: "Motores",
				type: "nvarchar(50)",
				maxLength: 50,
				nullable: true,
				oldClrType: typeof(string),
				oldMaxLength: 64);

			migrationBuilder.AlterColumn<int>(
				name: "OpcConfigId",
				table: "Motores",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AlterColumn<int>(
				name: "idPLC",
				table: "Motores",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AddForeignKey(
				name: "FK__Motores__OpcConf__5634BA94",
				table: "Motores",
				column: "OpcConfigId",
				principalTable: "OpcConfig",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}
	}
}
