using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class recetas_to_medicaciones_binding : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_RecetasLineas_idMedicamento] ON [RecetasLineas];");
			migrationBuilder.Sql("CREATE INDEX [IX_RecetasLineas_idMedicamento] ON [RecetasLineas]([idMedicamento]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_RecetasLineas_idReceta] ON [RecetasLineas];");
			migrationBuilder.Sql("CREATE INDEX [IX_RecetasLineas_idReceta] ON [RecetasLineas]([idReceta]);");

			migrationBuilder.DropForeignKey(
				name: "FK_RecetasLineas_Medicaciones",
				table: "RecetasLineas");

			migrationBuilder.DropIndex(
				name: "IX_RecetasLineas_idMedicamento",
				table: "RecetasLineas");

			migrationBuilder.DropColumn(
				name: "idMedicamento",
				table: "RecetasLineas");

			migrationBuilder.AlterColumn<int>(
				name: "idReceta",
				table: "RecetasLineas",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AddColumn<int>(
				name: "ProductoId",
				table: "RecetasLineas",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<int>(
				name: "MedicacionId",
				table: "Recetas",
				nullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_RecetasLineas_ProductoId",
				table: "RecetasLineas",
				column: "ProductoId");

			migrationBuilder.CreateIndex(
				name: "IX_Recetas_MedicacionId",
				table: "Recetas",
				column: "MedicacionId");

			migrationBuilder.AddForeignKey(
				name: "FK_Recetas_Medicaciones_MedicacionId",
				table: "Recetas",
				column: "MedicacionId",
				principalTable: "Medicaciones",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_RecetasLineas_Productos",
				table: "RecetasLineas",
				column: "ProductoId",
				principalTable: "Productos",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Recetas_Medicaciones_MedicacionId",
				table: "Recetas");

			migrationBuilder.DropForeignKey(
				name: "FK_RecetasLineas_Productos",
				table: "RecetasLineas");

			migrationBuilder.DropIndex(
				name: "IX_RecetasLineas_ProductoId",
				table: "RecetasLineas");

			migrationBuilder.DropIndex(
				name: "IX_Recetas_MedicacionId",
				table: "Recetas");

			migrationBuilder.DropColumn(
				name: "ProductoId",
				table: "RecetasLineas");

			migrationBuilder.DropColumn(
				name: "MedicacionId",
				table: "Recetas");

			migrationBuilder.AlterColumn<int>(
				name: "idReceta",
				table: "RecetasLineas",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AddColumn<int>(
				name: "idMedicamento",
				table: "RecetasLineas",
				type: "int",
				nullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_RecetasLineas_idMedicamento",
				table: "RecetasLineas",
				column: "idMedicamento");

			migrationBuilder.AddForeignKey(
				name: "FK_RecetasLineas_Medicaciones",
				table: "RecetasLineas",
				column: "idMedicamento",
				principalTable: "Medicaciones",
				principalColumn: "Id",
				onDelete: ReferentialAction.SetNull);
		}
	}
}
