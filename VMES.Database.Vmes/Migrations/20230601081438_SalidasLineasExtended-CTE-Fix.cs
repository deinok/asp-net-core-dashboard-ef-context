using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class SalidasLineasExtendedCTEFix : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
				ALTER VIEW [SalidasLineasExtended] AS WITH CTE AS(
					SELECT
						SL.id
						, SL.idSalidas
						, SL.idviajes
						, SL.idorden
						, SL.idAlbaran
						, Alb.Serie AS AlbaranSerie
						, SerieAlbaran.Nombre AS AlbaranSerieNombre
						, Alb.Numero AS AlbaranNumero
						, Alb.Fecha AS AlbaranFecha
						, SL.idProducto
						, P.Nombre AS ProductoNombre
						, SL.idFormato
						, Form.Nombre AS FormatoNombre
						, Form.Descripcion AS FormatoDescripcion
						, SL.idEnvase
						, Enva.Nombre AS EnvaseNombre
						, SL.idUnidad
						, Uni.Nombre AS UnidadTexto
						, SL.idDomicilio
						, Domi.Cliente AS DomicilioIdCliente
						, Cli.Nombre AS DomicilioClienteNombre
						, Domi.Nombre AS DomicilioNombre
						, Domi.Referencia AS DomicilioReferencia
						, Domi.Direccion AS DomicilioDireccion
						, Domi.Poblacion AS DomicilioPoblacion
						, Domi.Telefono AS DomicilioTelefono
						, Domi.CodigoPostal DomicilioCodigoPostal
						, Domi.Provincia AS DomicilioProvincia
						, Provincias.Nombre AS DomicilioProvinciaNombre
						, Domi.Pais AS DomicilioPais
						, Pais.Nombre AS DomicilioPaisNombre
						, Domi.Inhabilitado
						, [dbo].GetTextoParametro('Domicilio', 'Inhabilitado', Domi.Inhabilitado) AS DomicilioInhabilitadoStr
						, Domi.Descripcion AS DomicilioDescripcion
						, Domi.Simogan AS DomicilioSIMOGAN
						, Domi.REGA AS DomicilioREGA
						, Domi.MarcaOficial AS DomicilioMarcaOficial
						, Es.Nombre AS DomicilioEspecie
						, SL.TipoOrigen
						, SL.Origen1
						, UbiOrig1.Nombre AS Origen1Nombre
						, SL.Origen2
						, UbiOrig2.Nombre AS Origen2Nombre
						, SL.Origen3
						, UbiOrig3.Nombre AS Origen3Nombre
						, SL.Origen4
						, UbiOrig4.Nombre AS Origen4Nombre
						, STUFF(
							ISNULL(', ' + UbiOrig1.Nombre, '') +
							ISNULL(', ' + UbiOrig2.Nombre, '') +
							ISNULL(', ' + UbiOrig3.Nombre, '') +
							ISNULL(', ' + UbiOrig4.Nombre, ''),
							1, 2, '') AS OrigenesStr
						, SL.FueraCajon
						, SL.Cajon1
						, SL.Cajon2
						, SL.Cajon3
						, SL.Cajon4
						, SL.Cajon5
						, SL.Cajon6
						, SL.Cajon7
						, SL.Cajon8
						, SL.Cajon9
						, SL.Cajon10
						, STUFF(
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Fueracajon', SL.FueraCajon), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon1', SL.Cajon1), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon2', SL.Cajon2), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon3', SL.Cajon3), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon4', SL.Cajon4), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon5', SL.Cajon5), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon6', SL.Cajon6), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon7', SL.Cajon7), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon8', SL.Cajon8), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon9', SL.Cajon9), '') +
							ISNULL(', ' + dbo.GetTextoParametro('SalidasLineas', 'Cajon10', SL.Cajon10), ''),
							1, 2, '') AS CajonesStr  -- con STUFF quitamos la coma y espacio iniciales
						, SL.FechaFinCarga
						, SL.FechaInicioCarga
						, SL.Bultos
						, SL.Bruto
						, SL.Tara
						, (SL.Bruto - SL.Tara) AS NetoCalculado
						, SL.PesoNetoManual
						, COALESCE(PesoNetoManual, (SL.Bruto - SL.Tara)) AS NetoEfectivo  -- El peso neto entrado manualmente tiene prevalencia sobre el calculado
						, SL.Estado
						, [dbo].GetTextoParametro('SalidasLineas', 'Estado', SL.Estado) AS EstadoStr
						, SL.PrecioUnidad
						, NULL AS IdMonedaPrecioUnidad
						, NULL AS PrecioUnidadMonedaNombre
						, SL.Cantidad
						, SL.Fecha
						, SL.Precio
						, NULL AS IdMonedaPrecio
						, NULL AS PrecioMonedaNombre
						, SL.PrecioTransporte
						, NULL AS IdMonedaPrecioTransporte
						, NULL AS PrecioTransporteMonedaNombre
						, SL.Observaciones
						, SL.idBasculaPesajeBruto
						, BascBruto.Nombre AS BasculaPesajeBrutoStr
						, SL.idBasculaPesajeNeto
						, BascNeto.Nombre AS BasculaPesajeNetoStr
						, SL.CampoLibre1
						, SL.CampoLibre2
						, SL.idPuntoDescarga
						, PD.Nombre AS PuntoDescargaStr
						, PD.Descripcion AS PuntoDescargaDescripcion
						,Ord.Id AS OrdenId
						,Ord.Nombre AS OrdenNombre
						, lot.Nombre AS PrimerLoteNombre
						, Rec.NumReceta AS NumeroReceta
						,STUFF((
								SELECT DISTINCT ' - ' + lot.Nombre
								FROM Resultados as Res
								LEFT OUTER JOIN Lotes AS Lot ON Lot.Id = Res.Lote AND Lot.Producto = Res.Producto
								WHERE Res.Orden = Ord.Id
								FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 3, '') AS TodosLotesNombre
							,STUFF((
								SELECT DISTINCT ' - ' + pd.Nombre
								FROM SalidasLiniasPuntosDescarga AS slpd
								LEFT OUTER JOIN PuntosDescarga AS pd ON slpd.idPuntoDescarga = pd.id
								WHERE idLineaSalida = SL.id
								FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 3, '') AS TodosPuntosDescarga
			
								,ISNULL(ROW_NUMBER() OVER(PARTITION BY SL.Id ORDER BY SL.Id ASC), -1) AS RowID
					FROM
						[SalidasLinias] AS SL
					LEFT OUTER JOIN SalidasAlbaranes AS Alb ON Alb.Id = SL.idAlbaran
					LEFT OUTER JOIN Series AS SerieAlbaran ON Alb.Serie = SerieAlbaran.Id
					LEFT OUTER JOIN Productos AS P ON P.Id = SL.idProducto
					LEFT OUTER JOIN Formatos AS Form ON Form.Id = SL.idFormato
					LEFT OUTER JOIN Envases AS Enva ON Enva.Id = SL.idEnvase
					LEFT OUTER JOIN Unidades AS Uni ON Uni.Id = SL.idUnidad
					LEFT OUTER JOIN Domicilios AS Domi ON Domi.Id = SL.idDomicilio
					LEFT OUTER JOIN Clientes AS Cli ON Cli.Id = Domi.Cliente
					LEFT OUTER JOIN Paises AS Pais ON Pais.Id = Domi.Pais
					LEFT OUTER JOIN Provincias AS Provincias ON Provincias.Id = Domi.Provincia
					LEFT OUTER JOIN Especies AS Es ON Domi.Especie = Es.Id
					LEFT OUTER JOIN Ubicaciones AS UbiOrig1 ON UbiOrig1.Id = SL.Origen1
					LEFT OUTER JOIN Ubicaciones AS UbiOrig2 ON UbiOrig2.Id = SL.Origen2
					LEFT OUTER JOIN Ubicaciones AS UbiOrig3 ON UbiOrig3.Id = SL.Origen3
					LEFT OUTER JOIN Ubicaciones AS UbiOrig4 ON UbiOrig4.Id = SL.Origen4
					LEFT OUTER JOIN Basculas AS BascBruto ON BascBruto.Id = SL.idBasculaPesajeBruto
					LEFT OUTER JOIN Basculas AS BascNeto ON BascNeto.Id = SL.idBasculaPesajeNeto
					LEFT OUTER JOIN PuntosDescarga AS PD ON PD.id = SL.idPuntoDescarga
					LEFT OUTER JOIN Ordenes AS Ord ON Ord.LineaSalida = SL.id
					LEFT OUTER JOIN Resultados AS Res ON res.Orden = Ord.id
					LEFT OUTER JOIN Recetas AS Rec ON Rec.idSalidaLinea = SL.id
					LEFT OUTER JOIN Lotes AS lot ON lot.Id = res.Lote)
				SELECT * FROM CTE WHERE RowID = 1;
			");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
