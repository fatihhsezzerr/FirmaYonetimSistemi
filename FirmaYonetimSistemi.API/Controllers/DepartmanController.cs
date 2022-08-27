using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirmaYonetimSistemi.DataAccess;
using FirmaYonetimSistemi.Entities;
using Microsoft.AspNetCore.Authorization;

namespace FirmaYonetimSistemi.API.Controllers
{
    public class DepartmanController : Controller
    {
        private readonly FirmaDbContext _context;

        public DepartmanController(FirmaDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles ="Müdür,İK")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departmanlar.AsNoTracking().ToListAsync());
        }

        // GET: Departman/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departman = await _context.Departmanlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departman == null)
            {
                return NotFound();
            }

            return View(departman);
        }

        // GET: Departman/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departman/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DepartmanAdi,Yetki")] Departman departman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departman);
        }

        // GET: Departman/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departman = await _context.Departmanlar.FindAsync(id);
            if (departman == null)
            {
                return NotFound();
            }
            return View(departman);
        }

        // POST: Departman/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DepartmanAdi,Yetki")] Departman departman)
        {
            if (id != departman.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmanExists(departman.Id))
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
            return View(departman);
        }

        // GET: Departman/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departman = await _context.Departmanlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departman == null)
            {
                return NotFound();
            }

            return View(departman);
        }

        // POST: Departman/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departman = await _context.Departmanlar.FindAsync(id);
            _context.Departmanlar.Remove(departman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmanExists(int id)
        {
            return _context.Departmanlar.Any(e => e.Id == id);
        }
    }
}
