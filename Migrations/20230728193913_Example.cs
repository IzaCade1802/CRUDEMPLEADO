﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace EjemploConexioBDMySQL.Migrations
{
    public partial class Example : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    PKEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.PKEmpleado);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
