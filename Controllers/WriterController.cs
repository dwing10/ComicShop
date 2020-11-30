using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComicShop.Models;
using Microsoft.AspNetCore.Authorization;

namespace ComicShop.Controllers
{
    [Authorize]
    public class WriterController : Controller
    {
        private readonly ComicContex _context;

        public WriterController(ComicContex context)
        {
            _context = context;
        }

        // GET: Writer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Writers.ToListAsync());
        }

        // GET: Writer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writer = await _context.Writers
                .FirstOrDefaultAsync(m => m.WriterID == id);
            if (writer == null)
            {
                return NotFound();
            }

            return View(writer);
        }

        // GET: Writer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Writer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WriterID,WriterName")] Writer writer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(writer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(writer);
        }

        // GET: Writer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writer = await _context.Writers.FindAsync(id);
            if (writer == null)
            {
                return NotFound();
            }
            return View(writer);
        }

        // POST: Writer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WriterID,WriterName")] Writer writer)
        {
            if (id != writer.WriterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(writer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WriterExists(writer.WriterID))
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
            return View(writer);
        }

        // GET: Writer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writer = await _context.Writers
                .FirstOrDefaultAsync(m => m.WriterID == id);
            if (writer == null)
            {
                return NotFound();
            }

            return View(writer);
        }

        // POST: Writer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var writer = await _context.Writers.FindAsync(id);
            _context.Writers.Remove(writer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WriterExists(int id)
        {
            return _context.Writers.Any(e => e.WriterID == id);
        }
    }
}
