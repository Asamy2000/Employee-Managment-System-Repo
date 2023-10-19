using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MVCAPPDAL.Migrations
{
	public partial class EmpExtraData : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Employees",
				type: "nvarchar(50)",
				maxLength: 50,
				nullable: false,
				defaultValue: "",
				oldClrType: typeof(string),
				oldType: "nvarchar(max)",
				oldNullable: true);

			migrationBuilder.AddColumn<string>(
				name: "Address",
				table: "Employees",
				type: "nvarchar(max)",
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "Age",
				table: "Employees",
				type: "int",
				nullable: true);

			migrationBuilder.AddColumn<DateTime>(
				name: "CreationDate",
				table: "Employees",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<string>(
				name: "Email",
				table: "Employees",
				type: "nvarchar(max)",
				nullable: true);

			migrationBuilder.AddColumn<DateTime>(
				name: "HireDate",
				table: "Employees",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<bool>(
				name: "IsActive",
				table: "Employees",
				type: "bit",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<string>(
				name: "Phone",
				table: "Employees",
				type: "nvarchar(max)",
				nullable: true);

			migrationBuilder.AddColumn<decimal>(
				name: "Salary",
				table: "Employees",
				type: "decimal(18,2)",
				nullable: false,
				defaultValue: 0m);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Address",
				table: "Employees");

			migrationBuilder.DropColumn(
				name: "Age",
				table: "Employees");

			migrationBuilder.DropColumn(
				name: "CreationDate",
				table: "Employees");

			migrationBuilder.DropColumn(
				name: "Email",
				table: "Employees");

			migrationBuilder.DropColumn(
				name: "HireDate",
				table: "Employees");

			migrationBuilder.DropColumn(
				name: "IsActive",
				table: "Employees");

			migrationBuilder.DropColumn(
				name: "Phone",
				table: "Employees");

			migrationBuilder.DropColumn(
				name: "Salary",
				table: "Employees");

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "Employees",
				type: "nvarchar(max)",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "nvarchar(50)",
				oldMaxLength: 50);
		}
	}
}
