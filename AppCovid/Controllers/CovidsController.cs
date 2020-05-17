using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppCovid.Data;
using AppCovid.Models;
using Microsoft.AspNetCore.Authorization;

namespace AppCovid.Controllers
{
    [Authorize]
    public class CovidsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CovidsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Covids
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Covids.Include(c => c.Country);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Covids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covid = await _context.Covids
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (covid == null)
            {
                return NotFound();
            }

            return View(covid);
        }

        // GET: Covids/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Nome");
            return View();
        }

        // POST: Covids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Death,Recovered,Confirmed,CountryId")] Covid covid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(covid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Nome", covid.CountryId);
            return View(covid);
        }

        // GET: Covids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covid = await _context.Covids.FindAsync(id);
            if (covid == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Nome", covid.CountryId);
            return View(covid);
        }

        // POST: Covids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Death,Recovered,Confirmed,CountryId")] Covid covid)
        {
            if (id != covid.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(covid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CovidExists(covid.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Nome", covid.CountryId);
            return View(covid);
        }

        // GET: Covids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covid = await _context.Covids
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (covid == null)
            {
                return NotFound();
            }

            return View(covid);
        }

        // POST: Covids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var covid = await _context.Covids.FindAsync(id);
            _context.Covids.Remove(covid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CovidExists(int id)
        {
            return _context.Covids.Any(e => e.Id == id);
        }
    }
}
