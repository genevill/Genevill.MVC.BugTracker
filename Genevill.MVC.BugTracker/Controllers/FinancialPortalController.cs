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
    public class FinancialPortalController : Controller
    {
        private readonly GenevillMVCFinancialPortalContext _context;

        public FinancialPortalController(GenevillMVCFinancialPortalContext context)
        {
            _context = context;
        }

        // GET: FinancialPortal
        public async Task<IActionResult> Index()
        {
            return View(await _context.FinancialPortal.ToListAsync());
        }

        // GET: FinancialPortal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financialPortal = await _context.FinancialPortal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (financialPortal == null)
            {
                return NotFound();
            }

            return View(financialPortal);
        }

        // GET: FinancialPortal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FinancialPortal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Account,AccountType,TransactionDate,TransactionAmount,Balance")] FinancialPortal financialPortal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(financialPortal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(financialPortal);
        }

        // GET: FinancialPortal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financialPortal = await _context.FinancialPortal.FindAsync(id);
            if (financialPortal == null)
            {
                return NotFound();
            }
            return View(financialPortal);
        }

        // POST: FinancialPortal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Account,AccountType,TransactionDate,TransactionAmount,Balance")] FinancialPortal financialPortal)
        {
            if (id != financialPortal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(financialPortal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinancialPortalExists(financialPortal.Id))
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
            return View(financialPortal);
        }

        // GET: FinancialPortal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financialPortal = await _context.FinancialPortal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (financialPortal == null)
            {
                return NotFound();
            }

            return View(financialPortal);
        }

        // POST: FinancialPortal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var financialPortal = await _context.FinancialPortal.FindAsync(id);
            _context.FinancialPortal.Remove(financialPortal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinancialPortalExists(int id)
        {
            return _context.FinancialPortal.Any(e => e.Id == id);
        }
    }
}
