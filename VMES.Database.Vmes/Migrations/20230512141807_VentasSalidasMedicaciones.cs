using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class VentasSalidasMedicaciones : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_VentasLiniasMedicaciones_idVentaLinia] ON [VentasLiniasMedicaciones];");
			migrationBuilder.Sql("CREATE INDEX [IX_VentasLiniasMedicaciones_idVentaLinia] ON [VentasLiniasMedicaciones]([idVentaLinia]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_VentasLiniasMedicaciones_idUnidad] ON [VentasLiniasMedicaciones];");
			migrationBuilder.Sql("CREATE INDEX [IX_VentasLiniasMedicaciones_idUnidad] ON [VentasLiniasMedicaciones]([idUnidad]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_VentasLiniasMedicaciones_idLineaSalidaMedicamento] ON [VentasLiniasMedicaciones];");
			migrationBuilder.Sql("CREATE INDEX [IX_VentasLiniasMedicaciones_idLineaSalidaMedicamento] ON [VentasLiniasMedicaciones]([idLineaSalidaMedicamento]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_VentasLiniasMedicaciones_idMedicamento] ON [VentasLiniasMedicaciones];");
			migrationBuilder.Sql("CREATE INDEX [IX_VentasLiniasMedicaciones_idMedicamento] ON [VentasLiniasMedicaciones]([idMedicamento]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_SalidasLiniasMedicaciones_idMedicamento] ON [SalidasLiniasMedicaciones];");
			migrationBuilder.Sql("CREATE INDEX [IX_SalidasLiniasMedicaciones_idMedicamento] ON [SalidasLiniasMedicaciones]([idMedicamento]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_SalidasLiniasMedicaciones_idSalidaLinia] ON [SalidasLiniasMedicaciones];");
			migrationBuilder.Sql("CREATE INDEX [IX_SalidasLiniasMedicaciones_idSalidaLinia] ON [SalidasLiniasMedicaciones]([idSalidaLinia]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_SalidasLiniasMedicaciones_IdUnidad] ON [SalidasLiniasMedicaciones];");
			migrationBuilder.Sql("CREATE INDEX [IX_SalidasLiniasMedicaciones_IdUnidad] ON [SalidasLiniasMedicaciones]([IdUnidad]);");

			migrationBuilder.DropForeignKey(
				name: "FK_SalidasLiniasMedicaciones_Unidades",
				table: "SalidasLiniasMedicaciones");

			migrationBuilder.DropForeignKey(
				name: "FK_SalidasLiniasMedicaciones_Medicaciones",
				table: "SalidasLiniasMedicaciones");

			migrationBuilder.DropForeignKey(
				name: "FK_VentasLiniasMedicaciones_SalidasLiniasMedicaciones",
				table: "VentasLiniasMedicaciones");

			migrationBuilder.DropForeignKey(
				name: "FK_VentasLiniasMedicaciones_Medicaciones",
				table: "VentasLiniasMedicaciones");

			migrationBuilder.DropForeignKey(
				name: "FK_VentasLiniasMedicaciones_Unidades",
				table: "VentasLiniasMedicaciones");

			migrationBuilder.DropForeignKey(
				name: "FK_VentasLiniasMedicaciones_VentasLinias",
				table: "VentasLiniasMedicaciones");

			migrationBuilder.DropIndex(
				name: "IX_VentasLiniasMedicaciones_idLineaSalidaMedicamento",
				table: "VentasLiniasMedicaciones");

			migrationBuilder.DropIndex(
				name: "IX_VentasLiniasMedicaciones_idMedicamento",
				table: "VentasLiniasMedicaciones");

			migrationBuilder.DropIndex(
				name: "IX_SalidasLiniasMedicaciones_idMedicamento",
				table: "SalidasLiniasMedicaciones");

			migrationBuilder.DropColumn(
				name: "idLineaSalidaMedicamento",
				table: "VentasLiniasMedicaciones");

			migrationBuilder.DropColumn(
				name: "idMedicamento",
				table: "VentasLiniasMedicaciones");

			migrationBuilder.DropColumn(
				name: "idMedicamento",
				table: "SalidasLiniasMedicaciones");

			migrationBuilder.AlterColumn<int>(
				name: "idVentaLinia",
				table: "VentasLiniasMedicaciones",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "idUnidad",
				table: "VentasLiniasMedicaciones",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<decimal>(
				name: "PrecioUnidad",
				table: "VentasLiniasMedicaciones",
				type: "decimal(18, 2)",
				nullable: true,
				oldClrType: typeof(decimal),
				oldType: "numeric(18, 6)",
				oldNullable: true);

			migrationBuilder.AlterColumn<decimal>(
				name: "Precio",
				table: "VentasLiniasMedicaciones",
				type: "decimal(18, 2)",
				nullable: true,
				oldClrType: typeof(decimal),
				oldType: "numeric(18, 6)",
				oldNullable: true);

			migrationBuilder.AlterColumn<DateTime>(
				name: "Fecha",
				table: "VentasLiniasMedicaciones",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldType: "datetime",
				oldNullable: true);

			migrationBuilder.AlterColumn<decimal>(
				name: "Cantidad",
				table: "VentasLiniasMedicaciones",
				type: "decimal(18, 3)",
				nullable: false,
				oldClrType: typeof(decimal),
				oldType: "numeric(18, 3)",
				oldNullable: true);

			migrationBuilder.AlterColumn<decimal>(
				name: "Bultos",
				table: "VentasLiniasMedicaciones",
				type: "decimal(18, 2)",
				nullable: true,
				oldClrType: typeof(decimal),
				oldType: "numeric(18, 3)",
				oldNullable: true);

			migrationBuilder.AddColumn<int>(
				name: "ProductoId",
				table: "VentasLiniasMedicaciones",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AlterColumn<int>(
				name: "idSalidaLinia",
				table: "SalidasLiniasMedicaciones",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<decimal>(
				name: "PrecioUnidad",
				table: "SalidasLiniasMedicaciones",
				type: "decimal(18, 2)",
				nullable: true,
				oldClrType: typeof(decimal),
				oldType: "numeric(18, 6)",
				oldNullable: true);

			migrationBuilder.AlterColumn<decimal>(
				name: "Precio",
				table: "SalidasLiniasMedicaciones",
				type: "decimal(18, 2)",
				nullable: true,
				oldClrType: typeof(decimal),
				oldType: "numeric(18, 6)",
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "IdUnidad",
				table: "SalidasLiniasMedicaciones",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<DateTime>(
				name: "Fecha",
				table: "SalidasLiniasMedicaciones",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldType: "datetime",
				oldNullable: true);

			migrationBuilder.AlterColumn<decimal>(
				name: "Cantidad",
				table: "SalidasLiniasMedicaciones",
				type: "decimal(18, 3)",
				nullable: false,
				oldClrType: typeof(decimal),
				oldType: "numeric(18, 3)",
				oldNullable: true);

			migrationBuilder.AlterColumn<decimal>(
				name: "Bultos",
				table: "SalidasLiniasMedicaciones",
				type: "decimal(18, 2)",
				nullable: true,
				oldClrType: typeof(decimal),
				oldType: "numeric(18, 3)",
				oldNullable: true);

			migrationBuilder.AddColumn<int>(
				name: "ProductoId",
				table: "SalidasLiniasMedicaciones",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<int>(
				name: "MedicacionId",
				table: "SalidasLinias",
				nullable: true);

			migrationBuilder.AlterColumn<DateTime>(
				name: "Fecha",
				table: "Medicaciones",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldType: "datetime",
				oldNullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_VentasLiniasMedicaciones_ProductoId",
				table: "VentasLiniasMedicaciones",
				column: "ProductoId");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLiniasMedicaciones_ProductoId",
				table: "SalidasLiniasMedicaciones",
				column: "ProductoId");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLinias_MedicacionId",
				table: "SalidasLinias",
				column: "MedicacionId");

			migrationBuilder.AddForeignKey(
				name: "FK_SalidasLinias_Medicaciones_MedicacionId",
				table: "SalidasLinias",
				column: "MedicacionId",
				principalTable: "Medicaciones",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_SalidasLiniasMedicaciones_Unidades",
				table: "SalidasLiniasMedicaciones",
				column: "IdUnidad",
				principalTable: "Unidades",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_SalidasLiniasMedicaciones_Productos_ProductoId",
				table: "SalidasLiniasMedicaciones",
				column: "ProductoId",
				principalTable: "Productos",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_VentasLiniasMedicaciones_Productos_ProductoId",
				table: "VentasLiniasMedicaciones",
				column: "ProductoId",
				principalTable: "Productos",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_VentasLiniasMedicaciones_Unidades",
				table: "VentasLiniasMedicaciones",
				column: "idUnidad",
				principalTable: "Unidades",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_VentasLiniasMedicaciones_VentasLinias",
				table: "VentasLiniasMedicaciones",
				column: "idVentaLinia",
				principalTable: "VentasLinias",
				principalColumn: "id",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_SalidasLinias_Medicaciones_MedicacionId",
				table: "SalidasLinias");

			migrationBuilder.DropForeignKey(
				name: "FK_SalidasLiniasMedicaciones_Unidades",
				table: "SalidasLiniasMedicaciones");

			migrationBuilder.DropForeignKey(
				name: "FK_SalidasLiniasMedicaciones_Productos_ProductoId",
				table: "SalidasLiniasMedicaciones");

			migrationBuilder.DropForeignKey(
				name: "FK_VentasLiniasMedicaciones_Productos_ProductoId",
				table: "VentasLiniasMedicaciones");

			migrationBuilder.DropForeignKey(
				name: "FK_VentasLiniasMedicaciones_Unidades",
				table: "VentasLiniasMedicaciones");

			migrationBuilder.DropForeignKey(
				name: "FK_VentasLiniasMedicaciones_VentasLinias",
				table: "VentasLiniasMedicaciones");

			migrationBuilder.DropIndex(
				name: "IX_VentasLiniasMedicaciones_ProductoId",
				table: "VentasLiniasMedicaciones");

			migrationBuilder.DropIndex(
				name: "IX_SalidasLiniasMedicaciones_ProductoId",
				table: "SalidasLiniasMedicaciones");

			migrationBuilder.DropIndex(
				name: "IX_SalidasLinias_MedicacionId",
				table: "SalidasLinias");

			migrationBuilder.DropColumn(
				name: "ProductoId",
				table: "VentasLiniasMedicaciones");

			migrationBuilder.DropColumn(
				name: "ProductoId",
				table: "SalidasLiniasMedicaciones");

			migrationBuilder.DropColumn(
				name: "MedicacionId",
				table: "SalidasLinias");

			migrationBuilder.AlterColumn<int>(
				name: "idVentaLinia",
				table: "VentasLiniasMedicaciones",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AlterColumn<int>(
				name: "idUnidad",
				table: "VentasLiniasMedicaciones",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AlterColumn<decimal>(
				name: "PrecioUnidad",
				table: "VentasLiniasMedicaciones",
				type: "numeric(18, 6)",
				nullable: true,
				oldClrType: typeof(decimal),
				oldType: "decimal(18, 2)",
				oldNullable: true);

			migrationBuilder.AlterColumn<decimal>(
				name: "Precio",
				table: "VentasLiniasMedicaciones",
				type: "numeric(18, 6)",
				nullable: true,
				oldClrType: typeof(decimal),
				oldType: "decimal(18, 2)",
				oldNullable: true);

			migrationBuilder.AlterColumn<DateTime>(
				name: "Fecha",
				table: "VentasLiniasMedicaciones",
				type: "datetime",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldNullable: true);

			migrationBuilder.AlterColumn<decimal>(
				name: "Cantidad",
				table: "VentasLiniasMedicaciones",
				type: "numeric(18, 3)",
				nullable: true,
				oldClrType: typeof(decimal),
				oldType: "decimal(18, 3)");

			migrationBuilder.AlterColumn<decimal>(
				name: "Bultos",
				table: "VentasLiniasMedicaciones",
				type: "numeric(18, 3)",
				nullable: true,
				oldClrType: typeof(decimal),
				oldType: "decimal(18, 2)",
				oldNullable: true);

			migrationBuilder.AddColumn<int>(
				name: "idLineaSalidaMedicamento",
				table: "VentasLiniasMedicaciones",
				type: "int",
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "idMedicamento",
				table: "VentasLiniasMedicaciones",
				type: "int",
				nullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "idSalidaLinia",
				table: "SalidasLiniasMedicaciones",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AlterColumn<decimal>(
				name: "PrecioUnidad",
				table: "SalidasLiniasMedicaciones",
				type: "numeric(18, 6)",
				nullable: true,
				oldClrType: typeof(decimal),
				oldType: "decimal(18, 2)",
				oldNullable: true);

			migrationBuilder.AlterColumn<decimal>(
				name: "Precio",
				table: "SalidasLiniasMedicaciones",
				type: "numeric(18, 6)",
				nullable: true,
				oldClrType: typeof(decimal),
				oldType: "decimal(18, 2)",
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "IdUnidad",
				table: "SalidasLiniasMedicaciones",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AlterColumn<DateTime>(
				name: "Fecha",
				table: "SalidasLiniasMedicaciones",
				type: "datetime",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldNullable: true);

			migrationBuilder.AlterColumn<decimal>(
				name: "Cantidad",
				table: "SalidasLiniasMedicaciones",
				type: "numeric(18, 3)",
				nullable: true,
				oldClrType: typeof(decimal),
				oldType: "decimal(18, 3)");

			migrationBuilder.AlterColumn<decimal>(
				name: "Bultos",
				table: "SalidasLiniasMedicaciones",
				type: "numeric(18, 3)",
				nullable: true,
				oldClrType: typeof(decimal),
				oldType: "decimal(18, 2)",
				oldNullable: true);

			migrationBuilder.AddColumn<int>(
				name: "idMedicamento",
				table: "SalidasLiniasMedicaciones",
				type: "int",
				nullable: true);

			migrationBuilder.AlterColumn<DateTime>(
				name: "Fecha",
				table: "Medicaciones",
				type: "datetime",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldNullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_VentasLiniasMedicaciones_idLineaSalidaMedicamento",
				table: "VentasLiniasMedicaciones",
				column: "idLineaSalidaMedicamento");

			migrationBuilder.CreateIndex(
				name: "IX_VentasLiniasMedicaciones_idMedicamento",
				table: "VentasLiniasMedicaciones",
				column: "idMedicamento");

			migrationBuilder.CreateIndex(
				name: "IX_SalidasLiniasMedicaciones_idMedicamento",
				table: "SalidasLiniasMedicaciones",
				column: "idMedicamento");

			migrationBuilder.AddForeignKey(
				name: "FK_SalidasLiniasMedicaciones_Unidades",
				table: "SalidasLiniasMedicaciones",
				column: "IdUnidad",
				principalTable: "Unidades",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_SalidasLiniasMedicaciones_Medicaciones",
				table: "SalidasLiniasMedicaciones",
				column: "idMedicamento",
				principalTable: "Medicaciones",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_VentasLiniasMedicaciones_SalidasLiniasMedicaciones",
				table: "VentasLiniasMedicaciones",
				column: "idLineaSalidaMedicamento",
				principalTable: "SalidasLiniasMedicaciones",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_VentasLiniasMedicaciones_Medicaciones",
				table: "VentasLiniasMedicaciones",
				column: "idMedicamento",
				principalTable: "Medicaciones",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_VentasLiniasMedicaciones_Unidades",
				table: "VentasLiniasMedicaciones",
				column: "idUnidad",
				principalTable: "Unidades",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_VentasLiniasMedicaciones_VentasLinias",
				table: "VentasLiniasMedicaciones",
				column: "idVentaLinia",
				principalTable: "VentasLinias",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);
		}
	}
}
