using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using TestHub.BLL.Services;
using TestHub.DAL.DTO;

namespace TestHub.View.Pages.Tests
{
    public class CreateModel : PageModel
    {
        private readonly TestService _testService;

        [BindProperty]
        public required TestDto TestDto { get; set; }

        public List<QuestionDto> TempQuestions { get; set; } = new();

        public CreateModel(TestService testService)
        {
            _testService = testService;
        }

        public void OnGet()
        {
            if (TempData["Questions"] != null)
            {
                TempQuestions = JsonSerializer.Deserialize<List<QuestionDto>>(TempData["Questions"] as string?? "")?? new();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TempData.Remove("Questions");
            await _testService.AddAsync(TestDto);
            return RedirectToPage("Index");
        }
    }
}
