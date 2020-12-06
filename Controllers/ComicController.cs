using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComicShop.Models;
using Microsoft.AspNetCore.Authorization;
using ComicShop.Models.ViewModels;

namespace ComicShop.Controllers
{
    [Authorize]
    public class ComicController : Controller
    {
        private readonly ComicContex _context;

        public ComicController(ComicContex context)
        {
            _context = context;
        }

        // GET: Comic
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentfilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["TitleSortParam"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["PublisherSortParam"] = sortOrder == "Publisher" ? "publisher_desc" : "Publisher";

            var comics = from c in _context.Comics.Include(p => p.PublisherClass).Include(w => w.Writer).Include(a => a.Artist) select c;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentfilter;
            }
            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                comics = comics.Where(c => c.Title.Contains(searchString) || c.PublisherClass.PublisherName.Contains(searchString) || c.Writer.WriterName.Contains(searchString) || c.Artist.ArtistName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    comics = comics.OrderByDescending(c => c.Title);
                    break;
                case "Publisher":
                    comics = comics.OrderBy(c => c.PublisherClass.PublisherName);
                    break;
                case "publisher_desc":
                    comics = comics.OrderByDescending(c => c.PublisherClass.PublisherName);
                    break;
                default:
                    comics = comics.OrderBy(c => c.Title);
                    break;
            }

            int pageSize = 3;
            return View(await PaginatedList<Comic>.CreateAsync(comics.AsNoTracking(), pageNumber ?? 1, pageSize));
            //return View(await _context.Comics.Include(p => p.PublisherClass).Include(w => w.Writer).Include(a => a.Artist).ToListAsync());
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
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistID", "ArtistName");
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
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistID", "ArtistName", comic.ArtistID);
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
            ViewData["ArtistID"] = new SelectList(_context.Artists, "ArtistID", "ArtistName", comic.ArtistID);
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
            ViewData["ArtistID"] = new SelectList(_context.Artists, "ArtistID", "ArtistName", comic.ArtistID);
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

        /// <summary>
        /// shows writers/ artists and the publications that they have contributed to
        /// </summary>
        public IActionResult PublicationContributors()
        {
            var data = new PublicationArtistViewModel
            {
                Artists = _context.Artists.ToList(),
                Comics = _context.Comics.ToList(),
                Publishers = _context.Publishers.ToList(),
                Writers = _context.Writers.ToList()
            };

            return View(data);
        }

        private bool ComicExists(int id)
        {
            return _context.Comics.Any(e => e.ComicId == id);
        }
    }
}
