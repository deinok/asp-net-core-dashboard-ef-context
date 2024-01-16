using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class ProductoMedidorCamino : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "ProductoMedidorCamino",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					CaminoId = table.Column<int>(nullable: false),
					MedidorId = table.Column<int>(nullable: false),
					ProductoId = table.Column<int>(nullable: false),
					Activo = table.Column<bool>(nullable: false, defaultValueSql: "1"),
					Tipo = table.Column<byte>(nullable: false),
					FechaCreacion = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
					FechaEdicion = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ProductoMedidorCamino", x => x.Id);
					table.ForeignKey(
						name: "FK_ProductoMedidorCamino_Caminos_CaminoId",
						column: x => x.CaminoId,
						principalTable: "Caminos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_ProductoMedidorCamino_Medidores_MedidorId",
						column: x => x.MedidorId,
						principalTable: "Medidores",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_ProductoMedidorCamino_Productos_ProductoId",
						column: x => x.ProductoId,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_ProductoMedidorCamino_MedidorId",
				table: "ProductoMedidorCamino",
				column: "MedidorId");

			migrationBuilder.CreateIndex(
				name: "IX_ProductoMedidorCamino_ProductoId",
				table: "ProductoMedidorCamino",
				column: "ProductoId");

			migrationBuilder.CreateIndex(
				name: "IX_ProductoMedidorCamino_CaminoId_MedidorId_ProductoId",
				table: "ProductoMedidorCamino",
				columns: new[] { "CaminoId", "MedidorId", "ProductoId" },
				unique: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "ProductoMedidorCamino");
		}
	}
}
