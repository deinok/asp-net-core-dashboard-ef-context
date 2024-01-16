using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class VentasLineasMedicacionesExtendedFix : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
				ALTER VIEW [VentasLineasMedicacionesExtended] AS
				SELECT
					VLM.id,
					VLM.idVentaLinia,
					VLM.idEnvase,
					Enva.Nombre AS EnvaseNombre,
					VLM.idFormato,
					Form.Nombre AS FormatoNombre,
					Form.Descripcion AS FormatoDescripcion,
					VL.idMedicamento,
					Prod.Nombre AS MedicamentoNombre,
					Prod.Referencia AS MedicamentoReferencia,
					Prod.Nombre AS MedicamentoProductoNombre,
					VLM.idUnidad,
					Uni.Nombre AS UnidadTexto,
					VLM.Fecha,
					VLM.Cantidad,
					VLM.Bultos,
					VLM.Estado,
					[dbo].GetTextoParametro('VentasLiniasMedicaciones', 'Estado', VLM.Estado) AS EstadoStr,
					VLM.Precio,
					NULL AS IdMonedaPrecio,
					NULL AS MonedaPrecioStr,
					VLM.PrecioUnidad,
					NULL AS IdMonedaPrecioUnidad,
					NULL AS MonedaPrecioUnidadStr
				FROM
					[VentasLiniasMedicaciones] AS VLM
  				LEFT OUTER JOIN
					VentasLinias AS VL ON VL.Id = VLM.id
				LEFT OUTER JOIN
					Envases AS Enva ON Enva.Id = VLM.IdEnvase
				LEFT OUTER JOIN
					Formatos AS Form ON Form.Id = VLM.IdFormato
				LEFT OUTER JOIN
					Productos AS Prod ON Prod.Id = VLM.ProductoId
  				LEFT OUTER JOIN
					Unidades AS Uni ON Uni.Id = VLM.IdUnidad;
			");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
