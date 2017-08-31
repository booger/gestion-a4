using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Depositos",
                columns: table => new
                {
                    DepositoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoPostal = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DepositoCodigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefonos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depositos", x => x.DepositoID);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    GrupoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GrupoCodigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.GrupoID);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    MarcaID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MarcaCodigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.MarcaID);
                });

            migrationBuilder.CreateTable(
                name: "Lineas",
                columns: table => new
                {
                    LineaID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GrupoID = table.Column<long>(type: "bigint", nullable: false),
                    LineaCodigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lineas", x => x.LineaID);
                    table.ForeignKey(
                        name: "FK_Lineas_Grupos_GrupoID",
                        column: x => x.GrupoID,
                        principalTable: "Grupos",
                        principalColumn: "GrupoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    ArticuloID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    ArticuloCodigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CodBarraGenerado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CodBarraOriginal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ControlaStock = table.Column<bool>(type: "bit", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImpuestosInternos = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    LineaID = table.Column<long>(type: "bigint", nullable: false),
                    MarcaID = table.Column<long>(type: "bigint", nullable: false),
                    PuntoDePedido = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    StockMaximo = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    StockMinimo = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TamanoLotePedido = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.ArticuloID);
                    table.ForeignKey(
                        name: "FK_Articulos_Lineas_LineaID",
                        column: x => x.LineaID,
                        principalTable: "Lineas",
                        principalColumn: "LineaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articulos_Marcas_MarcaID",
                        column: x => x.MarcaID,
                        principalTable: "Marcas",
                        principalColumn: "MarcaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    ArticuloID = table.Column<long>(type: "bigint", nullable: false),
                    DepositoID = table.Column<long>(type: "bigint", nullable: false),
                    Comprometido = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Existencia = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PedidoProv = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => new { x.ArticuloID, x.DepositoID });
                    table.ForeignKey(
                        name: "FK_Stocks_Articulos_ArticuloID",
                        column: x => x.ArticuloID,
                        principalTable: "Articulos",
                        principalColumn: "ArticuloID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Depositos_DepositoID",
                        column: x => x.DepositoID,
                        principalTable: "Depositos",
                        principalColumn: "DepositoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_LineaID",
                table: "Articulos",
                column: "LineaID");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_MarcaID",
                table: "Articulos",
                column: "MarcaID");

            migrationBuilder.CreateIndex(
                name: "IX_Lineas_GrupoID",
                table: "Lineas",
                column: "GrupoID");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_DepositoID",
                table: "Stocks",
                column: "DepositoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Depositos");

            migrationBuilder.DropTable(
                name: "Lineas");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Grupos");
        }
    }
}
