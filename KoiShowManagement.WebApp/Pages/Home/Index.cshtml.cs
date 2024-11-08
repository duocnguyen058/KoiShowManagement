using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiShowManagement.WebApp.Pages.Home
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            ViewData["Title"] = "Trang chủ";
        }
    }
}
