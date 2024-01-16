namespace VMES.Database.Vmes.Models
{

	public enum NetAlarmasResponseType : int
	{
		SinRespuesta = 0,
		OmitirYContinuar = 1,
		CompletarConOrigen = 2,
		CompletarConDestino = 3,
		SustituirPorOrigen = 4,
		SustituirPorDestino = 5,
		Abortar = 6,
		Finalizar = 7,
		Reintentar = 8,
		Aceptar = 9,
		NoOkKo = 10,
		SustituirPorLote = 11,
		CompletarConLote = 12,
		AccionAuxiliar1 = 13,
		AccionAuxiliar2 = 14,
		AccionAuxiliar3 = 15,
		VaciaryContinuar = 16,
		CompletarPorOrigenConParametros = 17,
		SustituirPorOrigenConParametros = 18,
		CambiarEstadoOrdenPendiente = 1001,
		ForzarOrdenLimpieza = 1002,
	}

}
