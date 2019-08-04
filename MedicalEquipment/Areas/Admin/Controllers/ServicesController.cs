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
    public class ServicesController : Controller
    {
        private readonly MedicalEquipmentContext _context;

        public ServicesController(MedicalEquipmentContext context)
        {
            _context = context;
        }

        // GET: Admin/Services
        public async Task<IActionResult> Index()
        {
            var medicalEquipmentContext = _context.Service.Include(s => s.Language);
            return View(await medicalEquipmentContext.ToListAsync());
        }

        // GET: Admin/Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service
                .Include(s => s.Language)
                .FirstOrDefaultAsync(m => m.Service_Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Admin/Services/Create
        public IActionResult Create()
        {
            ViewData["Lang_Id"] = new SelectList(_context.Languages, "Lang_Id", "LanguageTitle");
            return View();
        }

        // POST: Admin/Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Service_Id,Tittle,Description,ImageName,Lang_Id")] Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Lang_Id"] = new SelectList(_context.Languages, "Lang_Id", "LanguageTitle", service.Lang_Id);
            return View(service);
        }

        // GET: Admin/Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            ViewData["Lang_Id"] = new SelectList(_context.Languages, "Lang_Id", "LanguageTitle", service.Lang_Id);
            return View(service);
        }

        // POST: Admin/Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Service_Id,Tittle,Description,ImageName,Lang_Id")] Service service)
        {
            if (id != service.Service_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.Service_Id))
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
            ViewData["Lang_Id"] = new SelectList(_context.Languages, "Lang_Id", "LanguageTitle", service.Lang_Id);
            return View(service);
        }

        // GET: Admin/Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service
                .Include(s => s.Language)
                .FirstOrDefaultAsync(m => m.Service_Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Admin/Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.Service.FindAsync(id);
            _context.Service.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
            return _context.Service.Any(e => e.Service_Id == id);
        }
    }
}
