using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Qase.Framework.Core.Drivers;

namespace Qase.Framework.Core.Pages;

public class BasePage
{
    protected IWebDriver Driver => DriverManager.Driver;
    protected WebDriverWait Wait { get; }

    protected BasePage()
    {
        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(DriverManager.TimeoutSeconds));
    }
    
    protected IWebElement FindVisibleElement(By locator)
    {
        try
        {
            var element = Wait.Until(driver =>
            {
                var elements = driver.FindElements(locator);

                foreach (var n in elements)
                {
                    if (n.Displayed)
                        return n;
                }

                return null;
            })!;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
           throw;
        }
        catch (WebDriverException ex)
        {
            throw;
        }
    }
    
    protected void Click(By locator)
    {
        var element = Wait.Until(driver =>
        {
            var elements = driver.FindElements(locator);

            foreach (var item in elements)
            {
                if (item.Displayed && item.Enabled)
                    return item;
            }

            return null;
        });

        element.Click();
    }
    
    protected void Type(By locator, string text)
    {
        var element = FindVisibleElement(locator);
        element.Clear();
        element.SendKeys(text);
    }
}