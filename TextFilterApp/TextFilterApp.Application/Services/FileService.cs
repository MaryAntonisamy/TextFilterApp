using TextFilterApp.Application.Interfaces;

namespace TextFilterApp.Application.Services;

public class FileService : IFileService
{
    public async Task<string> ReadAllTextAsync(string filePath)
    {
        try
        {
            using (var reader = new StreamReader(filePath))
            {
                return await reader.ReadToEndAsync();
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"An error occurred while reading the file asynchronously: {filePath}", ex);
        }
    }
}
