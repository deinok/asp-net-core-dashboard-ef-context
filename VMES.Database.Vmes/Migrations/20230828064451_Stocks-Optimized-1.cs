using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class StocksOptimized1 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP INDEX IF EXISTS [IStocks2] ON [Stocks];");
			migrationBuilder.Sql("CREATE INDEX [IStocks2] ON [Stocks]([Id]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_Stocks_Lote] ON [Stocks];");
			migrationBuilder.Sql("CREATE INDEX [IX_Stocks_Lote] ON [Stocks]([Id]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_Stocks_Ubicacion_Estado] ON [Stocks];");
			migrationBuilder.Sql("CREATE INDEX [IX_Stocks_Ubicacion_Estado] ON [Stocks]([Id]);");

			migrationBuilder.Sql("UPDATE [Stocks] SET [Exportado] = 0 WHERE [Exportado] IS NULL;");
			migrationBuilder.Sql("UPDATE [Stocks] SET [Fecha] = '1900-01-01' WHERE [Fecha] IS NULL;");
			migrationBuilder.Sql("UPDATE [Stocks] SET [Importado] = 0 WHERE [Importado] IS NULL;");

			migrationBuilder.DropForeignKey(
				name: "FK_LogMovimientosStocks_Stocks",
				table: "LogMovimientosStocks");

			migrationBuilder.DropForeignKey(
				name: "FK_Stocks_Envases",
				table: "Stocks");

			migrationBuilder.DropForeignKey(
				name: "FK_Stocks_Formatos",
				table: "Stocks");

			migrationBuilder.DropForeignKey(
				name: "FK_Stocks_Lotes",
				table: "Stocks");

			migrationBuilder.DropForeignKey(
				name: "FK_Stocks_Productos",
				table: "Stocks");

			migrationBuilder.DropForeignKey(
				name: "FK_Stocks_Ubicaciones",
				table: "Stocks");

			migrationBuilder.DropForeignKey(
				name: "FK_Stocks_Unidades",
				table: "Stocks");

			migrationBuilder.DropForeignKey(
				name: "FK_Stocks_EntradasLineas",
				table: "Stocks");

			migrationBuilder.DropForeignKey(
				name: "FK_Stocks_SalidasLinias",
				table: "Stocks");

			migrationBuilder.DropIndex(
				name: "I_StocksUbis",
				table: "Stocks");

			migrationBuilder.DropIndex(
				name: "IX_Stocks_Ubicacion_Estado",
				table: "Stocks");

			migrationBuilder.DropIndex(
				name: "IStocks1",
				table: "Stocks");

			migrationBuilder.DropColumn(
				name: "Producto",
				table: "Stocks");

			migrationBuilder.AlterColumn<int>(
				name: "Ubicacion",
				table: "Stocks",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<int>(
				name: "Lote",
				table: "Stocks",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "Stocks",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<DateTime>(
				name: "FechaERP",
				table: "Stocks",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldType: "datetime",
				oldNullable: true);

			migrationBuilder.AlterColumn<DateTime>(
				name: "Fecha",
				table: "Stocks",
				nullable: false,
				oldClrType: typeof(DateTime),
				oldType: "datetime",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Stocks",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AddForeignKey(
				name: "FK_LogMovimientosStocks_Stocks_IdStock",
				table: "LogMovimientosStocks",
				column: "IdStock",
				principalTable: "Stocks",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Stocks_Envases_Envase",
				table: "Stocks",
				column: "Envase",
				principalTable: "Envases",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Stocks_Formatos_Formato",
				table: "Stocks",
				column: "Formato",
				principalTable: "Formatos",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Stocks_Lotes_Lote",
				table: "Stocks",
				column: "Lote",
				principalTable: "Lotes",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Stocks_Ubicaciones_Ubicacion",
				table: "Stocks",
				column: "Ubicacion",
				principalTable: "Ubicaciones",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Stocks_Unidades_Unidad",
				table: "Stocks",
				column: "Unidad",
				principalTable: "Unidades",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Stocks_EntradasLineas_idEntradasLineas",
				table: "Stocks",
				column: "idEntradasLineas",
				principalTable: "EntradasLineas",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Stocks_SalidasLinias_idSalidasLineas",
				table: "Stocks",
				column: "idSalidasLineas",
				principalTable: "SalidasLinias",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_LogMovimientosStocks_Stocks_IdStock",
				table: "LogMovimientosStocks");

			migrationBuilder.DropForeignKey(
				name: "FK_Stocks_Envases_Envase",
				table: "Stocks");

			migrationBuilder.DropForeignKey(
				name: "FK_Stocks_Formatos_Formato",
				table: "Stocks");

			migrationBuilder.DropForeignKey(
				name: "FK_Stocks_Lotes_Lote",
				table: "Stocks");

			migrationBuilder.DropForeignKey(
				name: "FK_Stocks_Ubicaciones_Ubicacion",
				table: "Stocks");

			migrationBuilder.DropForeignKey(
				name: "FK_Stocks_Unidades_Unidad",
				table: "Stocks");

			migrationBuilder.DropForeignKey(
				name: "FK_Stocks_EntradasLineas_idEntradasLineas",
				table: "Stocks");

			migrationBuilder.DropForeignKey(
				name: "FK_Stocks_SalidasLinias_idSalidasLineas",
				table: "Stocks");

			migrationBuilder.AlterColumn<int>(
				name: "Ubicacion",
				table: "Stocks",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AlterColumn<int>(
				name: "Lote",
				table: "Stocks",
				type: "int",
				nullable: true,
				oldClrType: typeof(int));

			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "Stocks",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<DateTime>(
				name: "FechaERP",
				table: "Stocks",
				type: "datetime",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldNullable: true);

			migrationBuilder.AlterColumn<DateTime>(
				name: "Fecha",
				table: "Stocks",
				type: "datetime",
				nullable: true,
				oldClrType: typeof(DateTime));

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "Stocks",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AddColumn<int>(
				name: "Producto",
				table: "Stocks",
				type: "int",
				nullable: true);

			migrationBuilder.CreateIndex(
				name: "I_StocksUbis",
				table: "Stocks",
				columns: new[] { "Ubicacion", "Cantidad", "Estado" });

			migrationBuilder.CreateIndex(
				name: "IX_Stocks_Ubicacion_Estado",
				table: "Stocks",
				columns: new[] { "Lote", "Fecha", "Ubicacion", "Estado" });

			migrationBuilder.CreateIndex(
				name: "IStocks1",
				table: "Stocks",
				columns: new[] { "Producto", "Formato", "Lote", "Envase", "Cantidad", "Unidad", "Fecha", "Estado", "Importado", "Exportado", "Palet", "Procesando", "Observaciones", "idOld", "idEntradasLineas", "idSalidasLineas", "Ubicacion", "Id" });

			migrationBuilder.AddForeignKey(
				name: "FK_LogMovimientosStocks_Stocks",
				table: "LogMovimientosStocks",
				column: "IdStock",
				principalTable: "Stocks",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Stocks_Envases",
				table: "Stocks",
				column: "Envase",
				principalTable: "Envases",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Stocks_Formatos",
				table: "Stocks",
				column: "Formato",
				principalTable: "Formatos",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Stocks_Lotes",
				table: "Stocks",
				column: "Lote",
				principalTable: "Lotes",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_Stocks_Productos",
				table: "Stocks",
				column: "Producto",
				principalTable: "Productos",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Stocks_Ubicaciones",
				table: "Stocks",
				column: "Ubicacion",
				principalTable: "Ubicaciones",
				principalColumn: "Id",
				onDelete: ReferentialAction.SetNull);

			migrationBuilder.AddForeignKey(
				name: "FK_Stocks_Unidades",
				table: "Stocks",
				column: "Unidad",
				principalTable: "Unidades",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_Stocks_EntradasLineas",
				table: "Stocks",
				column: "idEntradasLineas",
				principalTable: "EntradasLineas",
				principalColumn: "id",
				onDelete: ReferentialAction.SetNull);

			migrationBuilder.AddForeignKey(
				name: "FK_Stocks_SalidasLinias",
				table: "Stocks",
				column: "idSalidasLineas",
				principalTable: "SalidasLinias",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);
		}
	}
}
