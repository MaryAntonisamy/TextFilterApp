namespace TextFilterApp.Application.Interfaces;

public interface ITextFilterService
{
    Task<string> ApplyAsync(string str);
}
