namespace VMES.Database.Vmes.Models
{

	public enum NetAlarmasInternalType : int
	{
		Correcto = 0,
		ServidorOPCCaido = 1,
		BaseDatosCaido = 2,
		TimeOutEnvioRespuestaAlarma = 201,
		TimeOutEnvioOrden = 202,
		HashEnvioOrden = 203,
		ErrorRecibidoDePLC = 204,
		HashRecepcion = 205,
		IncompatibilidadFlexible = 401,
		IncompatibilidadEstricta = 402,
		Transito = 600,
		MotoresConsumoAlto = 800,
		MotoresConsumoExcesivo = 810,
		MotoresExcesoMaximetro = 820,
		SobreConsumoMaximetro = 850,
		SinComunicacionesBasculaTransito = 900,
		AlarmaGenerada = 999,
		ProductoDistintoDestino = 2010,
		LimpiarCircuito6000 = 2020,
		ComprobacionOrigenVacio = 2050,
		ConsumosBuffer = 2500,
	}

}
