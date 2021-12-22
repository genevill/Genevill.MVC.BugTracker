using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Genevill.MVC.BugTracker.Data;
using Genevill.MVC.BugTracker.Models;

namespace Genevill.MVC.BugTracker.Controllers
{
    public class BugTrackerController : Controller
    {
        private readonly GenevillMVCBugTrackerContext _context;

        public BugTrackerController(GenevillMVCBugTrackerContext context)
        {
            _context = context;
        }

        // GET: BugTrackers
        public async Task<IActionResult> Index(string assigneeSearch, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> assigneeQuery = from m in _context.BugTracker
                                            orderby m.Assignee
                                            select m.Assignee;
            var bugs = from m in _context.BugTracker
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                bugs = bugs.Where(s => s.Summary!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(assigneeSearch))
            {
                bugs = bugs.Where(x => x.Assignee == assigneeSearch);
            }

            var bugReportVM = new BugReportViewModel
            {
                Assignees = new SelectList(await assigneeQuery.Distinct().ToListAsync()),
                BugReports = await bugs.ToListAsync()
            };

            return View(bugReportVM);
        }

        // GET: BugTrackers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugReport = await _context.BugTracker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bugReport == null)
            {
                return NotFound();
            }

            return View(bugReport);
        }

        // GET: BugTrackers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BugTrackers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Summary,Assignee,AffectedUser,Status,Resolution,Created,Updated")] BugReport bugReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bugReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bugReport);
        }

        // GET: BugTrackers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugReport = await _context.BugTracker.FindAsync(id);
            if (bugReport == null)
            {
                return NotFound();
            }
            return View(bugReport);
        }

        // POST: BugTrackers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Summary,Assignee,AffectedUser,PhoneNumber,Status,Resolution,Created,Updated")] BugReport bugReport)
        {
            if (id != bugReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bugReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BugTrackerExists(bugReport.Id))
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
            return View(bugReport);
        }

        // GET: BugTrackers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugReport = await _context.BugTracker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bugReport == null)
            {
                return NotFound();
            }

            return View(bugReport);
        }

        // POST: BugTrackers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bugReport = await _context.BugTracker.FindAsync(id);
            _context.BugTracker.Remove(bugReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BugTrackerExists(int id)
        {
            return _context.BugTracker.Any(e => e.Id == id);
        }
    }
}
