using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class ComponentesActivosModified : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_ComponentesActivos_IdCompActivosLista] ON [ComponentesActivos];");
			migrationBuilder.Sql("CREATE INDEX [IX_ComponentesActivos_IdCompActivosLista] ON [ComponentesActivos] ([IdCompActivosLista]);");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IX_ComponentesActivos_Producto] ON [ComponentesActivos];");
			migrationBuilder.Sql("CREATE INDEX [IX_ComponentesActivos_Producto] ON [ComponentesActivos] ([Producto]);");

			migrationBuilder.DropForeignKey(
				name: "FK_ComponentesActivos_CompActivosLista",
				table: "ComponentesActivos");

			migrationBuilder.DropForeignKey(
				name: "FK_ComponentesActivos_Productos",
				table: "ComponentesActivos");

			migrationBuilder.DropTable(
				name: "CompActivosLista");

			migrationBuilder.DropPrimaryKey(
				name: "PK_ComponentesActivos",
				table: "ComponentesActivos");

			migrationBuilder.DropIndex(
				name: "IX_ComponentesActivos_IdCompActivosLista",
				table: "ComponentesActivos");

			migrationBuilder.DropIndex(
				name: "IX_ComponentesActivos_Producto",
				table: "ComponentesActivos");

			migrationBuilder.DropColumn(
				name: "Id",
				table: "ComponentesActivos");

			migrationBuilder.DropColumn(
				name: "IdCompActivosLista",
				table: "ComponentesActivos");

			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "ComponentesActivos",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "ComponentesActivos",
				nullable: false,
				oldClrType: typeof(bool),
				oldType: "bit",
				oldNullable: true);

			migrationBuilder.AlterColumn<float>(
				name: "Cantidad",
				table: "ComponentesActivos",
				nullable: false,
				oldClrType: typeof(float),
				oldType: "real",
				oldNullable: true);

			migrationBuilder.AddColumn<int>(
				name: "Orden",
				table: "ComponentesActivos",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<string>(
				name: "Nombre",
				table: "ComponentesActivos",
				maxLength: 120,
				nullable: false,
				defaultValue: "");

			migrationBuilder.AddColumn<int>(
				name: "Unidad",
				table: "ComponentesActivos",
				nullable: true);

			migrationBuilder.AddPrimaryKey(
				name: "PK_ComponentesActivos",
				table: "ComponentesActivos",
				columns: new[] { "Producto", "Orden" });

			migrationBuilder.CreateIndex(
				name: "IX_ComponentesActivos_Unidad",
				table: "ComponentesActivos",
				column: "Unidad");

			migrationBuilder.AddForeignKey(
				name: "FK_ComponentesActivos_Productos_Producto",
				table: "ComponentesActivos",
				column: "Producto",
				principalTable: "Productos",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
				name: "FK_ComponentesActivos_Unidades_Unidad",
				table: "ComponentesActivos",
				column: "Unidad",
				principalTable: "Unidades",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_ComponentesActivos_Productos_Producto",
				table: "ComponentesActivos");

			migrationBuilder.DropForeignKey(
				name: "FK_ComponentesActivos_Unidades_Unidad",
				table: "ComponentesActivos");

			migrationBuilder.DropPrimaryKey(
				name: "PK_ComponentesActivos",
				table: "ComponentesActivos");

			migrationBuilder.DropIndex(
				name: "IX_ComponentesActivos_Unidad",
				table: "ComponentesActivos");

			migrationBuilder.DropColumn(
				name: "Orden",
				table: "ComponentesActivos");

			migrationBuilder.DropColumn(
				name: "Nombre",
				table: "ComponentesActivos");

			migrationBuilder.DropColumn(
				name: "Unidad",
				table: "ComponentesActivos");

			migrationBuilder.AlterColumn<bool>(
				name: "Importado",
				table: "ComponentesActivos",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<bool>(
				name: "Exportado",
				table: "ComponentesActivos",
				type: "bit",
				nullable: true,
				oldClrType: typeof(bool));

			migrationBuilder.AlterColumn<float>(
				name: "Cantidad",
				table: "ComponentesActivos",
				type: "real",
				nullable: true,
				oldClrType: typeof(float));

			migrationBuilder.AddColumn<int>(
				name: "Id",
				table: "ComponentesActivos",
				type: "int",
				nullable: false,
				defaultValue: 0)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AddColumn<int>(
				name: "IdCompActivosLista",
				table: "ComponentesActivos",
				type: "int",
				nullable: true);

			migrationBuilder.AddPrimaryKey(
				name: "PK_ComponentesActivos",
				table: "ComponentesActivos",
				column: "Id");

			migrationBuilder.CreateTable(
				name: "CompActivosLista",
				columns: table => new
				{
					id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
					Medicamento = table.Column<bool>(type: "bit", nullable: true),
					Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
					Unidad = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CompActivosLista", x => x.id);
					table.ForeignKey(
						name: "FK_CompActivosLista_Unidades",
						column: x => x.Unidad,
						principalTable: "Unidades",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				name: "IX_ComponentesActivos_IdCompActivosLista",
				table: "ComponentesActivos",
				column: "IdCompActivosLista");

			migrationBuilder.CreateIndex(
				name: "IX_ComponentesActivos_Producto",
				table: "ComponentesActivos",
				column: "Producto");

			migrationBuilder.CreateIndex(
				name: "IX_CompActivosLista_Unidad",
				table: "CompActivosLista",
				column: "Unidad");

			migrationBuilder.AddForeignKey(
				name: "FK_ComponentesActivos_CompActivosLista",
				table: "ComponentesActivos",
				column: "IdCompActivosLista",
				principalTable: "CompActivosLista",
				principalColumn: "id",
				onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
				name: "FK_ComponentesActivos_Productos",
				table: "ComponentesActivos",
				column: "Producto",
				principalTable: "Productos",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}
	}
}
