using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Enlyce.E2E.Selenium;

// Un navegador por clase de pruebas. Selenium Manager descarga el chromedriver solo.
public sealed class BrowserFixture : IDisposable
{
    public IWebDriver Driver { get; }
    public string CrmUrl { get; } = Environment.GetEnvironmentVariable("DEMO_CRM_URL") ?? "http://localhost:5019";
    public string WebUrl { get; } = Environment.GetEnvironmentVariable("DEMO_WEB_URL") ?? "http://localhost:3000";
    public string AdminEmail { get; } = Environment.GetEnvironmentVariable("DEMO_ADMIN_EMAIL") ?? "admin@enlyce.test";
    public string AdminPassword { get; } = Environment.GetEnvironmentVariable("DEMO_ADMIN_PASSWORD") ?? "DemoEnlyce2026!!";

    public BrowserFixture()
    {
        var options = new ChromeOptions();
        if (Environment.GetEnvironmentVariable("DEMO_HEADED") != "1")
            options.AddArgument("--headless=new");
        options.AddArgument("--window-size=1400,900");
        Driver = new ChromeDriver(options);
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
    }

    public void Dispose() => Driver.Quit();
}
