using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class gmao_element_trigger_task : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "GMAO_ElementReviewTasks",
				columns: table => new
				{
					Id = table.Column<Guid>(nullable: false),
					ElementId = table.Column<int>(nullable: false),
					TaskId = table.Column<int>(nullable: false),
					TriggerType = table.Column<byte>(nullable: false),
					Comments = table.Column<string>(maxLength: 256, nullable: true),
					CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
					UpdatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
					IsEnabled = table.Column<bool>(nullable: false),
					Threshold = table.Column<int>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GMAO_ElementReviewTasks", x => x.Id);
					table.ForeignKey(
						name: "FK_GMAO_ElementReviewTasks_GMAO_Elementos_ElementId",
						column: x => x.ElementId,
						principalTable: "GMAO_Elementos",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_GMAO_ElementReviewTasks_GMAO_ParadasConfiguracion_TaskId",
						column: x => x.TaskId,
						principalTable: "GMAO_ParadasConfiguracion",
						principalColumn: "id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElementReviewTasks_ElementId",
				table: "GMAO_ElementReviewTasks",
				column: "ElementId");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElementReviewTasks_TaskId",
				table: "GMAO_ElementReviewTasks",
				column: "TaskId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "GMAO_ElementReviewTasks");
		}
	}
}
