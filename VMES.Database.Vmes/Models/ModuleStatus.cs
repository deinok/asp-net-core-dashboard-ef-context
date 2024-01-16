namespace VMES.Database.Vmes.Models
{

	public enum ModuleStatus : int
	{
		Parado = 0,
		Funcionando = 1,
		Deteniendo = 2,
		FaseLimpieza = 3,
		FaseDesconexion = 4,
		Pausado = 5,
		ProduciendoConAlarmasLeves = 10,
		ProduciendoConAlarmasGraves = 11,
		AveriaElectrica = 12,
		AveríaMecánica = 13,
		AveríaIndeterminada = 14,
		EnMantenimiento = 20,
	}

}
