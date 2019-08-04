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
    public class ServicesTypesController : Controller
    {
        private readonly MedicalEquipmentContext _context;

        public ServicesTypesController(MedicalEquipmentContext context)
        {
            _context = context;
        }

        // GET: Admin/ServicesTypes
        public async Task<IActionResult> Index()
        {
            var medicalEquipmentContext = _context.ServicesType.Include(s => s.Service);
            return View(await medicalEquipmentContext.ToListAsync());
        }

        // GET: Admin/ServicesTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicesType = await _context.ServicesType
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.ServicesType_Id == id);
            if (servicesType == null)
            {
                return NotFound();
            }

            return View(servicesType);
        }

        // GET: Admin/ServicesTypes/Create
        public IActionResult Create()
        {
            ViewData["Service_Id"] = new SelectList(_context.Service, "Service_Id", "Description");
            return View();
        }

        // POST: Admin/ServicesTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServicesType_Id,Tittle,Service_Id")] ServicesType servicesType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicesType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Service_Id"] = new SelectList(_context.Service, "Service_Id", "Description", servicesType.Service_Id);
            return View(servicesType);
        }

        // GET: Admin/ServicesTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicesType = await _context.ServicesType.FindAsync(id);
            if (servicesType == null)
            {
                return NotFound();
            }
            ViewData["Service_Id"] = new SelectList(_context.Service, "Service_Id", "Description", servicesType.Service_Id);
            return View(servicesType);
        }

        // POST: Admin/ServicesTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServicesType_Id,Tittle,Service_Id")] ServicesType servicesType)
        {
            if (id != servicesType.ServicesType_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicesType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicesTypeExists(servicesType.ServicesType_Id))
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
            ViewData["Service_Id"] = new SelectList(_context.Service, "Service_Id", "Description", servicesType.Service_Id);
            return View(servicesType);
        }

        // GET: Admin/ServicesTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicesType = await _context.ServicesType
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.ServicesType_Id == id);
            if (servicesType == null)
            {
                return NotFound();
            }

            return View(servicesType);
        }

        // POST: Admin/ServicesTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicesType = await _context.ServicesType.FindAsync(id);
            _context.ServicesType.Remove(servicesType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicesTypeExists(int id)
        {
            return _context.ServicesType.Any(e => e.ServicesType_Id == id);
        }
    }
}
