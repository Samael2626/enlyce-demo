using OpenQA.Selenium;

namespace Enlyce.E2E.Selenium;

public sealed class PublicSiteTests(BrowserFixture browser) : IClassFixture<BrowserFixture>
{
    private IWebDriver Driver => browser.Driver;

    [Fact]
    public void Home_page_loads_with_title()
    {
        Driver.Navigate().GoToUrl(browser.WebUrl);

        Assert.Contains("Enlyce", Driver.Title);
    }

    [Fact]
    public void Property_listing_shows_seeded_demo_properties()
    {
        Driver.Navigate().GoToUrl($"{browser.WebUrl}/inmuebles");

        var cards = Driver.FindElements(By.CssSelector("a[href^='/inmuebles/']"));
        Assert.NotEmpty(cards);
    }
}
