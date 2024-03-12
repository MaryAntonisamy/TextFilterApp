namespace TextFilterApp.Application.Interfaces;

public interface IFileService
{
    Task<string> ReadAllTextAsync(string filePath);
}
