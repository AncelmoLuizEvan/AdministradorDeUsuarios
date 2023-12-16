using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpcCalc.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(45)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(45)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfis", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Permissoes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Sistema = table.Column<string>(type: "varchar(45)", nullable: false),
                    Acessar = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissoes", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(45)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(45)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    CnpjCpf = table.Column<string>(type: "varchar(14)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(45)", nullable: false),
                    Login = table.Column<string>(type: "varchar(45)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email = table.Column<string>(type: "varchar(45)", nullable: false),
                    DataHoraAcesso = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DataHoraInclusao = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Celular = table.Column<string>(type: "varchar(15)", nullable: true),
                    EmailVerificado = table.Column<int>(type: "int", nullable: true),
                    Inativo = table.Column<int>(type: "int", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MotivosInativacao",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(45)", nullable: false),
                    UsuarioId = table.Column<string>(type: "varchar(36)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivosInativacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotivosInativacao_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuariosPerfis",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    UsuarioId = table.Column<string>(type: "varchar(36)", nullable: false),
                    PerfilId = table.Column<string>(type: "varchar(36)", nullable: false),
                    PermissaoId = table.Column<string>(type: "varchar(36)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosPerfis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosPerfis_Perfis_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsuariosPerfis_Permissoes_PermissaoId",
                        column: x => x.PermissaoId,
                        principalTable: "Permissoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsuariosPerfis_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuariosRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    UsuarioId = table.Column<string>(type: "varchar(36)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(36)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsuariosRoles_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Perfis",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "Descricao", "Nome" },
                values: new object[,]
                {
                    { "337ebb8d-185c-4f77-b40d-8ed53f9a4744", null, new DateTime(2023, 12, 16, 0, 29, 41, 423, DateTimeKind.Local).AddTicks(1429), "Acesso para testar o sistema", "Mensal" },
                    { "3f81495b-b0fb-4356-9b37-56001d9f41cf", null, new DateTime(2023, 12, 16, 0, 29, 41, 423, DateTimeKind.Local).AddTicks(1447), "Acesso vitalício", "Vitalicio" },
                    { "b45eca50-7451-48a3-9f18-0f91d532c5ee", null, new DateTime(2023, 12, 16, 0, 29, 41, 423, DateTimeKind.Local).AddTicks(1444), "Acesso por seis meses", "Semestral" },
                    { "e645d5f5-8fa6-430e-9f05-ffabedf5c64d", null, new DateTime(2023, 12, 16, 0, 29, 41, 423, DateTimeKind.Local).AddTicks(1446), "Acesso por um ano", "Anual" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "Descricao", "Nome" },
                values: new object[,]
                {
                    { "25b8b123-8e19-44e7-8012-1f9bd866ca88", null, new DateTime(2023, 12, 16, 0, 29, 41, 423, DateTimeKind.Local).AddTicks(6188), "Cliente RpcCalc", "Cliente" },
                    { "d26b4af8-bc0b-4e3c-bc1f-96ccd6bb9f96", null, new DateTime(2023, 12, 16, 0, 29, 41, 423, DateTimeKind.Local).AddTicks(6179), "Administrador", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MotivosInativacao_UsuarioId",
                table: "MotivosInativacao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPerfis_PerfilId",
                table: "UsuariosPerfis",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPerfis_PermissaoId",
                table: "UsuariosPerfis",
                column: "PermissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosPerfis_UsuarioId",
                table: "UsuariosPerfis",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRoles_RoleId",
                table: "UsuariosRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRoles_UsuarioId",
                table: "UsuariosRoles",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotivosInativacao");

            migrationBuilder.DropTable(
                name: "UsuariosPerfis");

            migrationBuilder.DropTable(
                name: "UsuariosRoles");

            migrationBuilder.DropTable(
                name: "Perfis");

            migrationBuilder.DropTable(
                name: "Permissoes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
