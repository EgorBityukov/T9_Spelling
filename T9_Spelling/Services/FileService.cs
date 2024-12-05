using T9_Spelling.Providers;

namespace T9_Spelling.Services
{
    public class FileService : IFileService
    {
        private readonly IFileProvider _fileProvider;

        public FileService(IFileProvider fileProvider) 
        { 
            _fileProvider = fileProvider;
        }

        public async Task<string[]> GetRowsAsync(string? path)
        {
            if (!Path.IsPathFullyQualified(path)) throw new ArgumentException("Invalid Path");
            return await _fileProvider.GetAllLinesAsync(path);
        }

        public async Task WriteRowsAsync(string? path, string[] rows)
        {
            if (!Path.IsPathRooted(path)) throw new ArgumentException("Invalid Path");
            await _fileProvider.WriteRowsAsync(path, rows);
        }
    }
}
