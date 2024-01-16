using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class HumanMachineInterfaceDiscriminated : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "HumanMachineInterfaceBasculas");

			migrationBuilder.DropTable(
				name: "HumanMachineInterfaceTags");

			migrationBuilder.AddColumn<int>(
				name: "TagId",
				table: "HumanMachineInterfaces",
				nullable: true);

			migrationBuilder.CreateIndex(
				name: "IX_HumanMachineInterfaces_TagId",
				table: "HumanMachineInterfaces",
				column: "TagId");

			migrationBuilder.AddForeignKey(
				name: "FK_HumanMachineInterfaces_Tags_TagId",
				table: "HumanMachineInterfaces",
				column: "TagId",
				principalTable: "Tags",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_HumanMachineInterfaces_Tags_TagId",
				table: "HumanMachineInterfaces");

			migrationBuilder.DropIndex(
				name: "IX_HumanMachineInterfaces_TagId",
				table: "HumanMachineInterfaces");

			migrationBuilder.DropColumn(
				name: "TagId",
				table: "HumanMachineInterfaces");

			migrationBuilder.CreateTable(
				name: "HumanMachineInterfaceBasculas",
				columns: table => new
				{
					HumanMachineInterfaceId = table.Column<int>(type: "int", nullable: false),
					BasculaId = table.Column<int>(type: "int", nullable: false),
					Default = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_HumanMachineInterfaceBasculas", x => new { x.HumanMachineInterfaceId, x.BasculaId });
					table.ForeignKey(
						name: "FK_HumanMachineInterfaceBasculas_Basculas_BasculaId",
						column: x => x.BasculaId,
						principalTable: "Basculas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_HumanMachineInterfaceBasculas_HumanMachineInterfaces_HumanMachineInterfaceId",
						column: x => x.HumanMachineInterfaceId,
						principalTable: "HumanMachineInterfaces",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "HumanMachineInterfaceTags",
				columns: table => new
				{
					HumanMachineInterfaceId = table.Column<int>(type: "int", nullable: false),
					TagId = table.Column<int>(type: "int", nullable: false),
					Default = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_HumanMachineInterfaceTags", x => new { x.HumanMachineInterfaceId, x.TagId });
					table.ForeignKey(
						name: "FK_HumanMachineInterfaceTags_HumanMachineInterfaces_HumanMachineInterfaceId",
						column: x => x.HumanMachineInterfaceId,
						principalTable: "HumanMachineInterfaces",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_HumanMachineInterfaceTags_Tags_TagId",
						column: x => x.TagId,
						principalTable: "Tags",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_HumanMachineInterfaceBasculas_BasculaId",
				table: "HumanMachineInterfaceBasculas",
				column: "BasculaId");

			migrationBuilder.CreateIndex(
				name: "IX_HumanMachineInterfaceTags_TagId",
				table: "HumanMachineInterfaceTags",
				column: "TagId");
		}
	}
}
