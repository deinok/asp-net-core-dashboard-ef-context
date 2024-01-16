using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class BufferErpVentasLineasBufferErpVentaId : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "BufferErpVentaId",
				table: "BufferERPVentasLineas",
				nullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_BufferERPVentasLineas_BufferErpVentaId",
				table: "BufferERPVentasLineas",
				column: "BufferErpVentaId");

			migrationBuilder.AddForeignKey(
				name: "FK_BufferERPVentasLineas_BufferERPVentas_BufferErpVentaId",
				table: "BufferERPVentasLineas",
				column: "BufferErpVentaId",
				principalTable: "BufferERPVentas",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_BufferERPVentasLineas_BufferERPVentas_BufferErpVentaId",
				table: "BufferERPVentasLineas");

			migrationBuilder.DropIndex(
				name: "IX_BufferERPVentasLineas_BufferErpVentaId",
				table: "BufferERPVentasLineas");

			migrationBuilder.DropColumn(
				name: "BufferErpVentaId",
				table: "BufferERPVentasLineas");
		}
	}
}
