namespace T9_Spelling.Providers
{
    public interface IFileProvider
    {
        Task<string[]> GetAllLinesAsync(string path);
        Task WriteRowsAsync(string path, string[] rows);

    }
}
