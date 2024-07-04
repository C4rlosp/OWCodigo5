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
    public class CarritosController : Controller
    {
        private readonly AppDbContext _context;

        public CarritosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Carritos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Carritos.Include(c => c.Asiento).Include(c => c.ObraTeatro).Include(c => c.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Carritos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos
                .Include(c => c.Asiento)
                .Include(c => c.ObraTeatro)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.IdCarrito == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // GET: Carritos/Create
        public IActionResult Create()
        {
            ViewData["IdAsiento"] = new SelectList(_context.Asientos, "IdAsiento", "TipoDeAsiento");
            ViewData["IdObraTeatro"] = new SelectList(_context.ObrasTeatros, "IdObraTeatro", "IdObraTeatro");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "Contrasena");
            return View();
        }

        // POST: Carritos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCarrito,NumeroTicket,IdObraTeatro,IdAsiento,IdUsuario,NumeroAsiento,Fila")] Carrito carrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAsiento"] = new SelectList(_context.Asientos, "IdAsiento", "TipoDeAsiento", carrito.IdAsiento);
            ViewData["IdObraTeatro"] = new SelectList(_context.ObrasTeatros, "IdObraTeatro", "IdObraTeatro", carrito.IdObraTeatro);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "Contrasena", carrito.IdUsuario);
            return View(carrito);
        }

        // GET: Carritos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos.FindAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }
            ViewData["IdAsiento"] = new SelectList(_context.Asientos, "IdAsiento", "TipoDeAsiento", carrito.IdAsiento);
            ViewData["IdObraTeatro"] = new SelectList(_context.ObrasTeatros, "IdObraTeatro", "IdObraTeatro", carrito.IdObraTeatro);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "Contrasena", carrito.IdUsuario);
            return View(carrito);
        }

        // POST: Carritos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCarrito,NumeroTicket,IdObraTeatro,IdAsiento,IdUsuario,NumeroAsiento,Fila")] Carrito carrito)
        {
            if (id != carrito.IdCarrito)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarritoExists(carrito.IdCarrito))
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
            ViewData["IdAsiento"] = new SelectList(_context.Asientos, "IdAsiento", "TipoDeAsiento", carrito.IdAsiento);
            ViewData["IdObraTeatro"] = new SelectList(_context.ObrasTeatros, "IdObraTeatro", "IdObraTeatro", carrito.IdObraTeatro);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "Contrasena", carrito.IdUsuario);
            return View(carrito);
        }

        // GET: Carritos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos
                .Include(c => c.Asiento)
                .Include(c => c.ObraTeatro)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.IdCarrito == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // POST: Carritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrito = await _context.Carritos.FindAsync(id);
            if (carrito != null)
            {
                _context.Carritos.Remove(carrito);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarritoExists(int id)
        {
            return _context.Carritos.Any(e => e.IdCarrito == id);
        }
    }
}
