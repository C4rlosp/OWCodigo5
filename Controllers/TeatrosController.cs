﻿using System;
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
    public class TeatrosController : Controller
    {
        private readonly AppDbContext _context;

        public TeatrosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Teatros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teatros.ToListAsync());
        }

        // GET: Teatros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teatro = await _context.Teatros
                .FirstOrDefaultAsync(m => m.IdTeatro == id);
            if (teatro == null)
            {
                return NotFound();
            }

            return View(teatro);
        }

        // GET: Teatros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teatros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTeatro,Nombre,Localidad")] Teatro teatro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teatro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teatro);
        }

        // GET: Teatros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teatro = await _context.Teatros.FindAsync(id);
            if (teatro == null)
            {
                return NotFound();
            }
            return View(teatro);
        }

        // POST: Teatros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTeatro,Nombre,Localidad")] Teatro teatro)
        {
            if (id != teatro.IdTeatro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teatro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeatroExists(teatro.IdTeatro))
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
            return View(teatro);
        }

        // GET: Teatros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teatro = await _context.Teatros
                .FirstOrDefaultAsync(m => m.IdTeatro == id);
            if (teatro == null)
            {
                return NotFound();
            }

            return View(teatro);
        }

        // POST: Teatros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teatro = await _context.Teatros.FindAsync(id);
            if (teatro != null)
            {
                _context.Teatros.Remove(teatro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeatroExists(int id)
        {
            return _context.Teatros.Any(e => e.IdTeatro == id);
        }
    }
}
