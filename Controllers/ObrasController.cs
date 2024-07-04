using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OWCodigo5.Data;
using OWCodigo5.Models;

namespace OWCodigo5.Controllers
{
    public class ObrasController : Controller
    {
        private readonly AppDbContext _context;
        //private readonly IWebHostEnvironment _environment;

        public ObrasController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            //_environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Obras.Include(o => o.Genero);
            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.Obras
                .Include(o => o.Genero)
                .FirstOrDefaultAsync(m => m.IdObra == id);

            if (obra == null)
            {
                return NotFound();
            }

            return View(obra);
        }

        public IActionResult Create()
        {
            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdObra,Titulo,IdGenero,FechaPresentacion")] Obra obra/*, IFormFile imagenFile*/)
        {
            if (ModelState.IsValid)
            {
                // if (imagenFile != null)
                // {
                //     obra.ImagenUrl = await UploadImage(imagenFile);
                // }

                _context.Add(obra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "Nombre", obra.IdGenero);
            return View(obra);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.Obras.FindAsync(id);
            if (obra == null)
            {
                return NotFound();
            }

            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "Nombre", obra.IdGenero);
            return View(obra);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdObra,Titulo,IdGenero,FechaPresentacion"/*,ImagenUrl*/)] Obra obra/*, IFormFile imagenFile*/)
        {
            if (id != obra.IdObra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // if (imagenFile != null)
                    // {
                    //     obra.ImagenUrl = await UploadImage(imagenFile);
                    // }

                    _context.Update(obra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObraExists(obra.IdObra))
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
            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "Nombre", obra.IdGenero);
            return View(obra);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obra = await _context.Obras
                .Include(o => o.Genero)
                .FirstOrDefaultAsync(m => m.IdObra == id);
            if (obra == null)
            {
                return NotFound();
            }

            return View(obra);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obra = await _context.Obras.FindAsync(id);
            if (obra != null)
            {
                _context.Obras.Remove(obra);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ObraExists(int id)
        {
            return _context.Obras.Any(e => e.IdObra == id);
        }

        // private async Task<string> UploadImage(IFormFile file)
        // {
        //     if (file == null || file.Length == 0)
        //         return null;

        //     // Validar que el tipo de archivo sea PNG
        //     if (!file.ContentType.Equals("image/png", StringComparison.OrdinalIgnoreCase))
        //     {
        //         throw new InvalidOperationException("Solo se permiten archivos PNG.");
        //     }

        //     var uploads = Path.Combine(_environment.WebRootPath, "uploads");

        //     // Asegurarte de que el directorio de carga exista
        //     if (!Directory.Exists(uploads))
        //     {
        //         Directory.CreateDirectory(uploads);
        //     }

        //     var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        //     var filePath = Path.Combine(uploads, fileName);

        //     try
        //     {
        //         using (var fileStream = new FileStream(filePath, FileMode.Create))
        //         {
        //             await file.CopyToAsync(fileStream);
        //         }
        //         Console.WriteLine("Imagen cargada exitosamente: " + filePath); // Registro de depuración
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine("Error al cargar la imagen: " + ex.Message); // Registro de depuración
        //         throw;
        //     }

        //     return "/uploads/" + fileName;
        // }
    }
}
