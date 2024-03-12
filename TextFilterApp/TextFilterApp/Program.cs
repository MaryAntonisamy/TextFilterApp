using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TextFilterApp.Application.Interfaces;
using TextFilterApp.Application.Services;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddTransient<ITextFilterService, TextFilterService>();
        services.AddTransient<IFileService, FileService>();
    })
    .Build();

var filePath = @"..\..\..\InputFile.txt";

var textFilterService = host.Services.GetRequiredService<ITextFilterService>();
var fileService = host.Services.GetRequiredService<IFileService>();
try
{
    string text =await fileService.ReadAllTextAsync(filePath);
    string filteredText = await textFilterService.ApplyAsync(text);
    Console.WriteLine(filteredText);
}
catch (IOException ex)
{
    Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
}



