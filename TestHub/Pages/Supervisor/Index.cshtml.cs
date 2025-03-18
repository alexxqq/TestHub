using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using TestHub.BLL.Interfaces;
using TestHub.DAL.Models;

namespace TestHub.View.Pages.Supervisor
{
    public class IndexModel : PageModel
    {
        private readonly ISupervisorService _userService;

        public IndexModel(ISupervisorService userService)
        {
            Log.Information("IndexModel() from supervisor created");
            _userService = userService;
        }

        public List<User> Admins { get; set; } = new();

        public async Task OnGetAsync()
        {
            Log.Information("OnGetAsync() from supervisor index");
            Admins = await _userService.GetAdminsAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Log.Information("OnPostDeleteAsync() from supervisor index");
            await _userService.DeleteAdminAsync(id);
            return RedirectToPage();
        }
    }
}
