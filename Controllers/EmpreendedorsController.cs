using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EngajaBlack1.Models;

namespace EngajaBlack1.Controllers
{
    public class EmpreendedorsController : Controller
    {
        private readonly Context _context;

        public EmpreendedorsController(Context context)
        {
            _context = context;
        }

        // GET: Empreendedors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empreendedor.ToListAsync());
        }

        // GET: Empreendedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empreendedor = await _context.Empreendedor
                .FirstOrDefaultAsync(m => m.CodigoEmpreendedor == id);
            if (empreendedor == null)
            {
                return NotFound();
            }

            return View(empreendedor);
        }

        // GET: Empreendedors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empreendedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoEmpreendedor,NomeLoja,CNPJ,Ramo,Cidade,Comunidade,Estado,HoraAbertura,HoraFechamento,Nome,CPF,Email,Password,Telefone,Endereco,CEP")] Empreendedor empreendedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empreendedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empreendedor);
        }

        // GET: Empreendedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empreendedor = await _context.Empreendedor.FindAsync(id);
            if (empreendedor == null)
            {
                return NotFound();
            }
            return View(empreendedor);
        }

        // POST: Empreendedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoEmpreendedor,NomeLoja,CNPJ,Ramo,Cidade,Comunidade,Estado,HoraAbertura,HoraFechamento,Nome,CPF,Email,Password,Telefone,Endereco,CEP")] Empreendedor empreendedor)
        {
            if (id != empreendedor.CodigoEmpreendedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empreendedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpreendedorExists(empreendedor.CodigoEmpreendedor))
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
            return View(empreendedor);
        }

        // GET: Empreendedors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empreendedor = await _context.Empreendedor
                .FirstOrDefaultAsync(m => m.CodigoEmpreendedor == id);
            if (empreendedor == null)
            {
                return NotFound();
            }

            return View(empreendedor);
        }

        // POST: Empreendedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empreendedor = await _context.Empreendedor.FindAsync(id);
            _context.Empreendedor.Remove(empreendedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpreendedorExists(int id)
        {
            return _context.Empreendedor.Any(e => e.CodigoEmpreendedor == id);
        }
    }
}
