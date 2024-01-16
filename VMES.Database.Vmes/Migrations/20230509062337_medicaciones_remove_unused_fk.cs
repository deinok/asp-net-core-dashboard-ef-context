using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class medicaciones_remove_unused_fk : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_Medicaciones_idProducto] ON [Medicaciones];");
			migrationBuilder.Sql("CREATE INDEX [IX_Medicaciones_idProducto] ON [Medicaciones]([idProducto]);");

			migrationBuilder.DropForeignKey(
				name: "FK_Medicaciones_Productos",
				table: "Medicaciones");

			migrationBuilder.DropIndex(
				name: "IX_Medicaciones_idProducto",
				table: "Medicaciones");

			migrationBuilder.DropColumn(
				name: "Cliente",
				table: "Medicaciones");

			migrationBuilder.DropColumn(
				name: "idProducto",
				table: "Medicaciones");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "Cliente",
				table: "Medicaciones",
				type: "int",
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "idProducto",
				table: "Medicaciones",
				type: "int",
				nullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_Medicaciones_idProducto",
				table: "Medicaciones",
				column: "idProducto");

			migrationBuilder.AddForeignKey(
				name: "FK_Medicaciones_Productos",
				table: "Medicaciones",
				column: "idProducto",
				principalTable: "Productos",
				principalColumn: "Id",
				onDelete: ReferentialAction.SetNull);
		}
	}
}
