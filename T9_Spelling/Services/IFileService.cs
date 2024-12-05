namespace T9_Spelling.Services
{
    public interface IFileService
    {
        Task<string[]> GetRowsAsync(string? path);
        Task WriteRowsAsync(string? path, string[] rows);
    }
}
