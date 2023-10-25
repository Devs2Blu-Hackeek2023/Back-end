using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back_End.Migrations
{
    /// <inheritdoc />
    public partial class ola : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Veiculos_ProprietarioId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Proprietarios_UsuarioId",
                table: "Proprietarios");

            migrationBuilder.DropIndex(
                name: "IX_Emissoes_RuaId",
                table: "Emissoes");

            migrationBuilder.DropIndex(
                name: "IX_Emissoes_VeiculoId",
                table: "Emissoes");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_ProprietarioId",
                table: "Veiculos",
                column: "ProprietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Proprietarios_UsuarioId",
                table: "Proprietarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Emissoes_RuaId",
                table: "Emissoes",
                column: "RuaId");

            migrationBuilder.CreateIndex(
                name: "IX_Emissoes_VeiculoId",
                table: "Emissoes",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Veiculos_ProprietarioId",
                table: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Proprietarios_UsuarioId",
                table: "Proprietarios");

            migrationBuilder.DropIndex(
                name: "IX_Emissoes_RuaId",
                table: "Emissoes");

            migrationBuilder.DropIndex(
                name: "IX_Emissoes_VeiculoId",
                table: "Emissoes");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_ProprietarioId",
                table: "Veiculos",
                column: "ProprietarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proprietarios_UsuarioId",
                table: "Proprietarios",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emissoes_RuaId",
                table: "Emissoes",
                column: "RuaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emissoes_VeiculoId",
                table: "Emissoes",
                column: "VeiculoId",
                unique: true);
        }
    }
}
