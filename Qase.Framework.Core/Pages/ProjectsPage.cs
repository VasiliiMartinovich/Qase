using OpenQA.Selenium;

namespace Qase.Framework.Core.Pages;

public class ProjectsPage : LoadablePage
{
    private static readonly By ProjectsHeader = By.CssSelector("[class='_5GG77']");
    
    public ProjectsPage(By pageReadyLocator) : base(ProjectsHeader)
    {
    }
}