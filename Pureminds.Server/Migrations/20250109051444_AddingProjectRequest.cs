using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pureminds.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddingProjectRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RelevantQuestion",
                table: "RelevantQuestion");

            migrationBuilder.DropColumn(
                name: "AttachmentAttribute",
                table: "ProductAttachments");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "ProductAttachments");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "ProductAttachments");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "ProductAttachments");

            migrationBuilder.RenameTable(
                name: "RelevantQuestion",
                newName: "RelevantQuestions");

            migrationBuilder.AddColumn<int>(
                name: "AttachmentId",
                table: "ProductAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "MediaClients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Feedback",
                table: "MediaClients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DashboardVideoFilePath",
                table: "GeneralSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelevantQuestions",
                table: "RelevantQuestions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentAttribute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorIPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsArchieved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuggestedStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BudgetStartLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BudgetEndLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProjectBrief = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorIPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsArchieved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectRequests_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttachments_AttachmentId",
                table: "ProductAttachments",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRequests_AttachmentId",
                table: "ProjectRequests",
                column: "AttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttachments_Attachments_AttachmentId",
                table: "ProductAttachments",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttachments_Attachments_AttachmentId",
                table: "ProductAttachments");

            migrationBuilder.DropTable(
                name: "ProjectRequests");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttachments_AttachmentId",
                table: "ProductAttachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelevantQuestions",
                table: "RelevantQuestions");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "ProductAttachments");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "MediaClients");

            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "MediaClients");

            migrationBuilder.DropColumn(
                name: "DashboardVideoFilePath",
                table: "GeneralSettings");

            migrationBuilder.RenameTable(
                name: "RelevantQuestions",
                newName: "RelevantQuestion");

            migrationBuilder.AddColumn<string>(
                name: "AttachmentAttribute",
                table: "ProductAttachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "ProductAttachments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "ProductAttachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "ProductAttachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelevantQuestion",
                table: "RelevantQuestion",
                column: "Id");
        }
    }
}
