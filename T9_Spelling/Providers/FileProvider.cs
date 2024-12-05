namespace T9_Spelling.Providers
{
    public class FileProvider : IFileProvider
    {
        public async Task<string[]> GetAllLinesAsync(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException($"File with path: {path} not found");

            return await File.ReadAllLinesAsync(path);
        }

        public async Task WriteRowsAsync(string path, string[] rows)
        {
            await File.AppendAllLinesAsync(path, rows);
        }
    }
}
