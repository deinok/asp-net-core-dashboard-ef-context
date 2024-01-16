using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class PLCAddonsDrop : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "PLCAddonsVars");

			migrationBuilder.DropTable(
				name: "PLCRead");

			migrationBuilder.DropTable(
				name: "PLCWrite");

			migrationBuilder.DropTable(
				name: "PLCAddons");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "PLCAddons",
				columns: table => new
				{
					id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Descripción = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Tipo = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PLCAddons", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "PLCRead",
				columns: table => new
				{
					id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					UltimaLectura = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
					Valor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
					posicion = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PLCRead", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "PLCWrite",
				columns: table => new
				{
					id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Estado = table.Column<int>(type: "int", nullable: false),
					FechaEnviado = table.Column<DateTime>(type: "datetime", nullable: false),
					FechaWrite = table.Column<DateTime>(type: "datetime", nullable: true),
					Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Valor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PLCWrite", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "PLCAddonsVars",
				columns: table => new
				{
					id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
					Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Tipo = table.Column<int>(type: "int", nullable: false),
					idAddon = table.Column<int>(type: "int", nullable: true),
					subscribir = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PLCAddonsVars", x => x.id);
					table.ForeignKey(
						name: "FK_PLCAddonsVars_PLCAddons",
						column: x => x.idAddon,
						principalTable: "PLCAddons",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_PLCAddonsVars_idAddon",
				table: "PLCAddonsVars",
				column: "idAddon");

			migrationBuilder.CreateIndex(
				name: "IX_PLCRead",
				table: "PLCRead",
				column: "Nombre");
		}
	}
}
