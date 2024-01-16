namespace VMES.Database.Vmes.Models
{

	public enum TarjetaStatus : int
	{
		SinOrden = 0,
		EsperandoPeso1 = 5,
		EsperandoPreDesinfeccion = 7,
		EsperandoInicioOrden = 10,
		EsperandoFinalOrden = 15,
		EsperandoPeso2 = 20,
		EsperandoPosDesinfeccion = 22,
		DevolucionTarjeta = 25
	}

}
