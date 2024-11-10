using Microsoft.AspNetCore.Mvc;
using KoiShowManagement.Repositories.Entities;
using KoiShowManagement.Services.Interface;

namespace KoiShowManagement.WebApp.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public IActionResult Index()
        {
            var members = _memberService.GetAllMembers();  // Đảm bảo gọi đúng phương thức bất đồng bộ
            return View(members);
        }

        public IActionResult Details(int id)
        {
            var member = _memberService.GetMemberById(id);  // Đảm bảo gọi đúng phương thức bất đồng bộ
            return View(member);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Member member)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await _memberService.AddMember(member);  // Sửa từ Add thành AddMember
                if (isAdded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(member);
        }
    }
}
