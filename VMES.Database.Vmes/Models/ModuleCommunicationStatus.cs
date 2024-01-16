namespace VMES.Database.Vmes.Models
{

	public enum ModuleCommunicationStatus : int
	{
		Desconocido = 0,
		IniciandoComunicaciones = 1,
		Parado = 2,
		EnMarcha = 3,
		EsperaAlarma = 4,
		Pausado = 5,
		Pausando = 6,
		SinComunicacionesBD = 7,
		ModoDebug = 8
	}

}
