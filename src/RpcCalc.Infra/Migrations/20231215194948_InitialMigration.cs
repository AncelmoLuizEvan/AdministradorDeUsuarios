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
                    Senha = table.Column<string>(type: "varchar(45)", nullable: false),
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
                name: "UsuarioRole",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "varchar(36)", nullable: false),
                    UsuarioId = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRole", x => new { x.RoleId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_UsuarioRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsuarioRole_UsuarioId",
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

            migrationBuilder.InsertData(
                table: "Perfis",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "Descricao", "Nome" },
                values: new object[,]
                {
                    { "1aa3a3f9-e1d6-4c77-9a88-a269b5254365", null, new DateTime(2023, 12, 15, 15, 49, 48, 141, DateTimeKind.Local).AddTicks(4658), "Acesso por um ano", "Anual" },
                    { "92a3f4a4-b35c-44d6-bdfd-1e20e5faea60", null, new DateTime(2023, 12, 15, 15, 49, 48, 141, DateTimeKind.Local).AddTicks(4639), "Acesso para testar o sistema", "Mensal" },
                    { "db3ff49b-f066-4bad-88ca-b8ff17a80b28", null, new DateTime(2023, 12, 15, 15, 49, 48, 141, DateTimeKind.Local).AddTicks(4686), "Acesso vitalício", "Vitalicio" },
                    { "ebf3d807-1424-4e86-8a13-a8ee89674765", null, new DateTime(2023, 12, 15, 15, 49, 48, 141, DateTimeKind.Local).AddTicks(4657), "Acesso por seis meses", "Semestral" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "Descricao", "Nome" },
                values: new object[,]
                {
                    { "412551dd-b756-49ec-803b-f229acd4fb89", null, new DateTime(2023, 12, 15, 15, 49, 48, 141, DateTimeKind.Local).AddTicks(9166), "Administrador", "Admin" },
                    { "43a63c44-e72f-472b-b9d7-7f55c848b9a6", null, new DateTime(2023, 12, 15, 15, 49, 48, 141, DateTimeKind.Local).AddTicks(9175), "Cliente RpcCalc", "Cliente" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MotivosInativacao_UsuarioId",
                table: "MotivosInativacao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRole_UsuarioId",
                table: "UsuarioRole",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotivosInativacao");

            migrationBuilder.DropTable(
                name: "UsuarioRole");

            migrationBuilder.DropTable(
                name: "UsuariosPerfis");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Perfis");

            migrationBuilder.DropTable(
                name: "Permissoes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
