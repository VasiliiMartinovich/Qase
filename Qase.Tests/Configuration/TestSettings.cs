using Microsoft.Extensions.Configuration;


namespace Qase.Tests.Configuration;


public static class TestSettings
{
    private static readonly IConfiguration Configuration =
        new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

    public static string BaseUrl =>
        Configuration["TestSettings:BaseUrl"]!;

    public static string Browser =>
        Configuration["TestSettings:Browser"]!;

    public static bool Headless =>
        bool.Parse(Configuration["TestSettings:Headless"]!);

    public static int TimeoutSeconds =>
        int.Parse(Configuration["TestSettings:TimeoutSeconds"]!);

    public static string Username =>
        Configuration["Credentials:Username"]!;

    public static string Password =>
        Configuration["Credentials:Password"]!;
}
