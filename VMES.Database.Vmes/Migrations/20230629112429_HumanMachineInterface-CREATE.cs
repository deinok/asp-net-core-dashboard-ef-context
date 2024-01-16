using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class HumanMachineInterfaceCREATE : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "HumanMachineInterfaces",
				columns: table => new
				{
					Id = table.Column<int>(nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Enabled = table.Column<bool>(nullable: false),
					Name = table.Column<string>(maxLength: 64, nullable: false),
					Height = table.Column<int>(nullable: false),
					Type = table.Column<byte>(nullable: false),
					Width = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_HumanMachineInterfaces", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "BasculasHumanMachineInterfaces",
				columns: table => new
				{
					BasculaId = table.Column<int>(nullable: false),
					HumanMachineInterfaceId = table.Column<int>(nullable: false),
					Default = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_BasculasHumanMachineInterfaces", x => new { x.BasculaId, x.HumanMachineInterfaceId });
					table.ForeignKey(
						name: "FK_BasculasHumanMachineInterfaces_Basculas_BasculaId",
						column: x => x.BasculaId,
						principalTable: "Basculas",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_BasculasHumanMachineInterfaces_HumanMachineInterfaces_HumanMachineInterfaceId",
						column: x => x.HumanMachineInterfaceId,
						principalTable: "HumanMachineInterfaces",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_BasculasHumanMachineInterfaces_HumanMachineInterfaceId",
				table: "BasculasHumanMachineInterfaces",
				column: "HumanMachineInterfaceId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "BasculasHumanMachineInterfaces");

			migrationBuilder.DropTable(
				name: "HumanMachineInterfaces");
		}
	}
}
