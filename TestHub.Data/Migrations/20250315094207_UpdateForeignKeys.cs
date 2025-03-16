using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestHub.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_questions_test_id",
                table: "questions",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "IX_answers_question_id",
                table: "answers",
                column: "question_id");

            migrationBuilder.AddForeignKey(
                name: "FK_answers_questions_question_id",
                table: "answers",
                column: "question_id",
                principalTable: "questions",
                principalColumn: "question_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_questions_tests_test_id",
                table: "questions",
                column: "test_id",
                principalTable: "tests",
                principalColumn: "test_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_answers_questions_question_id",
                table: "answers");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_tests_test_id",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_test_id",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_answers_question_id",
                table: "answers");
        }
    }
}
