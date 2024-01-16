using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class ProductoEnvaseEtiqueta : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "ProductosEnvasesEtiquetas",
				columns: table => new
				{
					ProductoId = table.Column<int>(nullable: false),
					EnvaseId = table.Column<int>(nullable: false),
					Type = table.Column<byte>(nullable: false),
					Code = table.Column<string>(maxLength: 128, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ProductosEnvasesEtiquetas", x => new { x.ProductoId, x.EnvaseId });
					table.ForeignKey(
						name: "FK_ProductosEnvasesEtiquetas_Envases_EnvaseId",
						column: x => x.EnvaseId,
						principalTable: "Envases",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_ProductosEnvasesEtiquetas_Productos_ProductoId",
						column: x => x.ProductoId,
						principalTable: "Productos",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_ProductosEnvasesEtiquetas_EnvaseId",
				table: "ProductosEnvasesEtiquetas",
				column: "EnvaseId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "ProductosEnvasesEtiquetas");
		}
	}
}
