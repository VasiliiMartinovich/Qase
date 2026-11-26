using OpenQA.Selenium;

namespace Qase.Framework.Core.Pages.Projects;

public class CreateProjectForm : LoadablePage
{
    private static readonly By FormHeader = By.XPath("//h3[normalize-space()='Create new project']");
    private static readonly By ProjectNameField = By.Id("project-name");
    private static readonly By ProjectCodeField = By.Id("project-code");
    private static readonly By DescriptionField = By.Id("description-area");
    private static readonly By PrivateAccessRadio = By.CssSelector("input[type='radio'][value='private']");
    private static readonly By PublicAccessRadio = By.CssSelector("input[type='radio'][value='public']");
    private static readonly By CreateProjectButton = By.XPath("//button[@type='submit']");
    private static readonly By CancelButton = By.XPath("//button[.//span[normalize-space()='Cancel']]");

    public CreateProjectForm() : base(FormHeader)
    {
    }

    public bool CreateProjectFormIsDisplayed()
    {
        return FindVisibleElement(FormHeader).Displayed;
    }

    public CreateProjectForm EnterProjectName(string projectName)
    {
        Type(ProjectNameField, projectName);
        return this;
    }

    public CreateProjectForm EnterProjectCode(string projectCode)
    {
        Type(ProjectCodeField, projectCode);
        return this;
    }

    public CreateProjectForm EnterDescription(string description)
    {
        Type(DescriptionField, description);
        return this;
    }
    
    public CreateProjectForm SelectPublicAccess()
    {
        Click(PublicAccessRadio);
        return this;
    }
    
    public bool IsPrivateAccessSelected()
    {
        return FindVisibleElement(PrivateAccessRadio).Selected;
    }
        
    public CreateProjectForm SelectPrivateAccess()
    {
        Click(PrivateAccessRadio);
        return this;
    }

    public ProjectPage ClickCreateProject()
    {
        Click(CreateProjectButton);
        return new ProjectPage();
    }

    public void ClickCancel()
    {
        Click(CancelButton);
    }
}