using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeFit.Data;
using BeFit.Models;

namespace BeFit.Controllers
{
    public class StatisticController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatisticController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Statistic
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Statistic.Include(s => s.ExerciseType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Statistic/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Statistic == null)
            {
                return NotFound();
            }

            var statistic = await _context.Statistic
                .Include(s => s.ExerciseType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statistic == null)
            {
                return NotFound();
            }

            return View(statistic);
        }

        // GET: Statistic/Create
        public IActionResult Create()
        {
            ViewData["ExerciseTypeId"] = new SelectList(_context.ExerciseType, "Id", "Id");
            return View();
        }

        // POST: Statistic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BestResult,NumOfSesssion,ExerciseTypeId")] Statistic statistic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statistic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExerciseTypeId"] = new SelectList(_context.ExerciseType, "Id", "Id", statistic.ExerciseTypeId);
            return View(statistic);
        }

        // GET: Statistic/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Statistic == null)
            {
                return NotFound();
            }

            var statistic = await _context.Statistic.FindAsync(id);
            if (statistic == null)
            {
                return NotFound();
            }
            ViewData["ExerciseTypeId"] = new SelectList(_context.ExerciseType, "Id", "Id", statistic.ExerciseTypeId);
            return View(statistic);
        }

        // POST: Statistic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BestResult,NumOfSesssion,ExerciseTypeId")] Statistic statistic)
        {
            if (id != statistic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statistic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatisticExists(statistic.Id))
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
            ViewData["ExerciseTypeId"] = new SelectList(_context.ExerciseType, "Id", "Id", statistic.ExerciseTypeId);
            return View(statistic);
        }

        // GET: Statistic/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Statistic == null)
            {
                return NotFound();
            }

            var statistic = await _context.Statistic
                .Include(s => s.ExerciseType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statistic == null)
            {
                return NotFound();
            }

            return View(statistic);
        }

        // POST: Statistic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Statistic == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Statistic'  is null.");
            }
            var statistic = await _context.Statistic.FindAsync(id);
            if (statistic != null)
            {
                _context.Statistic.Remove(statistic);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatisticExists(int id)
        {
          return (_context.Statistic?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
