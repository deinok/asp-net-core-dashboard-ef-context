using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class AnalizadoresRedDROP : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "AnalizadoresRed");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "AnalizadoresRed",
				columns: table => new
				{
					id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Corriente0 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Corriente1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Corriente2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Corriente_Neutro = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Corriente_trifasica = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					CosFi_Trifasico = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
					Energia_Activa = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Energia_Activa_Generada = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Energia_Aparente = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Energia_Aparente_Generada = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Energia_Capacitiva_Generada = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Energia_Inductiva_Generada = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Energia_Reactiva_Capacitiva = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Energia_Reactiva_Inductiva = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					FactorPotencia0 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					FactorPotencia1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					FactorPotencia2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					FactorPotencia_Trifasico = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Frecuencia = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					IdOpc = table.Column<int>(type: "int", nullable: true),
					Max_Demanda = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Max_Demanda_L1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Max_Demanda_L2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Max_Demanda_L3 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					ModoMaximetro = table.Column<bool>(type: "bit", nullable: true),
					Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
					PosicionPLC = table.Column<int>(type: "int", nullable: true),
					PotenciaActiva0 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaActiva1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaActiva2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaActiva_Trifasica = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaAparente0 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaAparente1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaAparente2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaAparente_Trifasica = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaCapacitativa_Trifasica = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaInductiva_Trifasica = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaReactiva0 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaReactiva1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					PotenciaReactiva2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					RegistrarDatos = table.Column<bool>(type: "bit", nullable: true),
					SobreConsumo = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					THD_A0 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					THD_A1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					THD_A2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					THD_V0 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					THD_V1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					THD_V2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					Temperatura = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					TensionSimple0 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					TensionSimple1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					TensionSimple2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					VCompuestaL1_L2 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					VCompuestaL2_L3 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true),
					VCompuestaL3_L1 = table.Column<decimal>(type: "decimal(15, 5)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AnalizadoresRed", x => x.id);
				});
		}
	}
}
