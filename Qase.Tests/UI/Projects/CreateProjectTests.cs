using NUnit.Framework;
using Qase.Framework.Core.Pages;
using Qase.Framework.Core.Pages.Authentication;
using Qase.Tests.Configuration;
using Qase.Tests.Infrastructure;
using Qase.Tests.Utilities;

namespace Qase.Tests.UI.Projects;

[TestFixture]
public class CreateProjectTests : UiBaseTest
{
    [SetUp]
    public void SetUp()
    {
        var loginPage =  new LoginPage();
        var projectsPage = loginPage
            .EnterEmail(TestSettings.Username)
            .EnterPassword(TestSettings.Password)
            .LoginSuccessfully();
    }

    [Test]
    public void CreateProject()
    {
        var projectName = "TestProject" + DateTime.Now.ToString("HHmmss");
        var projectCode = RandomDataGenerator.GenerateProjectCode();
        var description = "Test description";
        
        var projectsPage = new ProjectsPage();
        var createProjectForm = projectsPage.ClickCreateNewProjectBtn();
        Assert.That(createProjectForm.CreateProjectFormIsDisplayed(), Is.True);
        
        var projectPage   = createProjectForm
            .EnterProjectName(projectName)
            .EnterProjectCode(projectCode)
            .EnterDescription(description)
            .ClickCreateProject();
        Assert.That(
            projectPage.IsProjectUrlCorrect(projectCode),
            Is.True,
            "User should be redirected to the created project page.");

        Assert.That(
            projectPage.IsProjectHeaderCorrect(projectCode),
            Is.True,
            "Project header should contain the project code.");
    }
}