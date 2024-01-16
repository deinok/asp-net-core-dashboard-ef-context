using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class SalidasClienteAgrupado : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
				CREATE VIEW [SalidasClienteAgrupado] AS
				SELECT	  
					Clientes.Id AS ClienteId, 
					Clientes.Referencia AS ClienteRef, 
					Clientes.Nombre AS ClienteNombre , 
					Productos.Id AS ProductoId, 
					Productos.Nombre AS ProductoNombre, 
					SUM(Res.Servida) AS Servida, 
					Salidas.FFin, 
					SUM(SalidasLinias.Cantidad) AS Teorico
				FROM 
					[Clientes]
				RIGHT JOIN 
					Salidas ON Salidas.idCliente = Clientes.Id
				RIGHT JOIN 
					SalidasLinias ON Salidas.Id = SalidasLinias.idSalidas 
				LEFT JOIN 
					Productos ON SalidasLinias.idProducto = Productos.Id
				RIGHT JOIN 
					(
						SELECT  
							Ordenes.Salida, 
							Ordenes.LineaSalida, 
							SUM(Resultados.Cantidad) AS Servida
						FROM
							Ordenes 
						RIGHT JOIN 
							Resultados ON Ordenes.Id = Resultados.Orden
						WHERE 
							Ordenes.Estado = 5 
						GROUP BY 
							Ordenes.Salida, 
							Ordenes.LineaSalida
					) AS Res ON Res.Salida = SalidasLinias.idSalidas AND Res.LineaSalida = SalidasLinias.Id
				WHERE 
					Salidas.Estado = 2
				GROUP BY 
					Clientes.Id, 
					Clientes.Referencia, 
					Clientes.Nombre, 
					Productos.Id, 
					Productos.Nombre, 
					Salidas.FFin;
			");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
