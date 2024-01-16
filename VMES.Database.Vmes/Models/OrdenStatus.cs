namespace VMES.Database.Vmes.Models
{

	public enum OrdenStatus : int
	{
		Pendiente = 0,
		EsperaColaIniciar = 1,
		ListoParaEnviar = 2,
		Enviada = 3,
		Procesando = 4,
		Finalizada = 5,
		Detenida = 6,
		Cancelada = 20,
		Eliminada = 100,
		PorConfirmar = 1000
	}

}
