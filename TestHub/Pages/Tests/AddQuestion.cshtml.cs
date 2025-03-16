using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using TestHub.DAL.DTO;

namespace TestHub.View.Pages.Tests
{
    public class AddQuestionModel : PageModel
    {
        [BindProperty]
        public required QuestionDto Question { get; set; }

        public required string QuestionType { get; set; }

        public void OnGet(string type)
        {
            QuestionType = type;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingQuestions = TempData["Questions"] as string;
            var questionList = existingQuestions != null
                ? JsonSerializer.Deserialize<List<QuestionDto>>(existingQuestions)
                : new List<QuestionDto>();

            questionList?.Add(Question);
            TempData["Questions"] = JsonSerializer.Serialize(questionList);
            TempData.Keep("Questions");

            return RedirectToPage("TestCreate");
        }
    }
}
