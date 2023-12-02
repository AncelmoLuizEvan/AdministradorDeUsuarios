﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpcCalc.Infra.Migrations
{
    /// <inheritdoc />
    public partial class IncluindoDataInicialFinalNoPerfil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataFinal",
                table: "Perfis",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicio",
                table: "Perfis",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFinal",
                table: "Perfis");

            migrationBuilder.DropColumn(
                name: "DataInicio",
                table: "Perfis");
        }
    }
}