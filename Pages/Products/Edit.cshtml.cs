using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMS_CRUD_Razor_Lab08.Data;
using PMS_CRUD_Razor_Lab08.Models;

namespace PMS_CRUD_Razor_Lab08.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly ProductRepository _repository;
        private readonly ProductImageService _images;

        public EditModel(
            ProductRepository repository,
            ProductImageService images)
        {
            _repository = repository;
            _images = images;
        }

        [BindProperty]
        public Product Product { get; set; } = new();

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            Product = product;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id != Product.Id)
            {
                return BadRequest();
            }

            var existing = await _repository.GetByIdAsync(id);

            if (existing == null)
            {
                return NotFound();
            }

            if (ImageFile != null && ImageFile.Length > 0)
            {
                string? imageError = _images.Validate(ImageFile);

                if (imageError != null)
                {
                    ModelState.AddModelError(nameof(ImageFile), imageError);
                }
            }

            if (!ModelState.IsValid)
            {
                Product.image = existing.image;
                return Page();
            }

            string? newImage = null;

            try
            {
                Product.image = existing.image;

                if (ImageFile != null && ImageFile.Length > 0)
                {
                    newImage = await _images.SaveAsync(ImageFile);
                    Product.image = newImage;
                }

                bool updated = await _repository.UpdateAsync(Product);

                if (!updated)
                {
                    if (newImage != null)
                    {
                        _images.Delete(newImage);
                    }

                    return NotFound();
                }

                if (newImage != null)
                {
                    _images.Delete(existing.image);
                }

                TempData["Success"] = "Product updated successfully!";
                return RedirectToPage("Index");
            }
            catch
            {
                if (newImage != null)
                {
                    _images.Delete(newImage);
                }

                ModelState.AddModelError(
                    string.Empty,
                    "The product could not be updated. Check your database connection and try again.");

                Product.image = existing.image;
                return Page();
            }
        }
    }
}