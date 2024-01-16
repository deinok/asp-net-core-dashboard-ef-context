using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class NetAlarmasFixIndexes : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP INDEX IF EXISTS [_dta_index_NetAlarmas_1] ON [NetAlarmas];");
			migrationBuilder.Sql("CREATE INDEX [_dta_index_NetAlarmas_1] ON [NetAlarmas]([Id]);");
			migrationBuilder.DropIndex(
				name: "_dta_index_NetAlarmas_1",
				table: "NetAlarmas");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [IndexNetAlarmas_1] ON [NetAlarmas];");
			migrationBuilder.Sql("CREATE INDEX [IndexNetAlarmas_1] ON [NetAlarmas]([Id]);");
			migrationBuilder.DropIndex(
				name: "IndexNetAlarmas_1",
				table: "NetAlarmas");

			migrationBuilder.Sql("DROP INDEX IF EXISTS [INetAlarmas1] ON [NetAlarmas];");
			migrationBuilder.Sql("CREATE INDEX [INetAlarmas1] ON [NetAlarmas]([Id]);");
			migrationBuilder.DropIndex(
				name: "INetAlarmas1",
				table: "NetAlarmas");

			migrationBuilder.RenameIndex(
				name: "_dta_index_NetAlarmas_2",
				table: "NetAlarmas",
				newName: "IX_NetAlarmas_Respondido");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.RenameIndex(
				name: "IX_NetAlarmas_Respondido",
				table: "NetAlarmas",
				newName: "_dta_index_NetAlarmas_2");

			migrationBuilder.CreateIndex(
				name: "_dta_index_NetAlarmas_1",
				table: "NetAlarmas",
				columns: new[] { "Id", "IdPlc", "idOrden", "idDosificacion", "idMedidor", "IdModulo", "TextoOpcional", "IdError", "FechaRecibido", "Respuesta", "RespPC", "RespUsuario", "RespFecha", "RespTxt", "txtError", "Opcion1", "Opcion2", "Opcion4", "Opcion3", "Tratada", "Visualizada", "idUbicacion", "Finalizada", "IdSeccion", "IdGrupo", "Ciclo_Num", "IdOrigen", "IdDestino", "IdOrigenPropuesto", "IdDestinoPropuesto", "Ciclo_NumPropuesto", "ConsultarScada", "InfoAdicScada", "ArgumentoPropuesto", "Enviada", "TextoAdicional", "FechaErrorMilisegundos", "RespIdOrigen", "RespIdDestino", "RespNumCiclos", "RespIdOrden", "RespArgumentos0", "RespArgumentos1", "RespArgumentos2", "RespArgumentos3", "RespVariables0", "RespVariables1", "RespVariables2", "RespVariables3", "RespVariables4", "RespIdProducto", "RespIdLote", "Interno", "TipoInterno", "PesadaNum", "Deshabilitada", "InfoAdicional1", "InfoAdicional2", "InfoAdicional3", "InfoAdicional4", "InfoAdicional5", "Respondido", "MostrarAUsuario", "RequiereRespuesta", "FechaError" });

			migrationBuilder.CreateIndex(
				name: "IndexNetAlarmas_1",
				table: "NetAlarmas",
				columns: new[] { "IdPlc", "idDosificacion", "idMedidor", "IdModulo", "TextoOpcional", "IdError", "FechaError", "FechaRecibido", "Respuesta", "RespPC", "RespUsuario", "RespFecha", "RespTxt", "txtError", "Opcion1", "Opcion2", "Opcion4", "Opcion3", "Tratada", "Visualizada", "idUbicacion", "Finalizada", "IdSeccion", "IdGrupo", "Ciclo_Num", "IdOrigen", "IdDestino", "IdOrigenPropuesto", "IdDestinoPropuesto", "Ciclo_NumPropuesto", "RequiereRespuesta", "ConsultarScada", "InfoAdicScada", "ArgumentoPropuesto", "Enviada", "TextoAdicional", "FechaErrorMilisegundos", "Respondido", "RespIdOrigen", "RespIdDestino", "RespNumCiclos", "RespIdOrden", "RespArgumentos0", "RespArgumentos1", "RespArgumentos2", "RespArgumentos3", "RespVariables0", "RespVariables1", "RespVariables2", "RespVariables3", "RespVariables4", "RespIdProducto", "RespIdLote", "Interno", "TipoInterno", "PesadaNum", "MostrarAUsuario", "Deshabilitada", "InfoAdicional1", "InfoAdicional2", "InfoAdicional3", "InfoAdicional4", "InfoAdicional5", "FechaErrorMES", "idOrden", "Id" });

			migrationBuilder.CreateIndex(
				name: "INetAlarmas1",
				table: "NetAlarmas",
				columns: new[] { "IdPlc", "idOrden", "idDosificacion", "idMedidor", "IdModulo", "TextoOpcional", "IdError", "FechaRecibido", "Respuesta", "RespPC", "RespUsuario", "RespFecha", "RespTxt", "txtError", "Opcion1", "Opcion2", "Opcion4", "Opcion3", "Tratada", "Visualizada", "idUbicacion", "Finalizada", "IdSeccion", "IdGrupo", "Ciclo_Num", "IdOrigen", "IdDestino", "IdOrigenPropuesto", "IdDestinoPropuesto", "Ciclo_NumPropuesto", "ConsultarScada", "InfoAdicScada", "ArgumentoPropuesto", "Enviada", "TextoAdicional", "FechaErrorMilisegundos", "RespIdOrigen", "RespIdDestino", "RespNumCiclos", "RespIdOrden", "RespArgumentos0", "RespArgumentos1", "RespArgumentos2", "RespArgumentos3", "RespVariables0", "RespVariables1", "RespVariables2", "RespVariables3", "RespVariables4", "RespIdProducto", "RespIdLote", "Interno", "TipoInterno", "PesadaNum", "Deshabilitada", "InfoAdicional1", "InfoAdicional2", "InfoAdicional3", "InfoAdicional4", "InfoAdicional5", "FechaErrorMES", "idMotor", "MostrarAUsuario", "RequiereRespuesta", "Respondido", "FechaError", "Id" });
		}
	}
}
