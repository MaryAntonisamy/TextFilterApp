using TextFilterApp.Application.Interfaces;

namespace TextFilterApp.Application.Services;

public class TextFilterService : ITextFilterService
{
    public Task<string> ApplyAsync(string str)
    {
        return Task.Run(() =>
        {
            char[] spearator = { ' ', '.', ',', '!', '?' };
            String[] strlist = str.Split(spearator,
                  StringSplitOptions.RemoveEmptyEntries);
            var filteredWords = strlist.Where(word => !MiddleVowlsFilter(word))
                                     .Where(word => word.Length >= 3)
                                     .Where(word => !word.Contains('t'))
                                     .ToList();
            return string.Join(" ", filteredWords);
        });
    }

    private bool MiddleVowlsFilter(string str)
    {
        int middle = str.Length / 2;
        char[] vowls = { 'a', 'e', 'i', 'o', 'u' };

        if (str.Length % 2 == 0)
        {
            return vowls.Contains(str[middle - 1]) || vowls.Contains(str[middle]);
        }
        else
        {
            return vowls.Contains(str[middle]);
        }
    }
}
