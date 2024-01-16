using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class MedicacionesIngredientesModified : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_MedicacionesIngredientes_Medicacion] ON [MedicacionesIngredientes];");
			migrationBuilder.Sql("CREATE INDEX [IX_MedicacionesIngredientes_Medicacion] ON [MedicacionesIngredientes]([Medicacion]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_MedicacionesIngredientes_Unidad] ON [MedicacionesIngredientes];");
			migrationBuilder.Sql("CREATE INDEX [IX_MedicacionesIngredientes_Unidad] ON [MedicacionesIngredientes] ([Unidad]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_MedicacionesIngredientes_Producto] ON [MedicacionesIngredientes];");
			migrationBuilder.Sql("CREATE INDEX [IX_MedicacionesIngredientes_Producto] ON [MedicacionesIngredientes] ([Producto]);");

			migrationBuilder.DropForeignKey(
				name: "FK_MedicacionesIngredientes_Medicaciones",
				table: "MedicacionesIngredientes");

			migrationBuilder.DropForeignKey(
				name: "FK_MedicacionesIngredientes_Productos",
				table: "MedicacionesIngredientes");

			migrationBuilder.DropForeignKey(
				name: "FK_MedicacionesIngredientes_Unidades",
				table: "MedicacionesIngredientes");

			migrationBuilder.DropPrimaryKey(
				name: "PK_MedicacionesIngredientes",
				table: "MedicacionesIngredientes");

			migrationBuilder.DropIndex(
				name: "IX_MedicacionesIngredientes_Medicacion",
				table: "MedicacionesIngredientes");

			migrationBuilder.DropColumn(
				name: "Id",
				table: "MedicacionesIngredientes");

			migrationBuilder.AlterColumn<int>(
				name: "Unidad",
				table: "MedicacionesIngredientes",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "Producto",
				table: "MedicacionesIngredientes",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "Produccion",
				table: "MedicacionesIngredientes",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<float>(
				name: "Porcentaje",
				table: "MedicacionesIngredientes",
				nullable: false,
				oldClrType: typeof(float),
				oldType: "real",
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "Medicacion",
				table: "MedicacionesIngredientes",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "MedicacionesIngredientes",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "MedicacionesIngredientes",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<float>(
				name: "Cantidad",
				table: "MedicacionesIngredientes",
				nullable: false,
				oldClrType: typeof(float),
				oldType: "real",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "AplicacionDirecta",
				table: "MedicacionesIngredientes",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AddColumn<int>(
				name: "Orden",
				table: "MedicacionesIngredientes",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddPrimaryKey(
				name: "PK_MedicacionesIngredientes",
				table: "MedicacionesIngredientes",
				columns: new[] { "Medicacion", "Orden" });

			migrationBuilder.AddForeignKey(
				name: "FK_MedicacionesIngredientes_Medicaciones_Medicacion",
				table: "MedicacionesIngredientes",
				column: "Medicacion",
				principalTable: "Medicaciones",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_MedicacionesIngredientes_Productos_Producto",
				table: "MedicacionesIngredientes",
				column: "Producto",
				principalTable: "Productos",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_MedicacionesIngredientes_Unidades_Unidad",
				table: "MedicacionesIngredientes",
				column: "Unidad",
				principalTable: "Unidades",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_MedicacionesIngredientes_Medicaciones_Medicacion",
				table: "MedicacionesIngredientes");

			migrationBuilder.DropForeignKey(
				name: "FK_MedicacionesIngredientes_Productos_Producto",
				table: "MedicacionesIngredientes");

			migrationBuilder.DropForeignKey(
				name: "FK_MedicacionesIngredientes_Unidades_Unidad",
				table: "MedicacionesIngredientes");

			migrationBuilder.DropPrimaryKey(
				name: "PK_MedicacionesIngredientes",
				table: "MedicacionesIngredientes");

			migrationBuilder.DropColumn(
				name: "Orden",
				table: "MedicacionesIngredientes");

			migrationBuilder.AlterColumn<int>(
				name: "Unidad",
				table: "MedicacionesIngredientes",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AlterColumn<int>(
				name: "Producto",
				table: "MedicacionesIngredientes",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AlterColumn<bool>(
				name: "Produccion",
				table: "MedicacionesIngredientes",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<float>(
				name: "Porcentaje",
				table: "MedicacionesIngredientes",
				type: "real",
				nullable: true,
				oldClrType: typeof(float));

			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "MedicacionesIngredientes",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "MedicacionesIngredientes",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<float>(
				name: "Cantidad",
				table: "MedicacionesIngredientes",
				type: "real",
				nullable: true,
				oldClrType: typeof(float));

			migrationBuilder.AlterColumn<bool>(
				name: "AplicacionDirecta",
				table: "MedicacionesIngredientes",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<int>(
				name: "Medicacion",
				table: "MedicacionesIngredientes",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AddColumn<int>(
				name: "Id",
				table: "MedicacionesIngredientes",
				type: "int",
				nullable: false,
				defaultValue: 0)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AddPrimaryKey(
				name: "PK_MedicacionesIngredientes",
				table: "MedicacionesIngredientes",
				column: "Id");

			migrationBuilder.CreateIndex(
				name: "IX_MedicacionesIngredientes_Medicacion",
				table: "MedicacionesIngredientes",
				column: "Medicacion");

			migrationBuilder.AddForeignKey(
				name: "FK_MedicacionesIngredientes_Medicaciones",
				table: "MedicacionesIngredientes",
				column: "Medicacion",
				principalTable: "Medicaciones",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_MedicacionesIngredientes_Productos",
				table: "MedicacionesIngredientes",
				column: "Producto",
				principalTable: "Productos",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_MedicacionesIngredientes_Unidades",
				table: "MedicacionesIngredientes",
				column: "Unidad",
				principalTable: "Unidades",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}
	}
}
