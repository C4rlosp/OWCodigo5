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
    public class DirectoresController : Controller
    {
        private readonly AppDbContext _context;

        public DirectoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Directores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Directores.ToListAsync());
        }

        // GET: Directores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.Directores
                .FirstOrDefaultAsync(m => m.IdDirector == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // GET: Directores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Directores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDirector,Nombre,ObraId")] Director director)
        {
            if (ModelState.IsValid)
            {
                _context.Add(director);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }

        // GET: Directores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.Directores.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }

        // POST: Directores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDirector,Nombre,ObraId")] Director director)
        {
            if (id != director.IdDirector)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(director);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectorExists(director.IdDirector))
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
            return View(director);
        }

        // GET: Directores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.Directores
                .FirstOrDefaultAsync(m => m.IdDirector == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // POST: Directores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var director = await _context.Directores.FindAsync(id);
            if (director != null)
            {
                _context.Directores.Remove(director);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectorExists(int id)
        {
            return _context.Directores.Any(e => e.IdDirector == id);
        }
    }
}
