using System.IO;
using System.Linq;

namespace OnlineMarket.Services
{
    public class FileService
    {
        private readonly IWebHostEnvironment _environment;

        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IEnumerable<string> GetFilesStartingWith(string subDirectory, string prefix)
        {
            // Combine the web root path with the subdirectory
            var directoryPath = Path.Combine(_environment.WebRootPath, subDirectory);

            if (Directory.Exists(directoryPath))
            {
                // Return all files that start with the specified prefix
                var files = Directory.GetFiles(directoryPath, $"{prefix}*");

                // Convert file paths to be relative to wwwroot (e.g., /img/file.jpg)
                return files.Select(file =>
                    Path.GetRelativePath(_environment.WebRootPath, file)
                           .Replace("\\", "/")); // Ensure paths are in URL-friendly format
            }

            return Enumerable.Empty<string>();
        }
    }
}
