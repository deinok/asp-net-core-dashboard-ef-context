namespace VMES.Database.Vmes.Models
{

	public enum SalidaViajeStatus : int
	{
		Pendiente = 0,
		EnTransito = 1,
		TransitoFinalizado = 5,
		EnViaje = 7,
		Finalizado = 10,
		Cancelado = 50,
		Devuelto = 100,
	}

}
