using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComicShop.Models;

namespace ComicShop.Controllers
{
    public class ComicController : Controller
    {
        private readonly ComicContex _context;

        public ComicController(ComicContex context)
        {
            _context = context;
        }

        // GET: Comic
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comics.Include(p => p.PublisherClass).Include(w => w.Writer).Include(a => a.Artist).ToListAsync());
        }

        // GET: Comic/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comic = await _context.Comics
                .Include(i => i.PublisherClass).Include(w => w.Writer).Include(a => a.Artist)
                .FirstOrDefaultAsync(m => m.ComicId == id);
            if (comic == null)
            {
                return NotFound();
            }

            return View(comic);
        }

        // GET: Comic/Create
        public IActionResult Create()
        {
            ViewData["WriterID"] = new SelectList(_context.Writers, "WriterID", "WriterName");
            ViewData["WriterID"] = new SelectList(_context.Artists, "ArtistID", "ArtistName");
            ViewData["PublisherID"] = new SelectList(_context.Publishers, "PublisherID", "PublisherName");
            return View();
        }

        // POST: Comic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComicId,Title,ArtistID,WriterID,Year,Rating,PublisherID")] Comic comic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WriterID"] = new SelectList(_context.Writers, "WriterID", "WriterName", comic.WriterID);
            ViewData["WriterID"] = new SelectList(_context.Artists, "ArtistID", "ArtistName", comic.ArtistID);
            ViewData["PublisherID"] = new SelectList(_context.Publishers, "PublisherID", "PublisherName", comic.PublisherID);
            return View(comic);
        }

        // GET: Comic/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comic = await _context.Comics.FindAsync(id);
            if (comic == null)
            {
                return NotFound();
            }
            ViewData["WriterID"] = new SelectList(_context.Writers, "WriterID", "WriterName", comic.WriterID);
            ViewData["WriterID"] = new SelectList(_context.Artists, "ArtistID", "ArtistName", comic.ArtistID);
            ViewData["PublisherID"] = new SelectList(_context.Publishers, "PublisherID", "PublisherName", comic.PublisherID);
            return View(comic);
        }

        // POST: Comic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComicId,Title,WriterID,ArtistID,Year,Rating,PublisherID")] Comic comic)
        {
            if (id != comic.ComicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComicExists(comic.ComicId))
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
            ViewData["WriterID"] = new SelectList(_context.Writers, "WriterID", "WriterName", comic.WriterID);
            ViewData["WriterID"] = new SelectList(_context.Artists, "ArtistID", "ArtistName", comic.ArtistID);
            ViewData["PublisherID"] = new SelectList(_context.Publishers, "PublisherID", "PublisherName", comic.PublisherID);
            return View(comic);
        }

        // GET: Comic/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comic = await _context.Comics
                .Include(i => i.PublisherClass).Include(w => w.Writer).Include(a => a.Artist)
                .FirstOrDefaultAsync(m => m.ComicId == id);
            if (comic == null)
            {
                return NotFound();
            }

            return View(comic);
        }

        // POST: Comic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comic = await _context.Comics.FindAsync(id);
            _context.Comics.Remove(comic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComicExists(int id)
        {
            return _context.Comics.Any(e => e.ComicId == id);
        }
    }
}
