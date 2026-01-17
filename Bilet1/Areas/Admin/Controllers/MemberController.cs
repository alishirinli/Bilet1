using Bilet1.DAL;
using Bilet1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bilet1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController : Controller
    {
        private readonly AppDbContext _context;

        public MemberController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Member> members = await _context.Members.ToListAsync();
            return View(members);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Member member)
        {
            if (!ModelState.IsValid)
            {
                return View(member);
            }

            bool result = await _context.Members
                .AnyAsync(c => c.Name == member.Name);

            if (result)
            {
                ModelState.AddModelError("Name", "Bu member sistemdə artıq var");
                return View(member);
            }

            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
