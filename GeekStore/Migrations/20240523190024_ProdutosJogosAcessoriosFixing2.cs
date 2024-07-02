using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekStore.Migrations
{
    /// <inheritdoc />
    public partial class ProdutosJogosAcessoriosFixing2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acessorios_Jogos_Id",
                table: "Acessorios");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Produtos_Id",
                table: "Jogos");

            migrationBuilder.AddColumn<string>(
                name: "CodBarras",
                table: "Jogos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fabricante",
                table: "Jogos",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeDoProduto",
                table: "Jogos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoCategoria",
                table: "Jogos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Jogos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Valor",
                table: "Jogos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "CodBarras",
                table: "Acessorios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fabricante",
                table: "Acessorios",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeDoProduto",
                table: "Acessorios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Plataforma",
                table: "Acessorios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PrazoDeGarantia",
                table: "Acessorios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoCategoria",
                table: "Acessorios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Acessorios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Valor",
                table: "Acessorios",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodBarras",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "Fabricante",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "NomeDoProduto",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "ProdutoCategoria",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "CodBarras",
                table: "Acessorios");

            migrationBuilder.DropColumn(
                name: "Fabricante",
                table: "Acessorios");

            migrationBuilder.DropColumn(
                name: "NomeDoProduto",
                table: "Acessorios");

            migrationBuilder.DropColumn(
                name: "Plataforma",
                table: "Acessorios");

            migrationBuilder.DropColumn(
                name: "PrazoDeGarantia",
                table: "Acessorios");

            migrationBuilder.DropColumn(
                name: "ProdutoCategoria",
                table: "Acessorios");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Acessorios");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Acessorios");

            migrationBuilder.AddForeignKey(
                name: "FK_Acessorios_Jogos_Id",
                table: "Acessorios",
                column: "Id",
                principalTable: "Jogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Produtos_Id",
                table: "Jogos",
                column: "Id",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
