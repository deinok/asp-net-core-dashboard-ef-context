namespace VMES.Database.Vmes.Models
{

	public enum SalidaLineaStatus : int
	{
		Pendiente = 0,
		EnTransito = 1,
		Finalizado = 10,
		Cancelado = 50,
		Devuelto = 100,
	}

}
