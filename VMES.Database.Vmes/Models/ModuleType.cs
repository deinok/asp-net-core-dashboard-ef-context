namespace VMES.Database.Vmes.Models
{

	public enum ModuleType : int
	{
		CargaPiquera = 0,
		CargaLiquidos = 1,
		CargaCorrectores = 2,
		CargaMicroIngredientes = 3,
		CargaAlmacen = 4,
		CargaCamion = 5,
		Volteo = 6,
		Molienda = 7,
		Premezcla = 100,
		Produccion = 120,
		Granulacion = 140,
		Ensacado = 200,
		Molturacion = 300,
		Transito = 400,
		ArcoDesinfeccion = 450,
		Pesaje = 500,
		General = 1000,
	}

}
