using OpenQA.Selenium;
using Qase.Framework.Core.Pages.Projects;

namespace Qase.Framework.Core.Pages;

public class ProjectsPage : LoadablePage
{
    private static readonly By ProjectsHeader = By.CssSelector("h1._5GG77s");
    private static readonly By CreateNewProjectBtn = By.XPath("//button[.//span[normalize-space()='Create new project']]");
    private static readonly By SearchInput = By.CssSelector("[placeholder='Search for projects']");
    private static readonly By AddFilterBtn = By.XPath("//span[normalize-space()='Add filter']");
    private static readonly By ListViewBtn = By.CssSelector("[data-icon='list']");
    private static readonly By CellViewBtn = By.CssSelector("[data-icon='table-cells']");
    private static readonly By MoreOptionsButton = By.XPath("//svg[@data-icon='ellipsis-vertical']/ancestor::button");
    private static  By ProjectLink(string projectCode) => By.CssSelector($"a[href='/project/{projectCode}']");
    
    public ProjectsPage() : base(ProjectsHeader)
    {
    }
    
    public bool IsDisplayed()
    {
        return Driver.FindElement(ProjectsHeader).Displayed;
    }
    
    public CreateProjectForm ClickCreateNewProjectBtn()
    {
        Click(CreateNewProjectBtn);
        return new CreateProjectForm();
    }
    
    public bool IsProjectDisplayed(string projectCode, string projectName)
    {
        var projectLink = FindVisibleElement(ProjectLink(projectCode));
        return projectLink.Text == projectName;
    }
    
}