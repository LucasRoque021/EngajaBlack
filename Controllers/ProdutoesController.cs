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
    public class ProdutoesController : Controller
    {
        private readonly Context _context;

        public ProdutoesController(Context context)
        {
            _context = context;
        }

        // GET: Produtoes
        public async Task<IActionResult> Index()
        {
            var context = _context.Produto.Include(p => p.Fornecedor).Include(p => p.Pedido);
            return View(await context.ToListAsync());
        }

        // GET: Produtoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.Fornecedor)
                .Include(p => p.Pedido)
                .FirstOrDefaultAsync(m => m.CodigoProduto == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtoes/Create
        public IActionResult Create()
        {
            ViewData["CodigoFornecedor"] = new SelectList(_context.Fornecedor, "CodigoFornecedor", "CEP");
            ViewData["NumPedido"] = new SelectList(_context.Pedido, "NumPedido", "NumPedido");
            return View();
        }

        // POST: Produtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoProduto,NomeProduto,ValorProduto,Categoria,NumPedido,CodigoEmpreendedor,CodigoFornecedor")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoFornecedor"] = new SelectList(_context.Fornecedor, "CodigoFornecedor", "CEP", produto.CodigoFornecedor);
            ViewData["NumPedido"] = new SelectList(_context.Pedido, "NumPedido", "NumPedido", produto.NumPedido);
            return View(produto);
        }

        // GET: Produtoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["CodigoFornecedor"] = new SelectList(_context.Fornecedor, "CodigoFornecedor", "CEP", produto.CodigoFornecedor);
            ViewData["NumPedido"] = new SelectList(_context.Pedido, "NumPedido", "NumPedido", produto.NumPedido);
            return View(produto);
        }

        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoProduto,NomeProduto,ValorProduto,Categoria,NumPedido,CodigoEmpreendedor,CodigoFornecedor")] Produto produto)
        {
            if (id != produto.CodigoProduto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.CodigoProduto))
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
            ViewData["CodigoFornecedor"] = new SelectList(_context.Fornecedor, "CodigoFornecedor", "CEP", produto.CodigoFornecedor);
            ViewData["NumPedido"] = new SelectList(_context.Pedido, "NumPedido", "NumPedido", produto.NumPedido);
            return View(produto);
        }

        // GET: Produtoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .Include(p => p.Fornecedor)
                .Include(p => p.Pedido)
                .FirstOrDefaultAsync(m => m.CodigoProduto == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.CodigoProduto == id);
        }
    }
}
