using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class EnvasesDeStock : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql($@"
				ALTER TABLE dbo.Stocks
				DROP COLUMN UdsEnvase;

				ALTER TABLE dbo.Desgloses
				DROP COLUMN UdsEnvase;
			");
			migrationBuilder.Sql($@"
				ALTER FUNCTION [dbo].[EnvasesDeStock] 
				(
					-- Add the parameters for the function here
					@idEnvase int,
					@Cantidad real
				)
				RETURNS decimal(18,5)
				AS
				BEGIN
					if @Cantidad <= 0 RETURN 0

					DECLARE @ResultVar decimal(18,5);
					DECLARE @ModoUds bit;
					DECLARE @EnvaseCapacidad real;

					SET @ModoUds = 0;
					SET @EnvaseCapacidad = 0;

					SELECT @EnvaseCapacidad = ISNULL(Capacidad, 0), @ModoUds = ModoUdsFormato 
					FROM Envases 
					WHERE Id=@idEnvase;

					if @ModoUds = 0 RETURN 0
					if @EnvaseCapacidad = 0 RETURN 0

					RETURN @Cantidad / @EnvaseCapacidad
				END
			");
			migrationBuilder.Sql($@"
				ALTER TABLE dbo.Stocks
				ADD [UdsEnvase]  AS ([dbo].[EnvasesDeStock]([envase],[Cantidad]));

				ALTER TABLE dbo.Desgloses
				ADD [UdsEnvase]  AS ([dbo].[EnvasesDeStock]([envase],[Cantidad]));
			");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
