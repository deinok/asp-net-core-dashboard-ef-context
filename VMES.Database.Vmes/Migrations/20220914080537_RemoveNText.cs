using Microsoft.EntityFrameworkCore.Migrations;

namespace VMES.Database.Vmes.Migrations
{
	public partial class RemoveNText : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "Observaciones",
				table: "Ventas",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Comentario",
				table: "Ventas",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Observaciones",
				table: "Salidas",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Comentario",
				table: "Salidas",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "CaminosDescripcion",
				table: "Modulos",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Observaciones",
				table: "GMAO_ElemIntervencionesTrabajos",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Descripcion",
				table: "GMAO_ElemIntervencionesTrabajos",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Observaciones",
				table: "GMAO_ElemIntervenciones",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Descripcion",
				table: "GMAO_ElemIntervenciones",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Observaciones",
				table: "GMAO_ElementosTipos",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Descripcion",
				table: "GMAO_ElementosTipos",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Descripcion",
				table: "GMAO_Archivos",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Contenido",
				table: "Etiquetas",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<byte[]>(
				name: "Logotipo",
				table: "Empresas",
				nullable: true,
				oldClrType: typeof(byte[]),
				oldType: "image",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Observaciones",
				table: "BufferERPVentas",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Comentario",
				table: "BufferERPVentas",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Observaciones",
				table: "BufferERPSalidas",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Comentario",
				table: "BufferERPSalidas",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Observaciones",
				table: "BufferERPPedidoVenta",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Comentario",
				table: "BufferERPPedidoVenta",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "ntext",
				oldNullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "Observaciones",
				table: "Ventas",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Comentario",
				table: "Ventas",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Observaciones",
				table: "Salidas",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Comentario",
				table: "Salidas",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "CaminosDescripcion",
				table: "Modulos",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Observaciones",
				table: "GMAO_ElemIntervencionesTrabajos",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Descripcion",
				table: "GMAO_ElemIntervencionesTrabajos",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Observaciones",
				table: "GMAO_ElemIntervenciones",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Descripcion",
				table: "GMAO_ElemIntervenciones",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Observaciones",
				table: "GMAO_ElementosTipos",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Descripcion",
				table: "GMAO_ElementosTipos",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Descripcion",
				table: "GMAO_Archivos",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Contenido",
				table: "Etiquetas",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<byte[]>(
				name: "Logotipo",
				table: "Empresas",
				type: "image",
				nullable: true,
				oldClrType: typeof(byte[]),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Observaciones",
				table: "BufferERPVentas",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Comentario",
				table: "BufferERPVentas",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Observaciones",
				table: "BufferERPSalidas",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Comentario",
				table: "BufferERPSalidas",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Observaciones",
				table: "BufferERPPedidoVenta",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Comentario",
				table: "BufferERPPedidoVenta",
				type: "ntext",
				nullable: true,
				oldClrType: typeof(string),
				oldNullable: true);
		}
	}
}
