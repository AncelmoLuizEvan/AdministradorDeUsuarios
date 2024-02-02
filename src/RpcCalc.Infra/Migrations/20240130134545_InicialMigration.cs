using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpcCalc.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InicialMigration : Migration
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
                    PermissaoId = table.Column<string>(type: "varchar(36)", nullable: true),
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
                    { "2796d73e-afd8-47a6-a72f-7db92bbc3fea", null, new DateTime(2024, 1, 30, 9, 45, 44, 961, DateTimeKind.Local).AddTicks(7062), "Acesso para testar o sistema", "Mensal" },
                    { "3768dfb8-d04b-42ae-80f5-c82851209773", null, new DateTime(2024, 1, 30, 9, 45, 44, 961, DateTimeKind.Local).AddTicks(7124), "Acesso para testar", "Semana" },
                    { "793dd8cd-3383-4e0a-81ca-dfe7b83b6479", null, new DateTime(2024, 1, 30, 9, 45, 44, 961, DateTimeKind.Local).AddTicks(7123), "Acesso vitalício", "Vitalicio" },
                    { "dcaf4669-cacb-41c5-9df5-1a868d1ba2e1", null, new DateTime(2024, 1, 30, 9, 45, 44, 961, DateTimeKind.Local).AddTicks(7120), "Acesso por seis meses", "Semestral" },
                    { "ea7f2f94-e55e-417c-b4a4-1f34a4d4a760", null, new DateTime(2024, 1, 30, 9, 45, 44, 961, DateTimeKind.Local).AddTicks(7121), "Acesso por um ano", "Anual" }
                });

            migrationBuilder.InsertData(
                table: "Permissoes",
                columns: new[] { "Id", "Acessar", "DataAtualizacao", "DataCriacao", "Sistema" },
                values: new object[,]
                {
                    { "5472a83d-711e-47bd-a253-d3836f14defa", 1, null, new DateTime(2024, 1, 30, 9, 45, 44, 962, DateTimeKind.Local).AddTicks(1344), "RPC Desktop" },
                    { "dadd3806-ed07-4105-8f79-ac424f544bbb", 1, null, new DateTime(2024, 1, 30, 9, 45, 44, 962, DateTimeKind.Local).AddTicks(1352), "RPC Web Admin" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "Descricao", "Nome" },
                values: new object[,]
                {
                    { "98b8bc25-67d6-46b7-92d4-084f5c2498f3", null, new DateTime(2024, 1, 30, 9, 45, 44, 962, DateTimeKind.Local).AddTicks(3395), "Cliente RpcCalc", "Cliente" },
                    { "f1933391-0f38-49b4-895b-34e06e26591e", null, new DateTime(2024, 1, 30, 9, 45, 44, 962, DateTimeKind.Local).AddTicks(3388), "Administrador", "Admin" }
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
