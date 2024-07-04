using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OWCodigo5.Data;
using OWCodigo5.Models;

namespace OWCodigo5.Controllers
{
    public class ObraTeatrosController : Controller
    {
        private readonly AppDbContext _context;

        public ObraTeatrosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ObraTeatros
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ObrasTeatros.Include(o => o.Obra).Include(o => o.Teatro);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ObraTeatros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obraTeatro = await _context.ObrasTeatros
                .Include(o => o.Obra)
                .Include(o => o.Teatro)
                .FirstOrDefaultAsync(m => m.IdObraTeatro == id);
            if (obraTeatro == null)
            {
                return NotFound();
            }

            return View(obraTeatro);
        }

        // GET: ObraTeatros/Create
        public IActionResult Create()
        {
            ViewData["IdObra"] = new SelectList(_context.Obras, "IdObra", "Titulo");
            ViewData["IdTeatro"] = new SelectList(_context.Teatros, "IdTeatro", "IdTeatro");
            return View();
        }

        // POST: ObraTeatros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdObraTeatro,IdObra,IdTeatro")] ObraTeatro obraTeatro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obraTeatro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdObra"] = new SelectList(_context.Obras, "IdObra", "Titulo", obraTeatro.IdObra);
            ViewData["IdTeatro"] = new SelectList(_context.Teatros, "IdTeatro", "IdTeatro", obraTeatro.IdTeatro);
            return View(obraTeatro);
        }

        // GET: ObraTeatros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obraTeatro = await _context.ObrasTeatros.FindAsync(id);
            if (obraTeatro == null)
            {
                return NotFound();
            }
            ViewData["IdObra"] = new SelectList(_context.Obras, "IdObra", "Titulo", obraTeatro.IdObra);
            ViewData["IdTeatro"] = new SelectList(_context.Teatros, "IdTeatro", "IdTeatro", obraTeatro.IdTeatro);
            return View(obraTeatro);
        }

        // POST: ObraTeatros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdObraTeatro,IdObra,IdTeatro")] ObraTeatro obraTeatro)
        {
            if (id != obraTeatro.IdObraTeatro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obraTeatro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObraTeatroExists(obraTeatro.IdObraTeatro))
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
            ViewData["IdObra"] = new SelectList(_context.Obras, "IdObra", "Titulo", obraTeatro.IdObra);
            ViewData["IdTeatro"] = new SelectList(_context.Teatros, "IdTeatro", "IdTeatro", obraTeatro.IdTeatro);
            return View(obraTeatro);
        }

        // GET: ObraTeatros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obraTeatro = await _context.ObrasTeatros
                .Include(o => o.Obra)
                .Include(o => o.Teatro)
                .FirstOrDefaultAsync(m => m.IdObraTeatro == id);
            if (obraTeatro == null)
            {
                return NotFound();
            }

            return View(obraTeatro);
        }

        // POST: ObraTeatros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obraTeatro = await _context.ObrasTeatros.FindAsync(id);
            if (obraTeatro != null)
            {
                _context.ObrasTeatros.Remove(obraTeatro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObraTeatroExists(int id)
        {
            return _context.ObrasTeatros.Any(e => e.IdObraTeatro == id);
        }
    }
}
