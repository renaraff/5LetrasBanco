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
    public class ComentarioController : Controller
    {
        private readonly Contexto _context;

        public ComentarioController(Contexto context)
        {
            _context = context;
        }

        // GET: Comentario
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Comentario.Include(c => c.Conteudo).Include(c => c.Duvida).Include(c => c.Professor);
            return View(await contexto.ToListAsync());
        }

        // GET: Comentario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comentario == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentario
                .Include(c => c.Conteudo)
                .Include(c => c.Duvida)
                .Include(c => c.Professor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // GET: Comentario/Create
        public IActionResult Create()
        {
            ViewData["ConteudoId"] = new SelectList(_context.Conteudo, "Id", "Id");
            ViewData["DuvidaId"] = new SelectList(_context.Duvida, "Id", "Id");
            ViewData["ProfessorId"] = new SelectList(_context.Professor, "Id", "Id");
            return View();
        }

        // POST: Comentario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConteudoId,DuvidaId,ProfessorId,AlunoId,ComentarioTexto")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comentario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConteudoId"] = new SelectList(_context.Conteudo, "Id", "Id", comentario.ConteudoId);
            ViewData["DuvidaId"] = new SelectList(_context.Duvida, "Id", "Id", comentario.DuvidaId);
            ViewData["ProfessorId"] = new SelectList(_context.Professor, "Id", "Id", comentario.ProfessorId);
            return View(comentario);
        }

        // GET: Comentario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comentario == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentario.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }
            ViewData["ConteudoId"] = new SelectList(_context.Conteudo, "Id", "Id", comentario.ConteudoId);
            ViewData["DuvidaId"] = new SelectList(_context.Duvida, "Id", "Id", comentario.DuvidaId);
            ViewData["ProfessorId"] = new SelectList(_context.Professor, "Id", "Id", comentario.ProfessorId);
            return View(comentario);
        }

        // POST: Comentario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConteudoId,DuvidaId,ProfessorId,AlunoId,ComentarioTexto")] Comentario comentario)
        {
            if (id != comentario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comentario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComentarioExists(comentario.Id))
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
            ViewData["ConteudoId"] = new SelectList(_context.Conteudo, "Id", "Id", comentario.ConteudoId);
            ViewData["DuvidaId"] = new SelectList(_context.Duvida, "Id", "Id", comentario.DuvidaId);
            ViewData["ProfessorId"] = new SelectList(_context.Professor, "Id", "Id", comentario.ProfessorId);
            return View(comentario);
        }

        // GET: Comentario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comentario == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentario
                .Include(c => c.Conteudo)
                .Include(c => c.Duvida)
                .Include(c => c.Professor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // POST: Comentario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comentario == null)
            {
                return Problem("Entity set 'Contexto.Comentario'  is null.");
            }
            var comentario = await _context.Comentario.FindAsync(id);
            if (comentario != null)
            {
                _context.Comentario.Remove(comentario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComentarioExists(int id)
        {
          return (_context.Comentario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
