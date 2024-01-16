using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class Trigger_OrdenPLC_ALTER : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
				ALTER TRIGGER [Trigger_OrdenPLC] ON [Ordenes]
				AFTER INSERT
				AS
				BEGIN
				DECLARE @ID_ORDEN int
				SET @ID_ORDEN = (SELECT [Id] FROM [INSERTED]);

				UPDATE [Ordenes] SET [OrdenEnvioPLC] = @ID_ORDEN WHERE [Id] IN (SELECT DISTINCT [Id] FROM [INSERTED]);

				END
			");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
