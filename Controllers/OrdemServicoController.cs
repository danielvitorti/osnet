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
    public class OrdemServicoController : Controller
    {
        private readonly OsNetContext _context;

        public OrdemServicoController(OsNetContext context)
        {
            _context = context;
        }

        // GET: OrdemServico
        public async Task<IActionResult> Index()
        {
            var osNetContext = _context.OrdemServico.Include(o => o.cliente).Include(o => o.servico).Include(o => o.status).Include(o => o.tipoOrdemServico);
            return View(await osNetContext.ToListAsync());
        }

        // GET: OrdemServico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordemServico = await _context.OrdemServico
                .Include(o => o.cliente)
                .Include(o => o.servico)
                .Include(o => o.status)
                .Include(o => o.tipoOrdemServico)
                .FirstOrDefaultAsync(m => m.id == id);
            if (ordemServico == null)
            {
                return NotFound();
            }

            return View(ordemServico);
        }

        // GET: OrdemServico/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "id", "nome");
            ViewData["ServicoId"] = new SelectList(_context.Servico, "id", "nome");
            ViewData["StatusId"] = new SelectList(_context.Status, "id", "nome");
            ViewData["TipoOrdemServicoId"] = new SelectList(_context.TipoOrdemServico, "id", "nome");
            return View();
        }

        // POST: OrdemServico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,titulo,resumo,justificativa,descricao,resolucao,ClienteId,TipoOrdemServicoId,ServicoId,StatusId")] OrdemServico ordemServico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordemServico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "id", "nome", ordemServico.ClienteId);
            ViewData["ServicoId"] = new SelectList(_context.Servico, "id", "nome", ordemServico.ServicoId);
            ViewData["StatusId"] = new SelectList(_context.Status, "id", "nome", ordemServico.StatusId);
            ViewData["TipoOrdemServicoId"] = new SelectList(_context.TipoOrdemServico, "id", "nome", ordemServico.TipoOrdemServicoId);
            return View(ordemServico);
        }

        // GET: OrdemServico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordemServico = await _context.OrdemServico.FindAsync(id);
            if (ordemServico == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "id", "nome", ordemServico.ClienteId);
            ViewData["ServicoId"] = new SelectList(_context.Servico, "id", "nome", ordemServico.ServicoId);
            ViewData["StatusId"] = new SelectList(_context.Status, "id", "nome", ordemServico.StatusId);
            ViewData["TipoOrdemServicoId"] = new SelectList(_context.TipoOrdemServico, "id", "nome", ordemServico.TipoOrdemServicoId);
            return View(ordemServico);
        }

        // POST: OrdemServico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,titulo,resumo,justificativa,descricao,resolucao,ClienteId,TipoOrdemServicoId,ServicoId,StatusId")] OrdemServico ordemServico)
        {
            if (id != ordemServico.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordemServico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdemServicoExists(ordemServico.id))
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

            // Combos ---------
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "id", "nome", ordemServico.ClienteId);
            ViewData["ServicoId"] = new SelectList(_context.Servico, "id", "nome", ordemServico.ServicoId);
            ViewData["StatusId"] = new SelectList(_context.Status, "id", "nome", ordemServico.StatusId);
            ViewData["TipoOrdemServicoId"] = new SelectList(_context.TipoOrdemServico, "id", "nome", ordemServico.TipoOrdemServicoId);
            // Combos ---------
            
            return View(ordemServico);
        }

        // GET: OrdemServico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordemServico = await _context.OrdemServico
                .Include(o => o.cliente)
                .Include(o => o.servico)
                .Include(o => o.status)
                .Include(o => o.tipoOrdemServico)
                .FirstOrDefaultAsync(m => m.id == id);
            if (ordemServico == null)
            {
                return NotFound();
            }

            return View(ordemServico);
        }

        // POST: OrdemServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordemServico = await _context.OrdemServico.FindAsync(id);
            _context.OrdemServico.Remove(ordemServico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdemServicoExists(int id)
        {
            return _context.OrdemServico.Any(e => e.id == id);
        }
    }
}
