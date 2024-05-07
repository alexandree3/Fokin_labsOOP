using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OOP_LABA3;
using OOP_LABA3.Models;

namespace OOP_LABA3.Controllers
{
    public class OfficeJobsController : Controller
    {
        private readonly AppDbContext _context;

        public OfficeJobsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: OfficeJobs
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.OfficeJob.Include(o => o.Job).Include(o => o.Office);
            return View(await appDbContext.ToListAsync());
        }

        // GET: OfficeJobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeJob = await _context.OfficeJob
                .Include(o => o.Job)
                .Include(o => o.Office)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (officeJob == null)
            {
                return NotFound();
            }

            return View(officeJob);
        }

        // GET: OfficeJobs/Create
        public IActionResult Create()
        {
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id");
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "Id");
            return View();
        }

        // POST: OfficeJobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OfficeId,JobId")] OfficeJob officeJob)
        {
            if (ModelState.IsValid)
            {
                _context.Add(officeJob);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id", officeJob.JobId);
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "Id", officeJob.OfficeId);
            return View(officeJob);
        }

        // GET: OfficeJobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeJob = await _context.OfficeJob.FindAsync(id);
            if (officeJob == null)
            {
                return NotFound();
            }
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id", officeJob.JobId);
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "Id", officeJob.OfficeId);
            return View(officeJob);
        }

        // POST: OfficeJobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OfficeId,JobId")] OfficeJob officeJob)
        {
            if (id != officeJob.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(officeJob);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfficeJobExists(officeJob.Id))
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
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Id", officeJob.JobId);
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "Id", officeJob.OfficeId);
            return View(officeJob);
        }

        // GET: OfficeJobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeJob = await _context.OfficeJob
                .Include(o => o.Job)
                .Include(o => o.Office)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (officeJob == null)
            {
                return NotFound();
            }

            return View(officeJob);
        }

        // POST: OfficeJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var officeJob = await _context.OfficeJob.FindAsync(id);
            if (officeJob != null)
            {
                _context.OfficeJob.Remove(officeJob);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfficeJobExists(int id)
        {
            return _context.OfficeJob.Any(e => e.Id == id);
        }
    }
}
