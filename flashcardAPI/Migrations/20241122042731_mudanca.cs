using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flashcardsAPI.Migrations
{
    /// <inheritdoc />
    public partial class mudanca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCards_Flash_FlashId",
                table: "FlashCards");

            migrationBuilder.DropIndex(
                name: "IX_FlashCards_FlashId",
                table: "FlashCards");

            migrationBuilder.DropColumn(
                name: "FlashId",
                table: "FlashCards");

            migrationBuilder.AddColumn<int>(
                name: "FlashCardId",
                table: "Teste",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teste_FlashCardId",
                table: "Teste",
                column: "FlashCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teste_FlashCards_FlashCardId",
                table: "Teste",
                column: "FlashCardId",
                principalTable: "FlashCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teste_FlashCards_FlashCardId",
                table: "Teste");

            migrationBuilder.DropIndex(
                name: "IX_Teste_FlashCardId",
                table: "Teste");

            migrationBuilder.DropColumn(
                name: "FlashCardId",
                table: "Teste");

            migrationBuilder.AddColumn<int>(
                name: "FlashId",
                table: "FlashCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_FlashId",
                table: "FlashCards",
                column: "FlashId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCards_Flash_FlashId",
                table: "FlashCards",
                column: "FlashId",
                principalTable: "Flash",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
