using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpcCalc.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoRelacionamentoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissoes_Perfis_PerfilId",
                table: "Permissoes");

            migrationBuilder.DropIndex(
                name: "IX_Permissoes_PerfilId",
                table: "Permissoes");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "Permissoes");

            migrationBuilder.AddColumn<string>(
                name: "PermissaoId",
                table: "UsuariosPerfis",
                type: "varchar(36)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPerfis_PermissaoId",
                table: "UsuariosPerfis",
                column: "PermissaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosPerfis_Permissoes_PermissaoId",
                table: "UsuariosPerfis",
                column: "PermissaoId",
                principalTable: "Permissoes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosPerfis_Permissoes_PermissaoId",
                table: "UsuariosPerfis");

            migrationBuilder.DropIndex(
                name: "IX_UsuariosPerfis_PermissaoId",
                table: "UsuariosPerfis");

            migrationBuilder.DropColumn(
                name: "PermissaoId",
                table: "UsuariosPerfis");

            migrationBuilder.AddColumn<string>(
                name: "PerfilId",
                table: "Permissoes",
                type: "varchar(36)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Permissoes_PerfilId",
                table: "Permissoes",
                column: "PerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissoes_Perfis_PerfilId",
                table: "Permissoes",
                column: "PerfilId",
                principalTable: "Perfis",
                principalColumn: "Id");
        }
    }
}
