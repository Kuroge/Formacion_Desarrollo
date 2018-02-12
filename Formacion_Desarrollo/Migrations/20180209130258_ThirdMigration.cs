using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Formacion_Desarrollo.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Usuario_DepartmentId",
                table: "Usuario",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Department_DepartmentId",
                table: "Usuario",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Department_DepartmentId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_DepartmentId",
                table: "Usuario");
        }
    }
}
