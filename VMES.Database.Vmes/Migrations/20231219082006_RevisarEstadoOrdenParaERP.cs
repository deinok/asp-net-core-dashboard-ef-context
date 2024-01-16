using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class RevisarEstadoOrdenParaERP : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
-- =============================================
-- Author:		Iván Noya
-- Create date: 14-10-2020
-- Modification: Juanjo Álvarez 12-11-2020
-- Description:	Controla el estado y actualiza la tabla de estados de orden. Se le debe llamar desde cualquier trigger de tablas que puedan cambiar su estado.
-- =============================================
CREATE PROCEDURE [dbo].[RevisarEstadoOrdenParaERP]
	-- Add the parameters for the stored procedure here
	@idOrden int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	-- Enum Estados Orden en VMES
	declare @enumEstadoOrdenVMESPendiente int = 0;
	declare @enumEstadoOrdenVMESEsperaColaIniciar int = 1;
	declare @enumEstadoOrdenVMESListoParaEnviar int = 2;
	declare @enumEstadoOrdenVMESEnviada int = 3;
	declare @enumEstadoOrdenVMESProcesando int = 4;
	declare @enumEstadoOrdenVMESFinalizada int = 5;
	declare @enumEstadoOrdenVMESDetenida int = 6;
	declare @enumEstadoOrdenVMESCancelada int = 20;
	declare @enumEstadoOrdenVMESEliminada int = 100;
	declare @enumEstadoOrdenVMESPorConfirmar int = 1000;

	-- Enum Estados Orden en ERP (MT_OrderStatus)
	declare @enumEstadoOrdenERPNuevaEnERP int = 0; -- Updated
	declare @enumEstadoOrdenERPNueva int = 1; -- New
	declare @enumEstadoOrdenERPEjecutando int = 3; -- Running
	declare @enumEstadoOrdenERPFinalizada int = 4; -- Complete
	declare @enumEstadoOrdenERPPausada int = 5; -- Pause
	declare @enumEstadoOrdenERPEnError int = 6; -- Error
	declare @enumEstadoOrdenERPCancelada int = 7; -- Cancelled
	declare @enumEstadoOrdenERPPesoCompletado int = 8;
	declare @enumEstadoOrdenERPActualizada int = 9;
	declare @enumEstadoOrdenERPIndefinido int = 600;


	declare @idEstadoAnteriorOrden int = 0;
	declare @estadoAnteriorOrden int;
	declare @estadoActual int;

	declare @fechaInicio as date = getdate();

	declare @estadoActualOrdenVMES int;

	SET @idEstadoAnteriorOrden = (select MAX(IdAuto) from OrdenesTransicionEstadosHistory where IdOrden = @idOrden);
	SET @estadoAnteriorOrden = (select Estado from OrdenesTransicionEstadosHistory where IdAuto = @idEstadoAnteriorOrden); 

	SET @estadoActualOrdenVMES = (select estado from Ordenes where Id = @idOrden);

	
	/* Calculamos el estado actual y comparamos con el anterior... */
	--Estos estados es que no ha iniciado aún... podemos saltarlos directamente.
	if @estadoActualOrdenVMES = @enumEstadoOrdenVMESPendiente 
		or @estadoActualOrdenVMES = @enumEstadoOrdenVMESEsperaColaIniciar 
		or @estadoActualOrdenVMES = @enumEstadoOrdenVMESListoParaEnviar 
		or @estadoActualOrdenVMES = @enumEstadoOrdenVMESEnviada
	begin 
		return;
	end


	
	if (@estadoActualOrdenVMES = @enumEstadoOrdenVMESFinalizada 
	 or @estadoActualOrdenVMES = @enumEstadoOrdenVMESCancelada)
		begin
			SET @fechaInicio = (select Fin from Ordenes where Id = @idOrden);
			if @estadoActualOrdenVMES = @enumEstadoOrdenVMESFinalizada
				begin
					SET @estadoActual = @enumEstadoOrdenERPFinalizada;
				end
			else if @estadoActualOrdenVMES = @enumEstadoOrdenVMESCancelada
				begin
					SET @estadoActual = @enumEstadoOrdenERPCancelada;
				end
		end
	else --No está finalizada ni cancelada
		begin
			if @estadoActualOrdenVMES = @enumEstadoOrdenVMESProcesando
			begin
				SET @estadoActual = @enumEstadoOrdenERPEjecutando;
				if @estadoAnteriorOrden is null 
				begin
					set @fechaInicio = GETDATE();	
				end
		
				--Si la orden está en marcha, pero el módulo está pausado... la orden está en pausa...
				declare @estadoModulo int 
				SET @estadoModulo = (select m.Estado from Ordenes as o 
												inner join Modulos as m ON m.Id = o.Modulo 
									 where o.Id = @idOrden);

				if @estadoModulo = 5 --pausado
				begin
					SET @estadoActual = @enumEstadoOrdenERPPausada;
				end
			end

			--Miremos si tiene alarmas activas que requieren respuesta y sin responder... (y que se muestren a usuario..)
			--Si está cancelada o finalizada, no hace falta mirar las alarmas...
			declare @fechaAlarmaActiva date;
			SET @fechaAlarmaActiva = (select min(a.FechaError)  
										from NetAlarmas as a
										left outer join NetAlarmasTipos as t on t.IdAlarmaPLC = a.IdError 
										where a.idOrden = @idOrden 
										  and a.RequiereRespuesta = 1 
										  and a.Respondido = 0 
										  and t.MostrarUsuario = 1);

			if @fechaAlarmaActiva is not null
			begin
				--Tenemos alarmas activas que requieren respuesta...
				SET @estadoActual = @enumEstadoOrdenERPEnError;
				SET @fechaInicio = @fechaAlarmaActiva;
			end
		

		end

	--Calculado el estado, pasamos a grabar los datos.
	--Comparamos estado anterior y nuevo,
	if @estadoAnteriorOrden = @estadoActual 
		begin
			--Actualizamos el registro y punto...
			update OrdenesTransicionEstadosHistory set ContadorActualizaciones = ContadorActualizaciones + 1 where IdAuto = @idEstadoAnteriorOrden;
		end
	else --Estados distintos
		begin
			--Si había estado anterior, actualizamos su fecha de finalización.
			if @idEstadoAnteriorOrden > 0
				begin
					update OrdenesTransicionEstadosHistory set FinValidez = GETDATE(), ContadorActualizaciones = ContadorActualizaciones + 1 where IdAuto = @idEstadoAnteriorOrden;
				end

			--Generamos el nuevo registro
			insert into OrdenesTransicionEstadosHistory (InicioValidez , ContadorActualizaciones, IdOrden, EstadoAnterior, Estado, ExportadoERP)
				values (GETDATE(), 0, @idOrden, @estadoAnteriorOrden, @estadoActual, 0);
		end
END
			");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
