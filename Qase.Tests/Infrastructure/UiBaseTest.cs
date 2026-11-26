using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Qase.Framework.Core.Drivers;
using Qase.Tests.Configuration;

namespace Qase.Tests.Infrastructure;

public class UiBaseTest
{
    protected IWebDriver? Driver;

    [SetUp]
    public void SetUp()
    {
        var browser = Enum.Parse<BrowserType>(
            TestSettings.Browser,
            ignoreCase: true
        );

        Driver = DriverFactory.CreateDriver(browser, TestSettings.Headless);

        DriverManager.SetDriver(Driver);
        DriverManager.TimeoutSeconds = TestSettings.TimeoutSeconds;

        Driver.Manage().Window.Maximize();
        Driver.Navigate().GoToUrl(TestSettings.BaseUrl);
        
        AcceptCookies();
    }

    [TearDown]
    public void TearDown()
    {
        DriverManager.QuitDriver();
        Driver?.Dispose();
        Driver = null;
    }
    
    private void AcceptCookies()
    {
        var wait = new WebDriverWait(Driver!, TimeSpan.FromSeconds(10));

        var shadowHost = wait.Until(driver =>
            driver.FindElement(By.Id("usercentrics-cmp-ui")));

        var shadowRoot = shadowHost.GetShadowRoot();

        var acceptButton = wait.Until(_ =>
        {
            try
            {
                var button = shadowRoot.FindElement(By.Id("accept"));

                return button.Displayed && button.Enabled
                    ? button
                    : null;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        });

        acceptButton.Click();
    }
}