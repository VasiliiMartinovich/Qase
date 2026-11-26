using OpenQA.Selenium;

namespace Qase.Framework.Core.Pages;

public class NavigationMenu : BasePage
{
    private static readonly By ProjectsMenu = By.CssSelector(".b8HUG7.xmY5KU");

    public NavigationMenu()
    {
        
    }
    
    public ProjectsPage OpenProjects()
    {
        Click(ProjectsMenu);
        return new ProjectsPage();
    }
}