using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flashcardsAPI.Migrations
{
    /// <inheritdoc />
    public partial class QuizMudando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Teste_TesteId",
                table: "Quiz");

            migrationBuilder.RenameColumn(
                name: "TesteId",
                table: "Quiz",
                newName: "FlashCardId");

            migrationBuilder.RenameIndex(
                name: "IX_Quiz_TesteId",
                table: "Quiz",
                newName: "IX_Quiz_FlashCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_FlashCards_FlashCardId",
                table: "Quiz",
                column: "FlashCardId",
                principalTable: "FlashCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_FlashCards_FlashCardId",
                table: "Quiz");

            migrationBuilder.RenameColumn(
                name: "FlashCardId",
                table: "Quiz",
                newName: "TesteId");

            migrationBuilder.RenameIndex(
                name: "IX_Quiz_FlashCardId",
                table: "Quiz",
                newName: "IX_Quiz_TesteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Teste_TesteId",
                table: "Quiz",
                column: "TesteId",
                principalTable: "Teste",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
