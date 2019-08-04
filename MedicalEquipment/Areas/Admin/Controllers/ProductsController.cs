using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalEquipment.Web.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MedicalEquipment.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly MedicalEquipmentContext _context;

        public ProductsController(MedicalEquipmentContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
          //  var medicalEquipmentContext = _context.Products.Include(p => p.Category).Include(p => p.Language);
            var model = _context.Products.ToList();
            if (model.Count == 0)
            {
                TempData["msg"] = "اطلاعاتی برای نمایش وجود ندارد";
                return View();
            }
            else
            {
                return View(await _context.Products.ToListAsync());
            }
           
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Language)
                .FirstOrDefaultAsync(m => m.Product_Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["Category_Id"] = new SelectList(_context.Categories, "Category_Id", "CategoryTitle");
            ViewData["Lang_Id"] = new SelectList(_context.Languages, "Lang_Id", "LanguageTitle");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Product_Id,ProductName,Description,ImageName,Price,Status,Lang_Id,Category_Id")] Product product,IFormFile imgProduct)
        {
            if (ModelState.IsValid)
            {
                if(imgProduct!=null)
                {
                    product.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgProduct.FileName);
                    string savePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ProductImages", product.ImageName);
                    using(var stream=new FileStream(savePath, FileMode.Create))
                    {
                        imgProduct.CopyTo(stream);
                    }
                }
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category_Id"] = new SelectList(_context.Categories, "Category_Id", "CategoryTitle", product.Category_Id);
            ViewData["Lang_Id"] = new SelectList(_context.Languages, "Lang_Id", "LanguageTitle", product.Lang_Id);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["Category_Id"] = new SelectList(_context.Categories, "Category_Id", "CategoryTitle", product.Category_Id);
            ViewData["Lang_Id"] = new SelectList(_context.Languages, "Lang_Id", "LanguageTitle", product.Lang_Id);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Product_Id,ProductName,Description,ImageName,Price,Status,Lang_Id,Category_Id")] Product product)
        {
            if (id != product.Product_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Product_Id))
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
            ViewData["Category_Id"] = new SelectList(_context.Categories, "Category_Id", "CategoryTitle", product.Category_Id);
            ViewData["Lang_Id"] = new SelectList(_context.Languages, "Lang_Id", "LanguageTitle", product.Lang_Id);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Deleted";
                    return RedirectToAction("Index");
                }
            }




            ////var product = await _context.Products
            //    .Include(p => p.Category)
            //    .Include(p => p.Language)
            //    .FirstOrDefaultAsync(m => m.Product_Id == id);
            //if (product == null)
            //{
            //    return NotFound();
            //}

            //return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Product_Id == id);
        }
    }
}
