using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class trg_Ordenes_OrdenesTransicionEstadosHistory_FU : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
-- trigger que diferencia entre los inserts, los updates y los deletes
-- https://stackoverflow.com/questions/11890868/how-to-store-historical-records-in-a-history-table-in-sql-server
-- ¿POR QUÉ USAR EXIST EN LUGAR DE COUNT(*) > 0
-- http://sqlblog.com/blogs/andrew_kelly/archive/2007/12/15/exists-vs-count-the-battle-never-ends.aspx
-- NOTA: Un trigger FOR y un trigger AFTER son lo mismo en SQL Server.
CREATE TRIGGER [dbo].[trg_Ordenes_OrdenesTransicionEstadosHistory_FU]
	ON [dbo].[Ordenes]
   FOR UPDATE
AS
BEGIN
	if @@ROWCOUNT = 0
		return

	SET NOCOUNT ON

	--Iván: El insert no hace falta en ordenes...
	--ya que se hace desde erp y se pone ya su estado.. es en el update solo .. cuando cambia hay que revisar...
	
	-- JUANJO 12/11/2020 En el insert esto se va a ejecutar igualmente porque la función UPDATE() detecta indistintamente tanto INSERT como UPDATE,
	-- por lo que vamos a filtrarlo haciendo un join con la deleted y sólo actuando en caso de cambio de valor en el campo Estado
	-- Igualmente, como finalmente hemos definido el trigger sólo for Update, con esto sólo conseguimos una capa de seguridad ""extra/supérflua"",
	-- más bien una simple optimización del código
	if UPDATE(estado)
	begin
		DECLARE @idOrden int;
		DECLARE @estadoNuevoOrden int;
		DECLARE @estadoViejoOrden int;
		DECLARE my_Cursor CURSOR FAST_FORWARD FOR SELECT i.Id, i.Estado, d.Estado
													FROM Inserted AS i 
													inner join Deleted as d on d.Id = i.Id
													where d.Estado <> i.Estado;
		-- haciendo el join con la deleted sólo procesamos los registros que han tenido un update en el campo Estado y que efectivamente éste ha cambiado el valor del mismo
		
		OPEN my_Cursor 
		FETCH NEXT FROM my_Cursor into @idOrden, @estadoNuevoOrden, @estadoViejoOrden
		
		WHILE @@FETCH_STATUS = 0 
		BEGIN 
			exec dbo.RevisarEstadoOrdenParaERP @idOrden;
			FETCH NEXT FROM my_Cursor into @idOrden, @estadoNuevoOrden, @estadoViejoOrden
		END

		CLOSE my_Cursor
		DEALLOCATE my_Cursor

	END
END

			");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
