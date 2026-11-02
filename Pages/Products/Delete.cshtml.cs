using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMS_CRUD_Razor_Lab08.Data;
using PMS_CRUD_Razor_Lab08.Models;

namespace PMS_CRUD_Razor_Lab08.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly ProductRepository _repository;
        private readonly ProductImageService _images;

        public DeleteModel(
            ProductRepository repository,
            ProductImageService images)
        {
            _repository = repository;
            _images = images;
        }

        public Product Product { get; private set; } = new();

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
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            try
            {
                bool deleted = await _repository.DeleteAsync(id);

                if (!deleted)
                {
                    return NotFound();
                }

                _images.Delete(product.image);

                TempData["Success"] = "Product deleted successfully!";
                return RedirectToPage("Index");
            }
            catch
            {
                TempData["Error"] =
                    "The product could not be deleted. Please try again.";

                return RedirectToPage("Index");
            }
        }
    }
}