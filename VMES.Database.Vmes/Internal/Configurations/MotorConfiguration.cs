using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VMES.Database.Vmes.Models;

namespace VMES.Database.Vmes.Internal.Configurations
{

	internal class MotorConfiguration : IEntityTypeConfiguration<Motor>
	{

		public void Configure(EntityTypeBuilder<Motor> entityTypeBuilder)
		{
			entityTypeBuilder.Property<decimal?>("AlertaConsumoAlto")
				.HasColumnType("decimal(18, 3)");
			entityTypeBuilder.Property<decimal?>("AlertaConsumoExcesivo")
				.HasColumnType("decimal(18, 3)");
			entityTypeBuilder.Property<float?>("IOCfgParInIntensidadNominal")
				.HasColumnType("real");
			entityTypeBuilder.Property<float?>("IOCfgParInCosFi")
				.HasColumnType("real");
			entityTypeBuilder.Property<int?>("IOCfgParInTension")
				.HasColumnType("int");
			entityTypeBuilder.Property<bool?>("IOCfgParInMonofasico")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgParInControlActivoVF")
				.HasColumnType("bit");
			entityTypeBuilder.Property<float?>("IOCfgParInConsignaAvisoIAlta")
				.HasColumnType("real");
			entityTypeBuilder.Property<float?>("IOCfgParInConsignaAlarmaI")
				.HasColumnType("real");
			entityTypeBuilder.Property<float?>("IOCfgParInIntensidadEnVacio")
				.HasColumnType("real");
			entityTypeBuilder.Property<float?>("IOCfgParInHysteresisMotorEnVacio")
				.HasColumnType("real");
			entityTypeBuilder.Property<int?>("IOCfgParInPorcentajeSobrecarga")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgParInPorcentajeCargaMaxima")
				.HasColumnType("int");
			entityTypeBuilder.Property<float?>("IOCfgParInHysteresisCarga")
				.HasColumnType("real");
			entityTypeBuilder.Property<float?>("IOCfgParInConsignaAvisoTempRod1")
				.HasColumnType("real");
			entityTypeBuilder.Property<float?>("IOCfgParInConsignaAvisoTempRod2")
				.HasColumnType("real");
			entityTypeBuilder.Property<float?>("IOCfgParInConsignaAlarmaTempRod1")
				.HasColumnType("real");
			entityTypeBuilder.Property<float?>("IOCfgParInConsignaAlarmaTempRod2")
				.HasColumnType("real");
			entityTypeBuilder.Property<float?>("IOCfgParInVelocidadErrorMax")
				.HasColumnType("real");
			entityTypeBuilder.Property<float?>("IOCfgParInVelocidadEscalado")
				.HasColumnType("real");
			entityTypeBuilder.Property<int?>("IOCfgParInSeccion0")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgParInSeccion1")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgParInSeccion2")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgParInSeccion3")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgParInSeccion3")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgParInSeccion4")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgParInSeccion5")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgParInSeccion6")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgParInSeccion7")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgParInSeccion8")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgParInSeccion9")
				.HasColumnType("int");
			entityTypeBuilder.Property<float?>("IOCfgParInParametroAux2")
				.HasColumnType("real");
			entityTypeBuilder.Property<float?>("IOCfgParInParametroAux3")
				.HasColumnType("real");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInDesactivarCM")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInDesactivarOtrasSeguridades")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInDesactivarAtasco")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInDesactivarPTC")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInDesactivarFalloVF")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInDesactivarFalloAE")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInDesactivarFalloAux")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInDesactivarAlDB1")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInDesactivarAlDB2")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInDesactivarAlDB3")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInDesactivarAlDB4")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInDesactivarDG")
				.HasColumnType("bit");
			entityTypeBuilder.Property<int?>("IOCfgSeguridadesInTipoDG")
				.HasColumnType("int");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInTempRod1Habilitada")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInTempRod2Habilitada")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInActivarEncadenadoAuto")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInActivarEncadenadoMan")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInActivarAlVelocidadFBack")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInActivarPreavisoArranque")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInPermisoRearranqManTrasFallo")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOCfgSeguridadesInAccionFalloSuministro")
				.HasColumnType("bit");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimEsperaCM")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimDelayOtrasSeguridades")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimDelayAtasco")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimDelayTermistorPTC")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimDelayFalloVF")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimDelayFalloAE")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimDelayFalloAux")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimDelayAlDB1")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimDelayAlDB2")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimDelayAlDB3")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimDelayAlDB4")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimMaximoOnDG")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimMaximoOffDG")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimDelayActivarCargaMax")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimDelayDesactivarCargaMax")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimDelayIntensidadElevada")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimDelayIntensidadMaxima")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimInhibirCargaArranque")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimRetardoStopAuto")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimOMSiguienteMotor")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOCfgTiemposInTimPreavisoArranque")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutHorasMarchaTotal")
				.HasColumnType("real");
			entityTypeBuilder.Property<int?>("IOMantenOutHorasMarchaParcial")
				.HasColumnType("real");
			entityTypeBuilder.Property<int?>("IOMantenOutHorasMarchaEnCarga")
				.HasColumnType("real");
			entityTypeBuilder.Property<int?>("IOMantenOutEnergiaEfectiva")
				.HasColumnType("real");
			entityTypeBuilder.Property<int?>("IOMantenOutEnergiaTotal")
				.HasColumnType("real");
			entityTypeBuilder.Property<int?>("IOMantenOutNumeroManiobras")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContadorTotAlarmas")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlFalloCM")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlTermico")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlDiferencial")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlParoEmerg")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlOtrasSeguridades")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlTermistorPTC")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlVF")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlAE")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlAux")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlDB1")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlDB2")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlDB3")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlDB4")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlDG")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlAtasco")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlIMax")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlIElevada")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlTempMaxRod1")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlTempElevRod1")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlTempMaxRod2")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlTempElevRod2")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlVelocidad")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlComunica")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlDeshabil")
				.HasColumnType("int");
			entityTypeBuilder.Property<bool?>("IOMantenInResetHorasTotal")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOMantenInResetHorasParcial")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOMantenInResetHorasEnCarga")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOMantenInResetEnergias")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOMantenInResetContadorManiobras")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOMantenInResetContadorAlarmas")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("LeerEnPLC")
				.HasColumnType("bit")
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.HasIndex("LeerEnPLC")
				.HasName("_dta_index_Motores_1");
			entityTypeBuilder.Property<bool?>("GrabarEnPLC")
				.HasColumnType("bit")
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property<bool?>("MedirKW")
				.HasColumnType("bit")
				.HasDefaultValueSql("((0))");
			entityTypeBuilder.Property<string>("NombreMes")
				.HasColumnType("nvarchar(50)");
			entityTypeBuilder.Property<bool?>("IsMaximetro")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("MaximetroGeneral")
				.HasColumnType("bit");
			entityTypeBuilder.Property<DateTime?>("InicioVentana")
				.HasColumnType("datetime");
			entityTypeBuilder.Property<decimal?>("ValorVentanaMaximetro")
				.HasColumnType("decimal(12, 3)");
			entityTypeBuilder.Property<int?>("MinsMaxVentana")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlLockOut")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlPuertaAbierta")
				.HasColumnType("int");
			entityTypeBuilder.Property<int?>("IOMantenOutContAlInversor")
				.HasColumnType("int");
			entityTypeBuilder.Property<bool?>("IOMantenInResetContadores")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOMantenInResetContadorEnergiaParciales")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOMantenInResetContadorEnergiaTotales")
				.HasColumnType("bit");
			entityTypeBuilder.Property<bool?>("IOMantenInResetMaxPotenciasIntensidad")
				.HasColumnType("bit");
			entityTypeBuilder.Property<decimal?>("IOMantenOutPotenciaActiva")
				.HasColumnType("decimal(18, 7)");
			entityTypeBuilder.Property<decimal?>("IOMantenOutPotenciaReactiva")
				.HasColumnType("decimal(18, 7)");
			entityTypeBuilder.Property<decimal?>("IOMantenOutPotenciaAparente")
				.HasColumnType("decimal(18, 7)");
			entityTypeBuilder.Property<decimal?>("IOMantenOutPotenciaActivaEfectiva")
				.HasColumnType("decimal(18, 7)");
			entityTypeBuilder.Property<decimal?>("IOMantenOutPotenciaReactivaEfectiva")
				.HasColumnType("decimal(18, 7)");
			entityTypeBuilder.Property<decimal?>("IOMantenOutPotenciaAparenteEfectiva")
				.HasColumnType("decimal(18, 7)");
			entityTypeBuilder.Property<decimal?>("IOMantenOutEnergiaEnCargaTotales")
				.HasColumnType("decimal(18, 7)");
			entityTypeBuilder.Property<decimal?>("IOMantenOutEnergiaEnVacioTotales")
				.HasColumnType("decimal(18, 7)");
			entityTypeBuilder.Property<decimal?>("IOMantenOutEnergiaEnCargaParciales")
				.HasColumnType("decimal(18, 7)");
			entityTypeBuilder.Property<decimal?>("IOMantenOutEnergiaEnVacioParciales")
				.HasColumnType("decimal(18, 7)");
			entityTypeBuilder.Property<decimal?>("IOMantenOutMemoriaMaxPotenciaActiva")
				.HasColumnType("decimal(18, 7)");
			entityTypeBuilder.Property<decimal?>("IOMantenOutMemoriaMaxPotenciaAparente")
				.HasColumnType("decimal(18, 7)");
			entityTypeBuilder.Property<decimal?>("IOMantenOutMemoriaMaxPotenciaReactiva")
				.HasColumnType("decimal(18, 7)");
			entityTypeBuilder.Property<decimal?>("IOMantenOutMemoriaMaxIntensidad")
				.HasColumnType("decimal(18, 7)");
			entityTypeBuilder.Property<decimal?>("EnergiaEnCargaAnterior")
				.HasColumnType("decimal(18, 7)");
			entityTypeBuilder.Property<decimal?>("EnergiaEnVacioAnterior")
				.HasColumnType("decimal(18, 7)");
			entityTypeBuilder.Property<decimal?>("EnergiaTotalAnterior")
				.HasColumnType("decimal(18, 7)");
			entityTypeBuilder.Property<decimal?>("EnergiaEfectivaAnterior")
				.HasColumnType("decimal(18, 7)");
			entityTypeBuilder.Property<int?>("IdOpc")
				.HasColumnType("int");
			entityTypeBuilder.HasOne(x => x.OpcConfig)
				.WithMany(x => x.Motores)
				.HasForeignKey(x => x.OpcConfigId)
				.OnDelete(DeleteBehavior.Restrict);
		}

	}

}
