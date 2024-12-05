using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using T9_Spelling.Config;
using T9_Spelling.Extension;
using T9_Spelling.Providers;
using T9_Spelling.Services;

var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

var serviceProvider = new ServiceCollection()
            .Configure<AppSettings>(configuration.GetSection("AppSettings"))
            .AddTransient<IFileProvider, FileProvider>()
            .AddTransient<IFileService, FileService>()
            .BuildServiceProvider();

var appSettings = new AppSettings();
configuration.GetSection("AppSettings").Bind(appSettings);


var fileService = serviceProvider.GetRequiredService<IFileService>();

var rows = await fileService.GetRowsAsync(appSettings.InputPath);
short numberOfCases = Convert.ToInt16(rows[0]);

string[] results = new string[numberOfCases];

for (short i = 1; i <= numberOfCases; i++)
{
    results[i-1] = WordsToPhoneService.ConvertToPhoneButtons(rows[i]).CaseFormat(i);
}

await fileService.WriteRowsAsync(appSettings.OutputPath, results);
