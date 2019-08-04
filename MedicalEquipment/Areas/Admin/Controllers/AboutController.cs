using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalEquipment.Web.Models;

namespace MedicalEquipment.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly MedicalEquipmentContext _context;

        public AboutController(MedicalEquipmentContext context)
        {
            _context = context;
        }

        // GET: Admin/About
        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutUs.ToListAsync());
        }

        // GET: Admin/About/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = await _context.AboutUs
                .FirstOrDefaultAsync(m => m.About_Id == id);
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }

        // GET: Admin/About/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/About/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("About_Id,Summary,Describtion")] About about)
        {
            if (ModelState.IsValid)
            {
                _context.Add(about);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }

        // GET: Admin/About/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = await _context.AboutUs.FindAsync(id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }

        // POST: Admin/About/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("About_Id,Summary,Describtion")] About about)
        {
            if (id != about.About_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(about);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutExists(about.About_Id))
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
            return View(about);
        }

        // GET: Admin/About/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about = await _context.AboutUs
                .FirstOrDefaultAsync(m => m.About_Id == id);
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }

        // POST: Admin/About/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var about = await _context.AboutUs.FindAsync(id);
            _context.AboutUs.Remove(about);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutExists(int id)
        {
            return _context.AboutUs.Any(e => e.About_Id == id);
        }
    }
}
