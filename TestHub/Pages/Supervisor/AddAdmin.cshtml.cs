using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using TestHub.BLL.Interfaces;

namespace TestHub.View.Pages.Supervisor
{
    public class AddAdminModel : PageModel
    {
        private readonly ISupervisorService _userService;

        public AddAdminModel(ISupervisorService userService)
        {
            Log.Information("AddAdminModel() created");
            _userService = userService;
        }

        [BindProperty]
        public string Name { get; set; } = null!;

        [BindProperty]
        public string Login { get; set; } = null!;

        [BindProperty]
        public string Password { get; set; } = null!;

        public string? ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            Log.Information("OnPostAsync() from AddAdmin started");
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
            {
                Log.Error("All fields should be filled!");
                ErrorMessage = "Усі поля мають бути заповнені!";
                return Page();
            }

            if (!new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(Login))
            {
                Log.Error("Incorrect email!");
                ErrorMessage = "Некоректна електронна пошта!";
                return Page();
            }

            await _userService.AddAdminAsync(Name, Login, Password);
            Log.Information("OnPostAsync() from AddAdmin ended");
            return RedirectToPage("Index");
        }
    }
}
