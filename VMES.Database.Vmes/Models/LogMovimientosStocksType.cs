namespace VMES.Database.Vmes.Models
{

	public enum LogMovimientosStocksType : int
	{
		Desconocido = 0,
		Entrada = 1,
		Salida = 2,
		Produccion = 3,
		Consumo = 4,
		Regularizacion = 5,
		CambioManual = 6,
		Ensacado = 7,
		CargaBigBag = 8,
		DescargaBigBag = 9,
		GeneradoDesdeUbicaciones = 10,
		AjusteSalida = 11,
		AlarmaMinimoSilo = 12,
		AjusteEntrada = 13,
		EntradaTeorica = 14,
		Traspaso = 15,
		StockEditado = 16,
		StockEliminado = 17,
		CambioLote = 18,
		DescargaIBC = 19,
		MezcladoUbicacion = 40,
		RegularizacionStockERPNoAcumulativo = 100,
		AddStockERP = 101,
		RemoveStockERP = 102,
	}

}
