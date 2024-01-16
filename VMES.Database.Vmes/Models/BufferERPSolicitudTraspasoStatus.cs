namespace VMES.Database.Vmes.Models
{

	public enum BufferERPSolicitudTraspasoStatus : int
	{
		PorEnviar = 0,
		EsperandoRespuesta = 1,
		RespuestaRecibida = 2,
		Finalizado = 3,
		ConError = 10,
	}

}
