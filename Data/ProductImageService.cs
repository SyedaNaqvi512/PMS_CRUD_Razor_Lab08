using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace PMS_CRUD_Razor_Lab08.Data
{
    public class ProductImageService
    {
        private readonly string _imageFolder;

        private static readonly HashSet<string> AllowedExtensions =
            new(StringComparer.OrdinalIgnoreCase)
            {
                ".jpg", ".jpeg", ".png", ".webp"
            };

        private const long MaxFileSize = 5 * 1024 * 1024;

        public ProductImageService(IWebHostEnvironment environment)
        {
            _imageFolder = Path.Combine(
                environment.WebRootPath ?? Path.Combine(environment.ContentRootPath, "wwwroot"),
                "images",
                "products");

            Directory.CreateDirectory(_imageFolder);
        }

        public string? Validate(IFormFile? file)
        {
            if (file == null || file.Length == 0)
            {
                return "Please select a product image.";
            }

            if (file.Length > MaxFileSize)
            {
                return "Image size cannot exceed 5 MB.";
            }

            string extension = Path.GetExtension(file.FileName);

            if (!AllowedExtensions.Contains(extension))
            {
                return "Only JPG, JPEG, PNG, and WEBP images are allowed.";
            }

            return null;
        }

        public async Task<string> SaveAsync(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            string fileName = $"{Guid.NewGuid():N}{extension}";
            string fullPath = Path.Combine(_imageFolder, fileName);

            await using var stream = new FileStream(
                fullPath,
                FileMode.CreateNew,
                FileAccess.Write);

            await file.CopyToAsync(stream);

            return $"images/products/{fileName}";
        }

        public void Delete(string? relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
            {
                return;
            }

            string fileName = Path.GetFileName(relativePath);

            if (string.IsNullOrWhiteSpace(fileName))
            {
                return;
            }

            string fullPath = Path.GetFullPath(
                Path.Combine(_imageFolder, fileName));

            string safeRoot = Path.GetFullPath(_imageFolder)
                .TrimEnd(Path.DirectorySeparatorChar)
                + Path.DirectorySeparatorChar;

            if (!fullPath.StartsWith(
                    safeRoot,
                    StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}