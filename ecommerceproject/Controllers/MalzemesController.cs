using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ecommerceproject.Data;
using ecommerceproject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.IO;
using ecommerceproject.ViewModels;

namespace ecommerceproject.Controllers
{
    public class MalzemesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostEnvironment;

        public MalzemesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this.hostEnvironment = hostEnvironment;

        }

        // GET: Malzemes
        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.Malzeme.Include(m => m.Category).Include(m=>m.MalzemeImages);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> UploadImage(ImageUploadViewModel uploadModel)
        {

            //string directory= @"C:\Users\Huseyin\source\repos\CetBookStore\CetBookStore\wwwroot\UserImages\";
            string directory = Path.Combine(hostEnvironment.WebRootPath, "UserImages");
            string fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(ImageUploadViewModel.ImageFile.FileName);
            string fullPath = Path.Combine(directory, fileName);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await uploadModel.ImageFile.CopyToAsync(fileStream);
            }

            MalzemeImage malzemeImage = new MalzemeImage();
            malzemeImage.MalzemeId = uploadModel.MalzemeId;
            malzemeImage.FileName = fileName;

            _context.MalzemeImages.Add(malzemeImage);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ManageImage), new { id = uploadModel.MalzemeId });


        }


        public async Task<IActionResult> ManageImage(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var malzeme = await _context.Malzeme.Include(b => b.MalzemeImages).Include(c => c.Category)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (malzeme == null)
            {
                return NotFound();
            }
            return View(malzeme);
        }

        // GET: Malzemes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var malzeme = await _context.Malzeme
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (malzeme == null)
            {
                return NotFound();
            }

            return View(malzeme);
        }

        // GET: Malzemes/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name");
            return View();
        }

        // POST: Malzemes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("Id,Title,PageCount,Authors,Description,Price,StockCount,CategoryId,CreatedDate")] Malzeme malzeme)
        {
            malzeme.CreatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(malzeme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", malzeme.CategoryId);
            return View(malzeme);
        }

        // GET: Malzemes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var malzeme = await _context.Malzeme.FindAsync(id);
            if (malzeme == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", malzeme.CategoryId);
            return View(malzeme);
        }

        // POST: Malzemes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,PageCount,Authors,Description,Price,StockCount,CategoryId,CreatedDate")] Malzeme malzeme)
        {
            if (id != malzeme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(malzeme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MalzemeExists(malzeme.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", malzeme.CategoryId);
            return View(malzeme);
        }

        // GET: Malzemes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var malzeme = await _context.Malzeme
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (malzeme == null)
            {
                return NotFound();
            }

            return View(malzeme);
        }

        // POST: Malzemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var malzeme = await _context.Malzeme.FindAsync(id);
            _context.Malzeme.Remove(malzeme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MalzemeExists(int id)
        {
            return _context.Malzeme.Any(e => e.Id == id);
        }
    }
}
