using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EngajaBlack1.Migrations
{
    public partial class banco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CodigoCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CreditCard = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.CodigoCliente);
                });

            migrationBuilder.CreateTable(
                name: "Empreendedor",
                columns: table => new
                {
                    CodigoEmpreendedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeLoja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Ramo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comunidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraAbertura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraFechamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empreendedor", x => x.CodigoEmpreendedor);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    CodigoFornecedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ramo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.CodigoFornecedor);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    NumPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrevisaoEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorPedido = table.Column<float>(type: "real", nullable: false),
                    CodigoCliente = table.Column<int>(type: "int", nullable: false),
                    CodigoEmpreendedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.NumPedido);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_CodigoCliente",
                        column: x => x.CodigoCliente,
                        principalTable: "Cliente",
                        principalColumn: "CodigoCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Empreendedor_CodigoEmpreendedor",
                        column: x => x.CodigoEmpreendedor,
                        principalTable: "Empreendedor",
                        principalColumn: "CodigoEmpreendedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    CodigoProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ValorProduto = table.Column<float>(type: "real", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumPedido = table.Column<int>(type: "int", nullable: false),
                    CodigoEmpreendedor = table.Column<int>(type: "int", nullable: false),
                    EmprendedorCodigoEmpreendedor = table.Column<int>(type: "int", nullable: true),
                    CodigoFornecedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.CodigoProduto);
                    table.ForeignKey(
                        name: "FK_Produto_Empreendedor_EmprendedorCodigoEmpreendedor",
                        column: x => x.EmprendedorCodigoEmpreendedor,
                        principalTable: "Empreendedor",
                        principalColumn: "CodigoEmpreendedor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produto_Fornecedor_CodigoFornecedor",
                        column: x => x.CodigoFornecedor,
                        principalTable: "Fornecedor",
                        principalColumn: "CodigoFornecedor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produto_Pedido_NumPedido",
                        column: x => x.NumPedido,
                        principalTable: "Pedido",
                        principalColumn: "NumPedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CodigoCliente",
                table: "Pedido",
                column: "CodigoCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CodigoEmpreendedor",
                table: "Pedido",
                column: "CodigoEmpreendedor");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CodigoFornecedor",
                table: "Produto",
                column: "CodigoFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_EmprendedorCodigoEmpreendedor",
                table: "Produto",
                column: "EmprendedorCodigoEmpreendedor");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_NumPedido",
                table: "Produto",
                column: "NumPedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empreendedor");
        }
    }
}
