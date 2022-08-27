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
using FirmaYonetimSistemi.Business.Concrete;

namespace FirmaYonetimSistemi.API.Controllers
{
    public class PersonelController : Controller
    {
        private readonly FirmaDbContext _context;

        public PersonelController(FirmaDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Müdür,İK")]
        public async Task<IActionResult> Index()
        {
            var firmaDbContext = _context.Personeller.Include(p => p.Departman);
            return View(await firmaDbContext.ToListAsync());
        }

        // GET: Personel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personel = await _context.Personeller
                .Include(p => p.Departman)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personel == null)
            {
                return NotFound();
            }

            return View(personel);
        }

        // GET: Personel/Create
        public IActionResult Create()
        {
            ViewData["DepartmanId"] = new SelectList(_context.Departmanlar, "Id", "DepartmanAdi");
            return View();
        }

        // POST: Personel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdSoyad,KullaniciAdi,Eposta,Sifre,DepartmanId")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmanId"] = new SelectList(_context.Departmanlar, "Id", "DepartmanAdi", personel.DepartmanId);
            return View(personel);
        }

        // GET: Personel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personel = await _context.Personeller.FindAsync(id);
            if (personel == null)
            {
                return NotFound();
            }
            ViewData["DepartmanId"] = new SelectList(_context.Departmanlar, "Id", "DepartmanAdi", personel.DepartmanId);
            return View(personel);
        }

        // POST: Personel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdSoyad,KullaniciAdi,Eposta,Sifre,DepartmanId")] Personel personel)
        {
            if (id != personel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                new PersonelManager().UpdatePersonel(personel);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmanId"] = new SelectList(_context.Departmanlar, "Id", "DepartmanAdi", personel.DepartmanId);
            return View(personel);
        }

        // GET: Personel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personel = await _context.Personeller
                .Include(p => p.Departman)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personel == null)
            {
                return NotFound();
            }

            return View(personel);
        }

        // POST: Personel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personel = await _context.Personeller.FindAsync(id);
            _context.Personeller.Remove(personel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonelExists(int id)
        {
            return _context.Personeller.Any(e => e.Id == id);
        }
    }
}
