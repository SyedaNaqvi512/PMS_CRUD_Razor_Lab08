using Microsoft.AspNetCore.Mvc.RazorPages;
using PMS_CRUD_Razor_Lab08.Data;
using PMS_CRUD_Razor_Lab08.Models;

namespace PMS_CRUD_Razor_Lab08.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ProductRepository _repository;

        public IndexModel(ProductRepository repository)
        {
            _repository = repository;
        }

        public List<Product> Products { get; private set; } = new();

        public async Task OnGetAsync()
        {
            Products = await _repository.GetAllAsync();
        }
    }
}