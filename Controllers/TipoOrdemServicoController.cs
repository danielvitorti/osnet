using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using osnet.Models;

namespace osnet.Controllers
{
    public class TipoOrdemServicoController : Controller
    {
        private readonly OsNetContext _context;

        public TipoOrdemServicoController(OsNetContext context)
        {
            _context = context;
        }

        // GET: TipoOrdemServico
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoOrdemServico.ToListAsync());
        }

        // GET: TipoOrdemServico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoOrdemServico = await _context.TipoOrdemServico
                .FirstOrDefaultAsync(m => m.id == id);
            if (tipoOrdemServico == null)
            {
                return NotFound();
            }

            return View(tipoOrdemServico);
        }

        // GET: TipoOrdemServico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoOrdemServico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome")] TipoOrdemServico tipoOrdemServico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoOrdemServico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoOrdemServico);
        }

        // GET: TipoOrdemServico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoOrdemServico = await _context.TipoOrdemServico.FindAsync(id);
            if (tipoOrdemServico == null)
            {
                return NotFound();
            }
            return View(tipoOrdemServico);
        }

        // POST: TipoOrdemServico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome")] TipoOrdemServico tipoOrdemServico)
        {
            if (id != tipoOrdemServico.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoOrdemServico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoOrdemServicoExists(tipoOrdemServico.id))
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
            return View(tipoOrdemServico);
        }

        // GET: TipoOrdemServico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoOrdemServico = await _context.TipoOrdemServico
                .FirstOrDefaultAsync(m => m.id == id);
            if (tipoOrdemServico == null)
            {
                return NotFound();
            }

            return View(tipoOrdemServico);
        }

        // POST: TipoOrdemServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoOrdemServico = await _context.TipoOrdemServico.FindAsync(id);
            _context.TipoOrdemServico.Remove(tipoOrdemServico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoOrdemServicoExists(int id)
        {
            return _context.TipoOrdemServico.Any(e => e.id == id);
        }
    }
}
