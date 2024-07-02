using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GeekStore.Pages
{
    [Authorize]
    public class IndexModel(ILogger<IndexModel> logger) : PageModel
    {
        private readonly ILogger<IndexModel> _logger = logger;

        public void OnGet()
        {

        }
    }
}
