using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OOP_LABA3.Models;

namespace OOP_LABA3.Controllers
{
    public class HumenController : Controller
    {
        private readonly AppDbContext _context;

        public HumenController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Humen
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Humans.Include(h => h.Office);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Humen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var human = await _context.Humans
                .Include(h => h.Office)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (human == null)
            {
                return NotFound();
            }

            return View(human);
        }

        // GET: Humen/Create
        public IActionResult Create()
        {
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "Id");
            return View();
        }

        // POST: Humen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Phone,Address,OfficeId")] Human human)
        {
            if (ModelState.IsValid)
            {
                _context.Add(human);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "Id", human.OfficeId);
            return View(human);
        }

        // GET: Humen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var human = await _context.Humans.FindAsync(id);
            if (human == null)
            {
                return NotFound();
            }
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "Id", human.OfficeId);
            return View(human);
        }

        // POST: Humen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Phone,Address,OfficeId")] Human human)
        {
            if (id != human.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(human);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HumanExists(human.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "Id", human.OfficeId);
            return View(human);
        }

        // GET: Humen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var human = await _context.Humans
                .Include(h => h.Office)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (human == null)
            {
                return NotFound();
            }

            return View(human);
        }

        // POST: Humen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var human = await _context.Humans.FindAsync(id);
            if (human != null)
            {
                _context.Humans.Remove(human);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HumanExists(int id)
        {
            return _context.Humans.Any(e => e.Id == id);
        }
    }
}
