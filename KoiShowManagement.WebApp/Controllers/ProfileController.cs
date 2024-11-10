using Microsoft.AspNetCore.Mvc;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.WebApp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public IActionResult Index()
        {
            var profile = _profileService.GetProfile(User.Identity.Name);
            return View(profile);
        }

        public IActionResult Edit()
        {
            var profile = _profileService.GetProfile(User.Identity.Name);
            return View(profile);
        }
    }
}
