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
    public class SatisController : Controller
    {
        private readonly FirmaDbContext _context;

        public SatisController(FirmaDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Müdür,Personel")]
        public async Task<IActionResult> Index()
        {
            var firmaDbContext = _context.Satislar.AsNoTracking().Include(s => s.Personel).Include(s => s.Urun);
            return View(await firmaDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var satis = await _context.Satislar
                .Include(s => s.Personel)
                .Include(s => s.Urun)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (satis == null)
            {
                return NotFound();
            }

            return View(satis);
        }

        public IActionResult Create()
        {
            ViewData["PersonelId"] = new SelectList(_context.Personeller, "Id", "AdSoyad");
            ViewData["UrunId"] = new SelectList(_context.Urunler, "Id", "UrunAdi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UrunId,PersonelId,Miktar,ToplamTutar,SatisTarihi")] Satis satis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(satis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonelId"] = new SelectList(_context.Personeller, "Id", "AdSoyad", satis.PersonelId);
            ViewData["UrunId"] = new SelectList(_context.Urunler, "Id", "UrunAdi", satis.UrunId);
            return View(satis);
        }

        // GET: Satis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var satis = await _context.Satislar.FindAsync(id);
            if (satis == null)
            {
                return NotFound();
            }
            ViewData["PersonelId"] = new SelectList(_context.Personeller, "Id", "AdSoyad", satis.PersonelId);
            ViewData["UrunId"] = new SelectList(_context.Urunler, "Id", "UrunAdi", satis.UrunId);
            return View(satis);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UrunId,PersonelId,Miktar,ToplamTutar,SatisTarihi")] Satis satis)
        {
            if (id != satis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(satis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SatisExists(satis.Id))
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
            ViewData["PersonelId"] = new SelectList(_context.Personeller, "Id", "AdSoyad", satis.PersonelId);
            ViewData["UrunId"] = new SelectList(_context.Urunler, "Id", "UrunAdi", satis.UrunId);
            return View(satis);
        }

        // GET: Satis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var satis = await _context.Satislar
                .Include(s => s.Personel)
                .Include(s => s.Urun)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (satis == null)
            {
                return NotFound();
            }

            return View(satis);
        }

        // POST: Satis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var satis = await _context.Satislar.FindAsync(id);
            _context.Satislar.Remove(satis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SatisExists(int id)
        {
            return _context.Satislar.Any(e => e.Id == id);
        }
    }
}
