using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekStore.Areas.Admin.Pages.AdminUsers
{
    public class CreateModel : PageModel
    {
        [Authorize(Roles = "Admin")]
        public void OnGet()
        {
        }
    }
}
