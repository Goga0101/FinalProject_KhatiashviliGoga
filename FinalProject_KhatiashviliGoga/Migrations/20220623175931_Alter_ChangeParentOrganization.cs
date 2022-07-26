using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject_KhatiashviliGoga.Migrations
{
    public partial class Alter_ChangeParentOrganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentOrganization",
                table: "Organizations");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "Organizations",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Organizations");

            migrationBuilder.AddColumn<string>(
                name: "ParentOrganization",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
