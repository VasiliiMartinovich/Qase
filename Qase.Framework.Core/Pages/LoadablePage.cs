using OpenQA.Selenium;

namespace Qase.Framework.Core.Pages;

public class LoadablePage : BasePage
{
    protected LoadablePage(By pageReadyLocator)
    {
        FindVisibleElement(pageReadyLocator);
    }
}