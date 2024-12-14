using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.DTO;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class ImageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ImageController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Image
        public async Task<IActionResult> Index(int productId)
        {
            var applicationDbContext = _context.Images.Include(i => i.Product).Where(i => i.ProductId == productId);
            // pass the productId to the view
            //find the product by id
            Product product = _context.Products.Find(productId);
            ViewBag.Product = product;
            
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Image/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

   

        // POST: Image/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
   public async Task<IActionResult> Create(ImageDTO imageDTO)
{
    // Check if the model state is valid
    if (!ModelState.IsValid)
    {
        // If the model state is invalid, set the ViewData for ProductId dropdown and return to the view
        ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", imageDTO.ProductId);
        return View(imageDTO);
    }

    if (imageDTO.IsMain)
    {
        // find all the other images that is main set to true and set them to false
        List<Image> images = _context.Images.Where(i => i.ProductId == imageDTO.ProductId && i.IsMain).ToList();
        foreach (Image img in images)
        {
            img.IsMain = false;
            _context.Update(img);
        }
    }

    // Create a new image object
    Image image = new Image
    {
        ProductId = imageDTO.ProductId,
        IsMain = imageDTO.IsMain
    };

    // Process the image file
    if (imageDTO.ImageFile != null && imageDTO.ImageFile.Length > 0)
    {
        // Set the unique filename and path
        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imageDTO.ImageFile.FileName);
        string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images/products");

        // Ensure the uploads folder exists
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        // Save the file asynchronously
        try
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageDTO.ImageFile.CopyToAsync(fileStream);
            }

            // Set the URL of the saved image
            image.Url = $"/images/products/{uniqueFileName}";
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("ImageFile", "There was an error uploading the image: " + ex.Message);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", imageDTO.ProductId);
            return View(imageDTO);
        }
    }
    else
    {
        ModelState.AddModelError("ImageFile", "Image file is required.");
        ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", imageDTO.ProductId);
        return View(imageDTO);
    }

    // Add the image to the database
    try
    {
        _context.Add(image);
        await _context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
        ModelState.AddModelError(string.Empty, "An error occurred while saving the image: " + ex.Message);
        ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", imageDTO.ProductId);
        return View(imageDTO);
    }

    // Redirect to the Index page of the product
    return RedirectToAction("Index", new { productId = imageDTO.ProductId });
}


        // GET: Image/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", image.ProductId);
            return View(image);
        }

        // POST: Image/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Url,IsMain,ProductId")] Image image)
        {
            if (id != image.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(image.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", image.ProductId);
            return View(image);
        }

        // GET: Image/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image != null)
            {
                _context.Images.Remove(image);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageExists(int id)
        {
            return _context.Images.Any(e => e.Id == id);
        }
    }
}
