using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_companyDetails_CompanyMasters_CompanyId",
                table: "companyDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_companyDetails",
                table: "companyDetails");

            migrationBuilder.RenameTable(
                name: "companyDetails",
                newName: "CompanyDetails");

            migrationBuilder.RenameIndex(
                name: "IX_companyDetails_CompanyId",
                table: "CompanyDetails",
                newName: "IX_CompanyDetails_CompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "UserMasters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "UserMasters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "CompanyMasters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "CompanyMasters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyDetails",
                table: "CompanyDetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserMasters_CountryId",
                table: "UserMasters",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMasters_StateId",
                table: "UserMasters",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_StateMaster_CountryId",
                table: "StateMaster",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMasters_CountryId",
                table: "CompanyMasters",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMasters_StateId",
                table: "CompanyMasters",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyDetails_CompanyMasters_CompanyId",
                table: "CompanyDetails",
                column: "CompanyId",
                principalTable: "CompanyMasters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMasters_CountryMasters_CountryId",
                table: "CompanyMasters",
                column: "CountryId",
                principalTable: "CountryMasters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyMasters_StateMaster_StateId",
                table: "CompanyMasters",
                column: "StateId",
                principalTable: "StateMaster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StateMaster_CountryMasters_CountryId",
                table: "StateMaster",
                column: "CountryId",
                principalTable: "CountryMasters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMasters_CountryMasters_CountryId",
                table: "UserMasters",
                column: "CountryId",
                principalTable: "CountryMasters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMasters_StateMaster_StateId",
                table: "UserMasters",
                column: "StateId",
                principalTable: "StateMaster",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyDetails_CompanyMasters_CompanyId",
                table: "CompanyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMasters_CountryMasters_CountryId",
                table: "CompanyMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyMasters_StateMaster_StateId",
                table: "CompanyMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_StateMaster_CountryMasters_CountryId",
                table: "StateMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMasters_CountryMasters_CountryId",
                table: "UserMasters");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMasters_StateMaster_StateId",
                table: "UserMasters");

            migrationBuilder.DropIndex(
                name: "IX_UserMasters_CountryId",
                table: "UserMasters");

            migrationBuilder.DropIndex(
                name: "IX_UserMasters_StateId",
                table: "UserMasters");

            migrationBuilder.DropIndex(
                name: "IX_StateMaster_CountryId",
                table: "StateMaster");

            migrationBuilder.DropIndex(
                name: "IX_CompanyMasters_CountryId",
                table: "CompanyMasters");

            migrationBuilder.DropIndex(
                name: "IX_CompanyMasters_StateId",
                table: "CompanyMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyDetails",
                table: "CompanyDetails");

            migrationBuilder.RenameTable(
                name: "CompanyDetails",
                newName: "companyDetails");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyDetails_CompanyId",
                table: "companyDetails",
                newName: "IX_companyDetails_CompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "UserMasters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "UserMasters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "CompanyMasters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "CompanyMasters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_companyDetails",
                table: "companyDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_companyDetails_CompanyMasters_CompanyId",
                table: "companyDetails",
                column: "CompanyId",
                principalTable: "CompanyMasters",
                principalColumn: "Id");
        }
    }
}
