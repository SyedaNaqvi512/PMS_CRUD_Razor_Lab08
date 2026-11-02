using System.ComponentModel.DataAnnotations;

namespace PMS_CRUD_Razor_Lab08.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product title is required.")]
        [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters.")]
        [Display(Name = "Product Title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(50, ErrorMessage = "Description cannot exceed 50 characters.")]
        [Display(Name = "Description")]
        public string description { get; set; } = string.Empty;

        [StringLength(255)]
        public string image { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Price cannot be negative.")]
        [Display(Name = "Price")]
        public int price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative.")]
        [Display(Name = "Quantity")]
        public int quantity { get; set; }

        [Required(ErrorMessage = "Please select a status.")]
        [StringLength(20)]
        public string status { get; set; } = "Available";
    }
}