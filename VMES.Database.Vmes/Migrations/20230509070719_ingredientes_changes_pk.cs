using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class ingredientes_changes_pk : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_MedicacionesIngredientes",
				table: "MedicacionesIngredientes");

			migrationBuilder.DropColumn(
				name: "Orden",
				table: "MedicacionesIngredientes");

			migrationBuilder.AddPrimaryKey(
				name: "PK_MedicacionesIngredientes",
				table: "MedicacionesIngredientes",
				columns: new[] { "Medicacion", "Producto" });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_MedicacionesIngredientes",
				table: "MedicacionesIngredientes");

			migrationBuilder.AddColumn<int>(
				name: "Orden",
				table: "MedicacionesIngredientes",
				type: "int",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddPrimaryKey(
				name: "PK_MedicacionesIngredientes",
				table: "MedicacionesIngredientes",
				columns: new[] { "Medicacion", "Orden" });
		}
	}
}
