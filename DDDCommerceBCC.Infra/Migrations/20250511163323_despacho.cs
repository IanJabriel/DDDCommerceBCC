using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDDCommerceBCC.Infra.Migrations
{
    /// <inheritdoc />
    public partial class despacho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Despachos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transportadora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDespacho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoRastreio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despachos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Despachos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despachos_PedidoId",
                table: "Despachos",
                column: "PedidoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despachos");
        }
    }
}
