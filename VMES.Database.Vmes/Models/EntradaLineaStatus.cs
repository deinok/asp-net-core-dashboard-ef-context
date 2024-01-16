namespace VMES.Database.Vmes.Models
{

	public enum EntradaLineaStatus : int
	{
		Pendiente = 0,
		EnTransito = 1,
		Eliminado = 2,
		Finalizado = 10,
		Cancelado = 50,
		Devuelto = 100
	}

}
