using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserProfile.Data;
using UserProfile.Models;

namespace UserProfile.Controllers
{
    public class SocialDetailsController : Controller
    {
        private readonly UserProfileContext _context;

        public SocialDetailsController(UserProfileContext context)
        {
            _context = context;
        }

        // GET: SocialDetails
        public async Task<IActionResult> Index(string searchStringSocial)
        {
            var socialDetails = from m in _context.SocialDetails
                                select m;

            if (!String.IsNullOrEmpty(searchStringSocial))
            {
                socialDetails = socialDetails.Where(s => s.email.Contains(searchStringSocial));
            }

            return View(await socialDetails.ToListAsync());
        }

        // GET: SocialDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialDetails = await _context.SocialDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialDetails == null)
            {
                return NotFound();
            }

            return View(socialDetails);
        }

        // GET: SocialDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SocialDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,email,profileImgUrl,friendsEmail")] SocialDetails socialDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socialDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socialDetails);
        }

        // GET: SocialDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialDetails = await _context.SocialDetails.FindAsync(id);
            if (socialDetails == null)
            {
                return NotFound();
            }
            return View(socialDetails);
        }

        // POST: SocialDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,email,profileImgUrl,friendsEmail")] SocialDetails socialDetails)
        {
            if (id != socialDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialDetailsExists(socialDetails.Id))
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
            return View(socialDetails);
        }

        // GET: SocialDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialDetails = await _context.SocialDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialDetails == null)
            {
                return NotFound();
            }

            return View(socialDetails);
        }

        // POST: SocialDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socialDetails = await _context.SocialDetails.FindAsync(id);
            _context.SocialDetails.Remove(socialDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialDetailsExists(int id)
        {
            return _context.SocialDetails.Any(e => e.Id == id);
        }
    }
}
