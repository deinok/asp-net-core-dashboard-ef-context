using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class BufferConsumidosProducidosVariable1Variable2 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<decimal>(
				name: "Variable2",
				table: "BufferProducidos",
				nullable: true,
				oldClrType: typeof(decimal),
				oldType: "decimal(12, 5)",
				oldNullable: true);

			migrationBuilder.AlterColumn<decimal>(
				name: "Variable1",
				table: "BufferProducidos",
				nullable: true,
				oldClrType: typeof(decimal),
				oldType: "decimal(12, 5)",
				oldNullable: true);

			migrationBuilder.AlterColumn<decimal>(
				name: "Variable2",
				table: "BufferConsumidos",
				nullable: true,
				oldClrType: typeof(decimal),
				oldType: "decimal(12, 5)",
				oldNullable: true);

			migrationBuilder.AlterColumn<decimal>(
				name: "Variable1",
				table: "BufferConsumidos",
				nullable: true,
				oldClrType: typeof(decimal),
				oldType: "decimal(12, 5)",
				oldNullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<decimal>(
				name: "Variable2",
				table: "BufferProducidos",
				type: "decimal(12, 5)",
				nullable: true,
				oldClrType: typeof(decimal),
				oldNullable: true);

			migrationBuilder.AlterColumn<decimal>(
				name: "Variable1",
				table: "BufferProducidos",
				type: "decimal(12, 5)",
				nullable: true,
				oldClrType: typeof(decimal),
				oldNullable: true);

			migrationBuilder.AlterColumn<decimal>(
				name: "Variable2",
				table: "BufferConsumidos",
				type: "decimal(12, 5)",
				nullable: true,
				oldClrType: typeof(decimal),
				oldNullable: true);

			migrationBuilder.AlterColumn<decimal>(
				name: "Variable1",
				table: "BufferConsumidos",
				type: "decimal(12, 5)",
				nullable: true,
				oldClrType: typeof(decimal),
				oldNullable: true);
		}
	}
}
