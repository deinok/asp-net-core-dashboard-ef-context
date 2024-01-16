using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class EntradaLineaReferenciaErp : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "ReferenciaErp",
				table: "EntradasLineas",
				maxLength: 32,
				nullable: true);

			migrationBuilder.Sql(@"
				ALTER VIEW [SalidasViajesExtended]
				AS
					SELECT
						SV.id
						, SV.idSerie
						, Serie.Nombre AS SerieNombre
						, SV.Numero
						, SV.FechaCreacion
						, SV.idVehiculo
						, ISNULL(Vehic.Matricula, SV.MatriculaCamion) AS VehiculoMatricula
						, ISNULL(Vehic.Remolque, SV.MatriculaRemolque) AS VehiculoRemolque
						, Vehic.Referencia AS VehiculoReferencia
						, SV.idChofer
						, ISNULL(Chof.Nombre, SV.NombreConductor) AS ChoferNombre
						, Chof.CIF AS ChoferCIF
						, Chof.CodigoPostal AS ChoferCodigoPostal
						, Chof.Poblacion AS ChoferPoblacion
						, Prov2.Nombre AS ChoferProvinciaNombre
						, SV.idTarjeta
						, Tarj.Nombre AS TarjetaNombre
						, SV.idEmpresaTransporte
						, EmpTrans.Nombre AS EmpresaTransporteNombre
						, EmpTrans.CIF AS EmpresaTransporteCIF
						, EmpTrans.Referencia AS EmpresaTransporteReferencia
						, EmpTrans.Direccion AS EmpresaTransporteDireccion
						, EmpTrans.CodigoPostal AS EmpresaTransporteCodigoPostal
						, EmpTrans.Poblacion AS EmpresaTransportePoblacion
						, Prov.Nombre AS EmpresaTransporteProvincia
						, EmpTrans.Telefono AS EmpresaTransporteTlf
						, SV.FInicioViaje AS FechaSalidaFabrica
						, SV.Referencia
						, SV.FechaPrevista
						, SV.Estado
						, [dbo].GetTextoParametro('SalidasViajes', 'Estado', SV.Estado) AS EstadoStr
						, SV.Observaciones
					FROM
						[SalidasViajes] AS SV
					LEFT OUTER JOIN Series AS Serie ON Serie.Id = SV.idSerie 
					LEFT OUTER JOIN EmpresasTransporte AS EmpTrans ON EmpTrans.Id = SV.idEmpresaTransporte 
					LEFT OUTER JOIN Vehiculos AS Vehic ON Vehic.Id = SV.IdVehiculo
					LEFT OUTER JOIN Choferes AS Chof ON Chof.Id = SV.IdChofer
					LEFT OUTER JOIN Tarjetas AS Tarj ON Tarj.Id = SV.idTarjeta
					LEFT OUTER JOIN Provincias as Prov ON EmpTrans.Provincia = Prov.Id 
					LEFT OUTER JOIN Provincias as Prov2 ON Chof.Provincia = Prov.Id 
			");

			migrationBuilder.Sql(@"
				ALTER VIEW [SalidasLineasExtended]
				AS
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
								1, 2, '') AS OrigenesStr  -- con STUFF quitamos la coma y espacio iniciales
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
					LEFT OUTER JOIN Lotes AS lot ON lot.Id = res.Lote
			");

			migrationBuilder.Sql(@"
				ALTER VIEW [EntradasLineasExtended]
				AS
					SELECT 
						EL.id AS [id]
						, EL.idEntradas
						, EL.idProducto
						, P.Nombre AS ProductoNombre
						, EL.CantidadPedida
						, EL.FechaInicioRecepcion
						, EL.FechaFinRecepcion
						, EL.PesoBruto
						, EL.Cajon1
						, EL.Cajon2
						, EL.Cajon3
						, EL.Cajon4
						, EL.Cajon5
						, EL.Cajon6
						, EL.Cajon7
						, EL.Cajon8
						, EL.Cajon9
						, EL.Cajon10
						, EL.Estado
						, [dbo].GetTextoParametro('EntradasLineas', 'Estado', EL.Estado) AS EstadoTexto
						, EL.FueraCajon
						, EL.Lote
						, L.Nombre AS LoteNombre
						, L.Referencia AS LoteReferencia
						, L.Caducidad AS LoteCaducidad
						, L.Estado AS LoteEstado
						, [dbo].GetTextoParametro('Lotes', 'Estado', L.Estado) AS LoteEstadoTexto
						, EL.Tara
						, (EL.PesoBruto - EL.Tara) AS Neto
						, EL.PesoNetoManual
						, COALESCE(PesoNetoManual, (EL.PesoBruto - EL.Tara)) AS PesoNeto  -- El peso neto entrado manualmente tiene prevalencia
						, EL.Unidad
						, Uni.Nombre AS UnidadTexto
						, EL.Destino1
						, Ubi1.Nombre AS Destino1Nombre
						, Ubi1.Referencia AS Destino1Referencia
						, EL.Destino2
						, Ubi2.Nombre AS Destino2Nombre
						, Ubi2.Referencia AS Destino2Referencia
						, EL.Destino3
						, Ubi3.Nombre AS Destino3Nombre
						, Ubi3.Referencia AS Destino3Referencia
						, EL.Destino4
						, Ubi4.Nombre AS Destino4Nombre
						, Ubi4.Referencia AS Destino4Referencia
						, EL.Formato
						, Form.Nombre AS FormatoNombre
						, Form.Descripcion AS FormatoDescripcion
						, EL.Envase
						, Enva.Nombre AS EnvaseNombre
						, EL.Bultos
						, EL.Observaciones
						, EL.Precio
						, EL.PagarKgTeoricos
						, EL.CampoLibre1
						, EL.CampoLIbre2
						, EL.Fecha
						, EL.idModulo
						, Modu.Nombre AS ModuloNombre
						, porig.Nombre AS ProveedorOrigenNombre
						, EL.ReferenciaErp AS ReferenciaERP
					FROM 
						[EntradasLineas] AS EL
					LEFT OUTER JOIN Productos AS P ON P.Id = EL.idProducto
					LEFT OUTER JOIN Lotes AS L ON L.Id = EL.Lote
					LEFT OUTER JOIN Unidades AS Uni ON Uni.Id = EL.Unidad
					LEFT OUTER JOIN Ubicaciones AS Ubi1 ON Ubi1.Id = EL.Destino1 
					LEFT OUTER JOIN Ubicaciones AS Ubi2 ON Ubi2.Id = EL.Destino2 
					LEFT OUTER JOIN Ubicaciones AS Ubi3 ON Ubi3.Id = EL.Destino3 
					LEFT OUTER JOIN Ubicaciones AS Ubi4 ON Ubi4.Id = EL.Destino4
					LEFT OUTER JOIN Formatos AS Form ON Form.Id = EL.Formato 
					LEFT OUTER JOIN Envases AS Enva ON Enva.Id = EL.Envase
					LEFT OUTER JOIN Modulos AS Modu ON Modu.Id = EL.idModulo 
					LEFT OUTER JOIN ProveedoresOrigenes AS POrig ON POrig.Id = EL.idOrigenProv 
			");

			migrationBuilder.Sql(@"
				ALTER VIEW [TotalCantidadPorOrden] AS
				SELECT 
					[orden].[Id] AS [IdOrden],
					SUM([resultado].Cantidad) AS [Total]
				FROM
					[Resultados] AS [resultado]
				INNER JOIN 
					[Ordenes] AS [orden] ON [resultado].[Orden] = [orden].[Id]
				GROUP BY 
					[orden].[Id]
			");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "ReferenciaErp",
				table: "EntradasLineas");
		}
	}
}
