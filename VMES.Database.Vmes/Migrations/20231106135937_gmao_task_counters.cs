using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class gmao_task_counters : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<Guid>(
				name: "ReviewTaskId",
				table: "GMAO_ElemIntervencionesTrabajos",
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "Counter",
				table: "GMAO_ElementReviewTasks",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<DateTime>(
				name: "ResetDate",
				table: "GMAO_ElementReviewTasks",
				nullable: false,
				defaultValueSql: "GETDATE()");

			migrationBuilder.CreateIndex(
				name: "IX_GMAO_ElemIntervencionesTrabajos_ReviewTaskId",
				table: "GMAO_ElemIntervencionesTrabajos",
				column: "ReviewTaskId");

			migrationBuilder.AddForeignKey(
				name: "FK_GMAO_ElemIntervencionesTrabajos_GMAO_ElementReviewTasks_ReviewTaskId",
				table: "GMAO_ElemIntervencionesTrabajos",
				column: "ReviewTaskId",
				principalTable: "GMAO_ElementReviewTasks",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_GMAO_ElemIntervencionesTrabajos_GMAO_ElementReviewTasks_ReviewTaskId",
				table: "GMAO_ElemIntervencionesTrabajos");

			migrationBuilder.DropIndex(
				name: "IX_GMAO_ElemIntervencionesTrabajos_ReviewTaskId",
				table: "GMAO_ElemIntervencionesTrabajos");

			migrationBuilder.DropColumn(
				name: "ReviewTaskId",
				table: "GMAO_ElemIntervencionesTrabajos");

			migrationBuilder.DropColumn(
				name: "Counter",
				table: "GMAO_ElementReviewTasks");

			migrationBuilder.DropColumn(
				name: "ResetDate",
				table: "GMAO_ElementReviewTasks");
		}
	}
}
