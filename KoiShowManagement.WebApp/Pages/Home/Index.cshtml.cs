using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiShowManagement.WebApp.Pages.Home
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            // Gán giá trị cho ViewData["Title"]
            ViewData["Title"] = "Trang chủ";
        }
    }
}
