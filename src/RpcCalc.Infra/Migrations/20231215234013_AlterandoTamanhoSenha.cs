using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpcCalc.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoTamanhoSenha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Perfis",
                keyColumn: "Id",
                keyValue: "1aa3a3f9-e1d6-4c77-9a88-a269b5254365");

            migrationBuilder.DeleteData(
                table: "Perfis",
                keyColumn: "Id",
                keyValue: "92a3f4a4-b35c-44d6-bdfd-1e20e5faea60");

            migrationBuilder.DeleteData(
                table: "Perfis",
                keyColumn: "Id",
                keyValue: "db3ff49b-f066-4bad-88ca-b8ff17a80b28");

            migrationBuilder.DeleteData(
                table: "Perfis",
                keyColumn: "Id",
                keyValue: "ebf3d807-1424-4e86-8a13-a8ee89674765");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "412551dd-b756-49ec-803b-f229acd4fb89");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "43a63c44-e72f-472b-b9d7-7f55c848b9a6");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(45)");

            migrationBuilder.InsertData(
                table: "Perfis",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "Descricao", "Nome" },
                values: new object[,]
                {
                    { "7947d5c0-fe71-43cf-896a-d4356caedffe", null, new DateTime(2023, 12, 15, 19, 40, 13, 548, DateTimeKind.Local).AddTicks(2348), "Acesso vitalício", "Vitalicio" },
                    { "9c335fc5-1870-4074-995a-6d4fcb2746f8", null, new DateTime(2023, 12, 15, 19, 40, 13, 548, DateTimeKind.Local).AddTicks(2345), "Acesso por seis meses", "Semestral" },
                    { "9d67272c-5d27-4f84-b666-32e9f6cfb8e6", null, new DateTime(2023, 12, 15, 19, 40, 13, 548, DateTimeKind.Local).AddTicks(2346), "Acesso por um ano", "Anual" },
                    { "ee8bb8a8-4ef3-4ac8-a78c-8ab657b81145", null, new DateTime(2023, 12, 15, 19, 40, 13, 548, DateTimeKind.Local).AddTicks(2313), "Acesso para testar o sistema", "Mensal" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DataAtualizacao", "DataCriacao", "Descricao", "Nome" },
                values: new object[,]
                {
                    { "1c735ea5-2fdd-4ca7-abf5-05620a80f37f", null, new DateTime(2023, 12, 15, 19, 40, 13, 548, DateTimeKind.Local).AddTicks(6467), "Administrador", "Admin" },
                    { "5cc8f87b-0e5a-441e-9123-8368f92babd5", null, new DateTime(2023, 12, 15, 19, 40, 13, 548, DateTimeKind.Local).AddTicks(6477), "Cliente RpcCalc", "Cliente" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Perfis",
                keyColumn: "Id",
                keyValue: "7947d5c0-fe71-43cf-896a-d4356caedffe");

            migrationBuilder.DeleteData(
                table: "Perfis",
                keyColumn: "Id",
                keyValue: "9c335fc5-1870-4074-995a-6d4fcb2746f8");

            migrationBuilder.DeleteData(
                table: "Perfis",
                keyColumn: "Id",
                keyValue: "9d67272c-5d27-4f84-b666-32e9f6cfb8e6");

            migrationBuilder.DeleteData(
                table: "Perfis",
                keyColumn: "Id",
                keyValue: "ee8bb8a8-4ef3-4ac8-a78c-8ab657b81145");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1c735ea5-2fdd-4ca7-abf5-05620a80f37f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5cc8f87b-0e5a-441e-9123-8368f92babd5");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "varchar(45)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

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
        }
    }
}
