using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class OpcConfigDefaults : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_OpcConfig_Gateways_GatewayId",
				table: "OpcConfig");

			migrationBuilder.AlterColumn<int>(
				name: "Version",
				table: "OpcConfig",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldDefaultValueSql: "((1))");

			migrationBuilder.AlterColumn<int>(
				name: "Tipo",
				table: "OpcConfig",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldDefaultValueSql: "((1))");

			migrationBuilder.AlterColumn<Guid>(
				name: "GatewayId",
				table: "OpcConfig",
				nullable: false,
				oldClrType: typeof(Guid),
				oldType: "uniqueidentifier",
				oldNullable: true);

			migrationBuilder.AddForeignKey(
				name: "FK_OpcConfig_Gateways_GatewayId",
				table: "OpcConfig",
				column: "GatewayId",
				principalTable: "Gateways",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_OpcConfig_Gateways_GatewayId",
				table: "OpcConfig");

			migrationBuilder.AlterColumn<int>(
				name: "Version",
				table: "OpcConfig",
				type: "int",
				nullable: false,
				defaultValueSql: "((1))",
				oldClrType: typeof(int));

			migrationBuilder.AlterColumn<int>(
				name: "Tipo",
				table: "OpcConfig",
				type: "int",
				nullable: false,
				defaultValueSql: "((1))",
				oldClrType: typeof(int));

			migrationBuilder.AlterColumn<Guid>(
				name: "GatewayId",
				table: "OpcConfig",
				type: "uniqueidentifier",
				nullable: true,
				oldClrType: typeof(Guid));

			migrationBuilder.AddForeignKey(
				name: "FK_OpcConfig_Gateways_GatewayId",
				table: "OpcConfig",
				column: "GatewayId",
				principalTable: "Gateways",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}
	}
}
