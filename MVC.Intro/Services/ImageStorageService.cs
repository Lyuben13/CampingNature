namespace MVC.Intro.Services
{
    public class ImageStorageService
    {
        private static readonly HashSet<string> AllowedExtensions =
            new(StringComparer.OrdinalIgnoreCase) { ".jpg", ".jpeg", ".png", ".gif", ".webp" };

        private const long MaxFileSizeBytes = 5 * 1024 * 1024;

        private readonly IWebHostEnvironment _environment;

        public ImageStorageService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string ToWebPath(string? path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return "/images/tent-placeholder.svg";
            }

            return path.StartsWith('/') ? path : "/" + path;
        }

        public string? SaveImage(IFormFile? file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            if (file.Length > MaxFileSizeBytes)
            {
                throw new InvalidOperationException("Файлът е твърде голям. Максимум 5 MB.");
            }

            var extension = Path.GetExtension(file.FileName);
            if (string.IsNullOrEmpty(extension) || !AllowedExtensions.Contains(extension))
            {
                throw new InvalidOperationException("Позволени са само изображения: JPG, PNG, GIF или WEBP.");
            }

            var imagesPath = Path.Combine(_environment.WebRootPath, "images");
            Directory.CreateDirectory(imagesPath);

            var fileName = $"{Guid.NewGuid():N}{extension.ToLowerInvariant()}";
            var filePath = Path.Combine(imagesPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/images/" + fileName;
        }

        public void DeleteLocalImage(string? imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath) || !imagePath.StartsWith("/images/", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var relative = imagePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar);
            var fullPath = Path.Combine(_environment.WebRootPath, relative);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}
