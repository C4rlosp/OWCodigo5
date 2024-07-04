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
    public class ActoresController : Controller
    {
        private readonly AppDbContext _context;

        public ActoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Actores
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Actores.Include(a => a.Obra);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Actores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actores
                .Include(a => a.Obra)
                .FirstOrDefaultAsync(m => m.IdActor == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // GET: Actores/Create
        public IActionResult Create()
        {
            ViewData["IdObra"] = new SelectList(_context.Obras, "IdObra", "Titulo");
            return View();
        }

        // POST: Actores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdActor,Nombre,Direccion,Nacionalidad,Edad,Personaje,RolEspecifico,IdObra")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdObra"] = new SelectList(_context.Obras, "IdObra", "Titulo", actor.IdObra);
            return View(actor);
        }

        // GET: Actores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actores.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            ViewData["IdObra"] = new SelectList(_context.Obras, "IdObra", "Titulo", actor.IdObra);
            return View(actor);
        }

        // POST: Actores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdActor,Nombre,Direccion,Nacionalidad,Edad,Personaje,RolEspecifico,IdObra")] Actor actor)
        {
            if (id != actor.IdActor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorExists(actor.IdActor))
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
            ViewData["IdObra"] = new SelectList(_context.Obras, "IdObra", "Titulo", actor.IdObra);
            return View(actor);
        }

        // GET: Actores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actores
                .Include(a => a.Obra)
                .FirstOrDefaultAsync(m => m.IdActor == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // POST: Actores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actor = await _context.Actores.FindAsync(id);
            if (actor != null)
            {
                _context.Actores.Remove(actor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorExists(int id)
        {
            return _context.Actores.Any(e => e.IdActor == id);
        }
    }
}
