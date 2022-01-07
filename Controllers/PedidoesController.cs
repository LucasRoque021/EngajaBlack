﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EngajaBlack1.Models;

namespace EngajaBlack1.Controllers
{
    public class PedidoesController : Controller
    {
        private readonly Context _context;

        public PedidoesController(Context context)
        {
            _context = context;
        }

        // GET: Pedidoes
        public async Task<IActionResult> Index()
        {
            var context = _context.Pedido.Include(p => p.Cliente).Include(p => p.Empreendedor);
            return View(await context.ToListAsync());
        }

        // GET: Pedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.Empreendedor)
                .FirstOrDefaultAsync(m => m.NumPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidoes/Create
        public IActionResult Create()
        {
            ViewData["CodigoCliente"] = new SelectList(_context.Cliente, "CodigoCliente", "CEP");
            ViewData["CodigoEmpreendedor"] = new SelectList(_context.Empreendedor, "CodigoEmpreendedor", "CEP");
            return View();
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumPedido,PrevisaoEntrega,DataPedido,ValorPedido,CodigoCliente,CodigoEmpreendedor")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoCliente"] = new SelectList(_context.Cliente, "CodigoCliente", "CEP", pedido.CodigoCliente);
            ViewData["CodigoEmpreendedor"] = new SelectList(_context.Empreendedor, "CodigoEmpreendedor", "CEP", pedido.CodigoEmpreendedor);
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["CodigoCliente"] = new SelectList(_context.Cliente, "CodigoCliente", "CEP", pedido.CodigoCliente);
            ViewData["CodigoEmpreendedor"] = new SelectList(_context.Empreendedor, "CodigoEmpreendedor", "CEP", pedido.CodigoEmpreendedor);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumPedido,PrevisaoEntrega,DataPedido,ValorPedido,CodigoCliente,CodigoEmpreendedor")] Pedido pedido)
        {
            if (id != pedido.NumPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.NumPedido))
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
            ViewData["CodigoCliente"] = new SelectList(_context.Cliente, "CodigoCliente", "CEP", pedido.CodigoCliente);
            ViewData["CodigoEmpreendedor"] = new SelectList(_context.Empreendedor, "CodigoEmpreendedor", "CEP", pedido.CodigoEmpreendedor);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.Empreendedor)
                .FirstOrDefaultAsync(m => m.NumPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.NumPedido == id);
        }
    }
}
