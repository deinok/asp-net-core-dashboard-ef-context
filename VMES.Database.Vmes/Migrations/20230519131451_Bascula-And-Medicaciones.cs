using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class BasculaAndMedicaciones : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("UPDATE [Basculas] SET Tipo = 0 WHERE Tipo IS NULL;");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_Basculas_OpcConfigId] ON [Basculas];");
			migrationBuilder.Sql("CREATE INDEX [IX_Basculas_OpcConfigId] ON [Basculas]([Id]);");

			migrationBuilder.DropForeignKey(
				name: "FK__Basculas__OpcCon__54B68676",
				table: "Basculas");

			migrationBuilder.DropForeignKey(
				name: "FK_Basculas_Tags",
				table: "Basculas");

			migrationBuilder.AddColumn<string>(
				name: "Edad",
				table: "Medicaciones",
				maxLength: 120,
				nullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "Tipo",
				table: "Basculas",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "OpcConfigId",
				table: "Basculas",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "PosicionPLC",
				table: "Basculas",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AddForeignKey(
				name: "FK_Basculas_OpcConfig_OpcConfigId",
				table: "Basculas",
				column: "OpcConfigId",
				principalTable: "OpcConfig",
				principalColumn: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Basculas_Tags_Tag",
				table: "Basculas",
				column: "Tag",
				principalTable: "Tags",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Basculas_OpcConfig_OpcConfigId",
				table: "Basculas");

			migrationBuilder.DropForeignKey(
				name: "FK_Basculas_Tags_Tag",
				table: "Basculas");

			migrationBuilder.DropColumn(
				name: "Edad",
				table: "Medicaciones");

			migrationBuilder.AlterColumn<int>(
				name: "Tipo",
				table: "Basculas",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AlterColumn<int>(
				name: "OpcConfigId",
				table: "Basculas",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AlterColumn<int>(
				name: "PosicionPLC",
				table: "Basculas",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AddForeignKey(
				name: "FK__Basculas__OpcCon__54B68676",
				table: "Basculas",
				column: "OpcConfigId",
				principalTable: "OpcConfig",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Basculas_Tags",
				table: "Basculas",
				column: "Tag",
				principalTable: "Tags",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}
	}
}
