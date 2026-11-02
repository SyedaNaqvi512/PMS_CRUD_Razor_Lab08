using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMS_CRUD_Razor_Lab08.Data;
using PMS_CRUD_Razor_Lab08.Models;

namespace PMS_CRUD_Razor_Lab08.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ProductRepository _repository;
        private readonly ProductImageService _images;

        public CreateModel(
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

        public void OnGet()
        {
            Product.status = "Available";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string? imageError = _images.Validate(ImageFile);

            if (imageError != null)
            {
                ModelState.AddModelError(nameof(ImageFile), imageError);
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            string? savedImage = null;

            try
            {
                savedImage = await _images.SaveAsync(ImageFile!);
                Product.image = savedImage;

                await _repository.CreateAsync(Product);

                TempData["Success"] = "Product added successfully!";
                return RedirectToPage("Index");
            }
            catch
            {
                if (savedImage != null)
                {
                    _images.Delete(savedImage);
                }

                ModelState.AddModelError(
                    string.Empty,
                    "The product could not be saved. Check your database connection and try again.");

                return Page();
            }
        }
    }
}