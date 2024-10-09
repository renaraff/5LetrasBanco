using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _5LetrasBanco.Models;

namespace _5LetrasBanco.Controllers
{
    public class DuvidaController : Controller
    {
        private readonly Contexto _context;

        public DuvidaController(Contexto context)
        {
            _context = context;
        }

        // GET: Duvida
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Duvida.Include(d => d.Materias);
            return View(await contexto.ToListAsync());
        }

        // GET: Duvida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Duvida == null)
            {
                return NotFound();
            }

            var duvida = await _context.Duvida
                .Include(d => d.Materias)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duvida == null)
            {
                return NotFound();
            }

            return View(duvida);
        }

        // GET: Duvida/Create
        public IActionResult Create()
        {
            ViewData["MateriasId"] = new SelectList(_context.Materias, "Id", "Id");
            return View();
        }

        // POST: Duvida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AlunoId,MateriasId,DuvidaTexto")] Duvida duvida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(duvida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MateriasId"] = new SelectList(_context.Materias, "Id", "Id", duvida.MateriasId);
            return View(duvida);
        }

        // GET: Duvida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Duvida == null)
            {
                return NotFound();
            }

            var duvida = await _context.Duvida.FindAsync(id);
            if (duvida == null)
            {
                return NotFound();
            }
            ViewData["MateriasId"] = new SelectList(_context.Materias, "Id", "Id", duvida.MateriasId);
            return View(duvida);
        }

        // POST: Duvida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AlunoId,MateriasId,DuvidaTexto")] Duvida duvida)
        {
            if (id != duvida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duvida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuvidaExists(duvida.Id))
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
            ViewData["MateriasId"] = new SelectList(_context.Materias, "Id", "Id", duvida.MateriasId);
            return View(duvida);
        }

        // GET: Duvida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Duvida == null)
            {
                return NotFound();
            }

            var duvida = await _context.Duvida
                .Include(d => d.Materias)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duvida == null)
            {
                return NotFound();
            }

            return View(duvida);
        }

        // POST: Duvida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Duvida == null)
            {
                return Problem("Entity set 'Contexto.Duvida'  is null.");
            }
            var duvida = await _context.Duvida.FindAsync(id);
            if (duvida != null)
            {
                _context.Duvida.Remove(duvida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuvidaExists(int id)
        {
          return (_context.Duvida?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
