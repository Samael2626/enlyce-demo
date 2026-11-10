using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Enlyce.E2E.Selenium;

public sealed class CrmLoginTests(BrowserFixture browser) : IClassFixture<BrowserFixture>
{
    private IWebDriver Driver => browser.Driver;

    private void SubmitLogin(string email, string password)
    {
        Driver.Navigate().GoToUrl($"{browser.CrmUrl}/login");
        Driver.FindElement(By.Id("email")).SendKeys(email);
        Driver.FindElement(By.Id("password")).SendKeys(password);
        Driver.FindElement(By.CssSelector("button[type=submit]")).Click();
    }

    [Fact]
    public void Login_with_valid_credentials_opens_dashboard()
    {
        SubmitLogin(browser.AdminEmail, browser.AdminPassword);

        new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(d => d.Url.Contains("/dashboard"));
        Assert.Contains("/dashboard", Driver.Url);
    }

    [Fact]
    public void Login_with_wrong_password_shows_error_and_stays_on_login()
    {
        SubmitLogin(browser.AdminEmail, "clave-incorrecta-123");

        var alert = new WebDriverWait(Driver, TimeSpan.FromSeconds(10))
            .Until(d => d.FindElement(By.CssSelector("[role=alert]")));
        Assert.False(string.IsNullOrWhiteSpace(alert.Text));
        Assert.Contains("/login", Driver.Url);
    }
}
